using ConsoleApp1.Dtos;
using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    public class Identity
    {
        private string connectionString = "Server=JESUS;Database=Dma03;Integrated Security=true";

        public  User Login(string email, string password)
        {
            var conn = new SqlConnection(connectionString);

            var query = $"Select * from Users where Email ='{email}' And Password = '{password}'";
            SqlDataAdapter adapter = new SqlDataAdapter(query,conn);
            var table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                var user = new User()
                {
                    Email = email,
                    Password = password
                };
                return user;
            }

            return null;    
        }

        public bool Register(UserRegisterDto dto)
        {
            var conn = new SqlConnection(connectionString);
            conn.Open();
            var query = $"INSERT INTO Users Values('{dto.Name}','{dto.Email}', '{dto.Password}')";
            var cmd = new SqlCommand(query, conn);
            var rows =  cmd.ExecuteNonQuery();
            if(rows ==0)
            {
                conn.Close();
                return false;
            }
            conn.Close();
            return true;
        }
    }
}
