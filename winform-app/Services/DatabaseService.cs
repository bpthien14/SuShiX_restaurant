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
                        MessageBox.Show($"ItemID: {menuItem.ItemID}, ItemName: {menuItem.ItemName}, CurrentPrice: {menuItem.CurrentPrice}, DeliveryAvailable: {menuItem.DeliveryAvailable}");
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"An error occurred: {ex.Message}");

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
        public DataTable GetMenuItemStatus(string branchID, DateTime fromDate, DateTime toDate)
        {
            DataTable menuItemStatus = new DataTable();

            using (SqlConnection connection = GetConnection())
            {
                SqlCommand command = new SqlCommand("sp_GetMenuItemStatus", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@BranchID", string.IsNullOrEmpty(branchID) ? (object)DBNull.Value : branchID);
                command.Parameters.AddWithValue("@FromDate", fromDate);
                command.Parameters.AddWithValue("@ToDate", toDate);

                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(menuItemStatus);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
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
                    Console.WriteLine($"An error occurred: {ex.Message}");
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
                                    dashboard.ProcessingOrders = Convert.ToInt32(reader["ProcessingOrders"]);
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

    }
}
