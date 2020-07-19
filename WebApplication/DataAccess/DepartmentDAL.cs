using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication.Models;
using static WebApplication.Entity.DepartmentEntity;

namespace WebApplication.DataAccess
{
    public class DepartmentDAL
    {
        /// <summary>
        /// Create Department
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string InsertDepartment(DepartmentCustom data)
        {
            string result = "";
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Test; Integrated Security = True");
                SqlCommand cmd = new SqlCommand("InsertDepartment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@departmentName", data.departmentName);
                cmd.Parameters.AddWithValue("@departmentDesc", data.departmentDesc);
                cmd.Parameters.AddWithValue("@isDeleted", 0);
                cmd.Parameters.AddWithValue("@createdOn", DateTime.Now);
                con.Open();
                object res = cmd.ExecuteNonQuery();
                con.Close();
                return result = "Item Added Successfully";
            }
            catch(Exception ex)
            {
                return result = "Item Not Added";
            }
        }

        /// <summary>
        /// Update Department
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string UpdateDepartment(DepartmentCustom data)
        {
            string result = "";
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Test; Integrated Security = True");
                SqlCommand cmd = new SqlCommand("UpdateDepartment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@departmentName", data.departmentName);
                cmd.Parameters.AddWithValue("@departmentDescription", data.departmentDesc);
                cmd.Parameters.AddWithValue("@id", data.id);
                cmd.Parameters.AddWithValue("@modifiedOn", DateTime.Now);
                con.Open();
                object res = cmd.ExecuteNonQuery();
                con.Close();
                return result = "Item Added Successfully";
            }
            catch (Exception ex)
            {
                return result = "Item Not Added";
            }
        }

        /// <summary>
        /// Delete Department
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeleteDepartment(int id)
        {
            string result = "";
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Test; Integrated Security = True");
                SqlCommand cmd = new SqlCommand("DeleteDepartment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@modifiedOn", DateTime.Now);
                con.Open();
                object res = cmd.ExecuteNonQuery();
                con.Close();
                return result = "Item Added Successfully";
            }
            catch (Exception ex)
            {
                return result = "";
            }
        }

        /// <summary>
        /// Get All Department
        /// </summary>
        /// <returns></returns>
        public List<Department> GetAllDepartment()
        {
            string result = "";
            DataTable dt = new DataTable();
            List<Department> departmentsList = new List<Department>();
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Test; Integrated Security = True");
                SqlCommand cmd = new SqlCommand("GetAllDepartment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                object res = cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);

                foreach(DataRow row in dt.Rows)
                {
                    departmentsList.Add(
                        new Department
                        {
                            departmentName = row["departmentName"].ToString(),
                            Id = Convert.ToInt32(row["id"]),
                            departmentDesc = row["departmentDesc"].ToString()
                        }) ;
                }
                return departmentsList;
            }
            catch (Exception ex)
            {
                return departmentsList;
            }
        }

        /// <summary>
        /// Get Department By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Department GetDepartmentById(int id)
        {
            string result = "";
            DataTable dt = new DataTable();
            Department department = new Department();

            try
            {
                SqlConnection con = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Test; Integrated Security = True");
                SqlCommand cmd = new SqlCommand("GetDepartmentById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                object res = cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);

                foreach(DataRow row in dt.Rows)
                {
                    department.Id = Convert.ToInt32(row["id"]);
                    department.departmentName = row["departmentName"].ToString();
                    department.departmentDesc = row["departmentDesc"].ToString();
                }
                return department;
            }
            catch (Exception ex)
            {
                return department;
            }
        }
    }
}