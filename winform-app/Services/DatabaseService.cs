using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using winform_app.Models;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using System.Data;
using System.Diagnostics;

namespace winform_app.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString;
        private string? customerID;

        public DatabaseService()
        {
            // Lấy connection string từ App.config
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        // Phương thức kết nối cơ bản
        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public List<Models.Region> GetRegions()
        {
            List<Models.Region> regions = new List<Models.Region>();

            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT RegionID, RegionName FROM REGION";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Models.Region region = new Models.Region
                        {
                            RegionID = reader.GetInt32(0),
                            RegionName = reader.GetString(1)
                        };
                        regions.Add(region);
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

            return regions;
        }
        public Models.Region GetRegionByBranchId(string branchID)
        {
            Models.Region region = null;

            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT REGION.RegionID, REGION.RegionName FROM REGION JOIN BRANCH ON BRANCH.RegionID = REGION.RegionID WHERE BRANCH.BranchID = @BranchID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BranchID", branchID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        region = new Models.Region
                        {
                            RegionID = reader.GetInt32(0),
                            RegionName = reader.GetString(1)
                        };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

            return region;
        }
        public string GetBranchNameById(string branchID)
        {
            string branchName = string.Empty;

            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT BranchName FROM BRANCH WHERE BranchID = @BranchID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BranchID", branchID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        branchName = reader.GetString(0);
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

            return branchName;
        }
        public List<Models.Department> GetDepartments()
        {
            List<Models.Department> departments = new List<Models.Department>();

            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT DepartmentID, DepartmentName FROM DEPARTMENT";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Models.Department department = new Models.Department
                        {
                            DepartmentID = reader.GetString(0),
                            DepartmentName = reader.GetString(1)
                        };
                        departments.Add(department);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

            return departments;
        }

        public DataTable GetStaffStatistics(int regionID, string? branchID, string? departmentID)
        {
            DataTable staffStatistics = new DataTable();

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("sp_GetStaffStatistics", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RegionID", regionID);
                command.Parameters.AddWithValue("@BranchID", string.IsNullOrEmpty(branchID) ? (object)DBNull.Value : branchID);
                command.Parameters.AddWithValue("@DepartmentID", string.IsNullOrEmpty(departmentID) ? (object)DBNull.Value : departmentID);
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(staffStatistics);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return staffStatistics;
        }
        public List<Models.Branch> GetBranchesByRegion(int regionID)
        {
            List<Models.Branch> branches = new List<Models.Branch>();

            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT BranchID, RegionID, BranchName, Address, BranchPhoneNumber, OpeningTime, ClosingTime, HasCarParking, HasBikeParking, DeliveryService, ManagerID FROM BRANCH WHERE RegionID = @RegionID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RegionID", regionID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Models.Branch branch = new Models.Branch
                        {
                            BranchID = reader.GetString(0),
                            RegionID = reader.GetInt32(1),
                            BranchName = reader.GetString(2),
                            Address = reader.GetString(3),
                            BranchPhoneNumber = reader.GetString(4),
                            OpeningTime = reader.GetTimeSpan(5),
                            ClosingTime = reader.GetTimeSpan(6),
                            HasCarParking = reader.GetBoolean(7),
                            HasBikeParking = reader.GetBoolean(8),
                            DeliveryService = reader.GetBoolean(9),
                            ManagerID = reader.GetString(10)
                        };
                        branches.Add(branch);
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

            return branches;
        }
        public List<Models.MenuItem> GetMenuItemsByBranch(string branchID)
        {
            List<Models.MenuItem> menuItems = new List<Models.MenuItem>();

            using (SqlConnection connection = GetConnection())
            {
                string query = @"
                    SELECT MENU_ITEM.ItemID, MENU_ITEM.CategoryID, MENU_ITEM.ItemName, MENU_ITEM.CurrentPrice, MENU_ITEM.DeliveryAvailable
                    FROM MENU_ITEM
                    JOIN MENU_ITEM_AVAILABILITY ON MENU_ITEM.ItemID = MENU_ITEM_AVAILABILITY.ItemID
                    WHERE MENU_ITEM_AVAILABILITY.BranchID = @BranchID AND MENU_ITEM_AVAILABILITY.IsAvailable = 1";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BranchID", branchID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Models.MenuItem menuItem = new Models.MenuItem
                        {
                            ItemID = reader.GetString(0),
                            CategoryID = reader.GetString(1),
                            ItemName = reader.GetString(2),
                            CurrentPrice = reader.GetDouble(3),
                            DeliveryAvailable = reader.GetBoolean(4)
                        };

                        menuItems.Add(menuItem);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");

                }
            }

            return menuItems;
        }
        public DataTable GetRevenueStatisticsByBranch(DateTime startDate, DateTime endDate, string branchID)
        {
            DataTable revenueStats = new DataTable();

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("sp_GetRevenueStatisticsByBranch", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);
                command.Parameters.AddWithValue("@BranchID", branchID);

                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(revenueStats);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return revenueStats;
        }
        public DataTable GetMenuItemStatus(string branchID, DateTime fromDate, DateTime toDate, string ItemID = null)
        {
            DataTable menuItemStatus = new DataTable();

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("sp_GetMenuItemStatus", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BranchID", string.IsNullOrEmpty(branchID) ? (object)DBNull.Value : branchID);
                command.Parameters.AddWithValue("@FromDate", fromDate);
                command.Parameters.AddWithValue("@ToDate", toDate);
                command.Parameters.AddWithValue("@ItemID", string.IsNullOrEmpty(ItemID) ? (object)DBNull.Value : ItemID);

                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(menuItemStatus);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error: {ex.Message}");
                }
            }

            return menuItemStatus;
        }


        // Phương thức kiểm tra thông tin đăng nhập
        public bool CheckLogin(string loginInput, string password, out Users user)
        {
            user = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("sp_CheckLogin", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@LoginInput", loginInput);
                command.Parameters.AddWithValue("@Password", password);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        user = new Users
                        {
                            UserID = reader["UserID"].ToString(),
                            Username = reader["FullName"].ToString(), // Assuming FullName is used as Username
                            Password = password, // Do not store plain text passwords in production
                            Role = reader["Role"].ToString()
                        };
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            return false;
        }
        public bool CheckLoginStaff(string loginInput, string password, out Staff staff, out string? level)
        {
            staff = null;
            level = null;
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("sp_CheckLogin_Staff", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@LoginInput", loginInput);
                command.Parameters.AddWithValue("@Password", password);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        staff = new Staff
                        {
                            UserID = reader["UserID"].ToString(),
                            FullName = reader["FullName"].ToString(),
                            BranchID = reader["BranchID"].ToString(),
                        };
                        level = reader["Role"].ToString();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi
                    Debug.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            return false;
        }
        public class CustomerDashboard
        {
            public string FullName { get; set; }
            public string CardType { get; set; }
            public float AccumulatedPoints { get; set; }
            public int PendingBookings { get; set; }
            public int ProcessingOrders { get; set; }
        }

        public CustomerDashboard GetCustomerDashboard(string userId)
        {
            CustomerDashboard dashboard = new CustomerDashboard();

            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand("sp_GetCustomerDashboard", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserID", userId);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                if (reader.Read())
                                {
                                    dashboard.FullName = reader["FullName"].ToString();
                                    dashboard.CardType = reader["CardType"].ToString();
                                    dashboard.AccumulatedPoints = Convert.ToSingle(reader["AccumulatedPoints"]);
                                }

                                if (reader.NextResult() && reader.Read())
                                {
                                    dashboard.PendingBookings = Convert.ToInt32(reader["PendingBookings"]);
                                }

                                if (reader.NextResult() && reader.Read())
                                {
                                    dashboard.ProcessingOrders = Convert.ToInt32(reader["PendingOrderCount"]);
                                }
                            }
                            else
                            {
                                MessageBox.Show("No data found for the given customer ID.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }
            }

            return dashboard;
        }
        public string GetCustomerIDByInfo(string customerInfo)
        {
            string customerID = null;

            using (SqlConnection connection = GetConnection())
            {
                string query = @"
            SELECT CustomerID 
            FROM CUSTOMER 
            WHERE FullName = @CustomerInfo ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerInfo", customerInfo);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        customerID = reader["CustomerID"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

            return customerID;
        }


        public bool BookTable(OrderTable orderTable, out int bookingID)
        {
            bookingID = 0;
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand("sp_BookTable", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@CustomerID", orderTable.CustomerID);
                    command.Parameters.AddWithValue("@BranchID", orderTable.BranchID);
                    command.Parameters.AddWithValue("@GuestCount", orderTable.TableNumber);
                    command.Parameters.AddWithValue("@BookingDate", orderTable.OrderDate);
                    command.Parameters.AddWithValue("@ArrivalTime", orderTable.OrderDate.TimeOfDay);
                    command.Parameters.AddWithValue("@Notes", orderTable.Notes);
                    command.Parameters.AddWithValue("@GuestName", orderTable.GuestName);
                    command.Parameters.AddWithValue("@GuestPhone", orderTable.GuestPhone);
                    command.Parameters.AddWithValue("@Status", orderTable.OrderStatus);

                    try
                    {
                        connection.Open();
                        bookingID = Convert.ToInt32(command.ExecuteScalar());
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        return false;
                    }
                }
            }
        }
        public Models.Branch GetBranchById(string branchID)
        {
            Models.Branch branch = null;

            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT BranchID, RegionID, BranchName, Address, BranchPhoneNumber, OpeningTime, ClosingTime, HasCarParking, HasBikeParking, DeliveryService, ManagerID FROM BRANCH WHERE BranchID = @BranchID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BranchID", branchID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        branch = new Models.Branch
                        {
                            BranchID = reader.GetString(0),
                            RegionID = reader.GetInt32(1),
                            BranchName = reader.GetString(2),
                            Address = reader.GetString(3),
                            BranchPhoneNumber = reader.GetString(4),
                            OpeningTime = reader.GetTimeSpan(5),
                            ClosingTime = reader.GetTimeSpan(6),
                            HasCarParking = reader.GetBoolean(7),
                            HasBikeParking = reader.GetBoolean(8),
                            DeliveryService = reader.GetBoolean(9),
                            ManagerID = reader.GetString(10)
                        };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

            return branch;
        }
        public List<Category> GetCategoriesByBranch(string branchID)
        {
            List<Category> categories = new List<Category>();

            using (SqlConnection connection = GetConnection())
            {
                string query = @"
            SELECT DISTINCT MENU_ITEM.CategoryID, MENU_CATEGORY.CategoryName
            FROM MENU_ITEM
            JOIN MENU_CATEGORY ON MENU_ITEM.CategoryID = MENU_CATEGORY.CategoryID
            JOIN MENU_ITEM_AVAILABILITY ON MENU_ITEM.ItemID = MENU_ITEM_AVAILABILITY.ItemID
            WHERE MENU_ITEM_AVAILABILITY.BranchID = @BranchID AND MENU_ITEM_AVAILABILITY.IsAvailable = 1";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@BranchID", branchID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Category category = new Category
                        {
                            CategoryID = reader.GetString(0),
                            CategoryName = reader.GetString(1)
                        };

                        categories.Add(category);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"An error occurred: {ex.Message}");
                }
            }

            return categories;
        }
        public bool SaveOrderAndBooking(OrderTable order, List<OrderItem> orderItems, OnlineBooking booking, double discount, double finalAmount)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var command = new SqlCommand("sp_SaveOrderAndBooking", connection, transaction)
                        {
                            CommandType = CommandType.StoredProcedure
                        };

                        // Booking parameters
                        command.Parameters.AddWithValue("@CustomerID", booking.CustomerID);
                        command.Parameters.AddWithValue("@BranchID", booking.BranchID);
                        command.Parameters.AddWithValue("@GuestCount", booking.GuestCount);
                        command.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
                        command.Parameters.AddWithValue("@ArrivalTime", booking.BookingDate.TimeOfDay);
                        command.Parameters.AddWithValue("@Notes", booking.Notes ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@GuestName", booking.GuestName);
                        command.Parameters.AddWithValue("@GuestPhone", booking.GuestPhone);
                        command.Parameters.AddWithValue("@DeliveryType", booking.DeliveryType);
                        command.Parameters.AddWithValue("@DeliveryAddress", booking.DeliveryAddress ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@DeliveryFee", booking.DeliveryFee);
                        command.Parameters.AddWithValue("@Status", booking.Status);

                        // Order parameters
                        command.Parameters.AddWithValue("@OrderID", order.OrderID);
                        command.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                        command.Parameters.AddWithValue("@StaffID", order.StaffID ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@TableNumber", order.TableNumber);

                        // Invoice parameters
                        command.Parameters.AddWithValue("@Discount", discount);
                        command.Parameters.AddWithValue("@FinalAmount", finalAmount);

                        // OrderItems as structured table parameter
                        var orderItemsTable = new DataTable();
                        orderItemsTable.Columns.Add("ItemID", typeof(string));
                        orderItemsTable.Columns.Add("Quantity", typeof(int));
                        foreach (var item in orderItems)
                        {
                            orderItemsTable.Rows.Add(item.ItemID, item.Quantity);
                        }
                        var orderItemsParam = new SqlParameter("@OrderItems", SqlDbType.Structured)
                        {
                            TypeName = "dbo.OrderItemTableType",
                            Value = orderItemsTable
                        };
                        command.Parameters.Add(orderItemsParam);

                        // Execute the command
                        int bookingID = Convert.ToInt32(command.ExecuteScalar());

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        // Log the exception
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }
        public Customer GetCustomerByUserID(string userID)
        {
            Customer customer = null;
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM CUSTOMER WHERE UserID = @UserID", connection))
                {
                    command.Parameters.AddWithValue("@UserID", userID);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customer = new Customer
                            {
                                CustomerID = reader["CustomerID"].ToString(),
                                FullName = reader["FullName"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                Email = reader["Email"].ToString(),
                                IDNumber = reader["IDNumber"].ToString(),
                                Gender = reader["Gender"].ToString(),
                                UserID = reader["UserID"].ToString()
                            };
                        }
                    }
                }
            }
            return customer;
        }
        public string GetNextOrderID()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT TOP 1 OrderID FROM ORDER_TABLE ORDER BY OrderID DESC", connection))
                {
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        string lastOrderID = result.ToString();
                        int numericPart = int.Parse(lastOrderID.Substring(3));
                        return $"ORD{(numericPart + 1).ToString("D5")}";
                    }
                    else
                    {
                        return "ORD00001"; // Default starting OrderID
                    }
                }
            }
        }

    }
}
