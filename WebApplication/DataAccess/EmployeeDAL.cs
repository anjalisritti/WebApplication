using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication.Models;
using static WebApplication.Entity.EmployeeEntity;

namespace WebApplication.DataAccess
{
    public class EmployeeDAL
    {
        /// <summary>
        /// Insert Employee
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string InsertEmployee(EmployeeCustom data)
        {
           string result = "";
            
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Test; Integrated Security = True");
                SqlCommand cmd = new SqlCommand("InsertEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@employeeName", data.employeeName);
                cmd.Parameters.AddWithValue("@employeeNo", data.employeeNo);
                cmd.Parameters.AddWithValue("@departmentId", data.departmentId);
                cmd.Parameters.AddWithValue("@salary", data.salary);
                cmd.Parameters.AddWithValue("@joiningDate", data.joiningDate);
                cmd.Parameters.AddWithValue("@isDeleted", 0);
                cmd.Parameters.AddWithValue("@createdOn", DateTime.Now);
                con.Open();
                object res = cmd.ExecuteScalar();
                con.Close();
                return result = "Added Sussessfully";
            }
            catch(Exception ex)
            {
                return result = "Not Added";
            }
        }

        /// <summary>
        /// Upload Employee
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string UploadEmployee(EmployeeCustom data)
        {
            
            string result = "";
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Test; Integrated Security = True");
                SqlCommand cmd = new SqlCommand("UpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@employeeName", data.employeeName);
                cmd.Parameters.AddWithValue("@employeeNo", data.employeeNo);
                cmd.Parameters.AddWithValue("@departmentId", data.departmentId);
                cmd.Parameters.AddWithValue("@salary", data.salary);
                cmd.Parameters.AddWithValue("@joiningDate", data.joiningDate);
                cmd.Parameters.AddWithValue("@id", data.id);
                cmd.Parameters.AddWithValue("@modifiedOn", DateTime.Now);
                con.Open();
                object res = cmd.ExecuteScalar();
                con.Close();
                return result = "Updated Successfully";
            }
            catch (Exception ex)
            {
                return result = "Not Updated";
            }
        }

        /// <summary>
        /// Delete Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeleteEmployee(int id)
        {
            string result = "";
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Test; Integrated Security = True");
                SqlCommand cmd = new SqlCommand("DeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@modifiedOn", DateTime.Now);
                con.Open();
                object res = cmd.ExecuteScalar();
                return result = "Deleted Successfully";
            }
            catch (Exception ex)
            {
                return result = "";
            }
        }

        /// <summary>
        /// Get Employee By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee GetEmployeeById(int id)
        {
            DataSet ds = new DataSet();
            Employee employeeDetails = new Employee();
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Test; Integrated Security = True");
                SqlCommand cmd = new SqlCommand("GetEmployeeById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    employeeDetails.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());
                    employeeDetails.employeeName = ds.Tables[0].Rows[i]["employeeName"].ToString();
                    employeeDetails.employeeNo = ds.Tables[0].Rows[i]["employeeNo"].ToString();
                    employeeDetails.salary = ds.Tables[0].Rows[i]["salary"].ToString();
                    employeeDetails.joiningDate = ds.Tables[0].Rows[i]["joiningDate"].ToString();
                    employeeDetails.departmentId = Convert.ToInt32(ds.Tables[0].Rows[i]["departmentId"].ToString());
                }
                return employeeDetails;
            }
            catch (Exception ex)
            {
                return employeeDetails;
            }
        }

        /// <summary>
        /// Get All Employee
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAllEmployee()
        {
            DataTable ds = new DataTable();
            List<Employee> employeeDetailsList = new List<Employee>();

            try
            {
                SqlConnection con = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Test; Integrated Security = True");
                SqlCommand cmd = new SqlCommand("GetAllEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);

                foreach(DataRow dataRow in ds.Rows)
                {
                    employeeDetailsList.Add(
                        new Employee
                        {
                            Id = Convert.ToInt32(dataRow["id"]),
                            employeeName = dataRow["employeeName"].ToString(),
                            employeeNo = dataRow["employeeNo"].ToString(),
                            salary = dataRow["salary"].ToString(),
                            joiningDate = dataRow["joiningDate"].ToString(),
                            departmentId = Convert.ToInt32(dataRow["departmentId"]),
                            //departmentName = dataRow["departmentName"].ToString()
                        });
                }
                return employeeDetailsList;
            }
            catch (Exception ex)
            {
                return employeeDetailsList;
            }
        }
    }
}