using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using winform_app.Models;

namespace winform_app.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString;

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
                            Role = "customer" // Assuming role is customer for this context
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
    }
}
