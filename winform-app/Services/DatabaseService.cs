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
        public DataTable GetRevenueStatisticsByBranch(DateTime startDate, DateTime endDate, string branchID)
        {
            DataTable revenueStats = new DataTable();

            using (SqlConnection connection = GetConnection())
            {
                string query = @"
                            SELECT RevenueData.BranchName AS N'Chi Nhánh', 
                               CAST(RevenueData.RevenueDate AS DATE) AS N'Ngày', 
                               COUNT(*) AS N'Số đơn', 
                               SUM(RevenueData.TotalRevenue) AS N'Tổng Doanh Thu', 
                               AVG(RevenueData.TotalRevenue) AS N'Trung Bình'
                            FROM (
                                SELECT BRANCH.BranchName, 
                                   ORDER_INVOICE.CreatedAt AS RevenueDate, 
                                   ORDER_INVOICE.FinalAmount AS TotalRevenue
                                FROM ORDER_INVOICE
                                JOIN ORDER_TABLE ON ORDER_INVOICE.OrderID = ORDER_TABLE.OrderID
                                JOIN BRANCH ON ORDER_TABLE.BranchID = BRANCH.BranchID
                                WHERE CAST(ORDER_INVOICE.CreatedAt AS DATE) BETWEEN CAST(@StartDate AS DATE) AND CAST(@EndDate AS DATE)
                                AND BRANCH.BranchID = @BranchID

                                UNION ALL

                                SELECT BRANCH.BranchName, 
                                       BOOKING_INVOICE.CreatedAt AS RevenueDate, 
                                       BOOKING_INVOICE.FinalAmount AS TotalRevenue
                                FROM BOOKING_INVOICE
                                JOIN ONLINE_BOOKING ON BOOKING_INVOICE.BookingID = ONLINE_BOOKING.BookingID
                                JOIN BRANCH ON ONLINE_BOOKING.BranchID = BRANCH.BranchID
                                WHERE CAST(BOOKING_INVOICE.CreatedAt AS DATE) BETWEEN CAST(@StartDate AS DATE) AND CAST(@EndDate AS DATE)
                                  AND BRANCH.BranchID = @BranchID
                            ) AS RevenueData
                            GROUP BY RevenueData.BranchName, RevenueData.RevenueDate
                            ORDER BY RevenueData.RevenueDate;";


                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@StartDate", SqlDbType.Date).Value = startDate.Date;
                command.Parameters.Add("@EndDate", SqlDbType.Date).Value = endDate.Date;
                command.Parameters.Add("@BranchID", SqlDbType.VarChar).Value = branchID;

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
