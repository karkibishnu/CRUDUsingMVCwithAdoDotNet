using CRUDUsingMVCwithAdoDotNet.git.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUDUsingMVCwithAdoDotNet.git.Repository
{
    public class EmployeeRepository
    {
        private SqlConnection sqlConnection;

        private void Connection()
        {
            string conStr = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
            sqlConnection = new SqlConnection(conStr);
        }

        public bool AddEmployee(EmployeeModel employee)
        {
            Connection();
            SqlCommand command = new SqlCommand("AddEmployee", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Name", employee.Name);
            command.Parameters.AddWithValue("@City", employee.City);
            command.Parameters.AddWithValue("@Address", employee.Address);

            sqlConnection.Open();
            int i = command.ExecuteNonQuery();

            sqlConnection.Close();

            return i >= 1;
        }

        public List<EmployeeModel> GetEmployees()
        {
            Connection();
            List<EmployeeModel> lstEmployee = new List<EmployeeModel>();

            SqlCommand command = new SqlCommand("GetEmployees", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();

            sqlConnection.Open();
            da.Fill(dt);
            sqlConnection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                lstEmployee.Add(
                    new EmployeeModel()
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        City = Convert.ToString(dr["City"]),
                        Address = Convert.ToString(dr["Address"])
                    }
                );
            }

            return lstEmployee;
        }

        public bool UpdateEmployee(EmployeeModel employee)
        {
            Connection();
            SqlCommand command = new SqlCommand("UpdateEmployee", sqlConnection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", employee.Id);
            command.Parameters.AddWithValue("@Name", employee.Name);
            command.Parameters.AddWithValue("@City", employee.City);
            command.Parameters.AddWithValue("@Address", employee.Address);

            sqlConnection.Open();
            int i = command.ExecuteNonQuery();
            sqlConnection.Close();

            return i >= 1;
        }

        public bool DeleteEmployee(int id)
        {
            Connection();
            SqlCommand command = new SqlCommand("DeleteEmployee", sqlConnection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);

            sqlConnection.Open();
            int i = command.ExecuteNonQuery();

            return i >= 1;
        }
    }
}