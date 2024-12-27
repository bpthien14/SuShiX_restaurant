using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using winform_app.Models;
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
