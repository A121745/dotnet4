using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace MVCwithDatabase.Models
{
    public class Employee
    {

        [Key]
        public int EmpNo { get; set; }
        

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter name")]
        [StringLength(10, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string Name { get; set; }

        [Range(1000, 500000, ErrorMessage = "Please enter values between 1000-500000")]
      //  [MaxLength(6), MinLength(4)]
        [Display(Name = "Basic Salary")]
        [DataType(DataType.Currency)]
        public decimal Basic { get; set; }

        public int DeptNo { get; set; }
        public static List<Employee> GetEmployees() {
           
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString= @"Data Source=(localdb)\ProjectsV13;Initial Catalog=JKJuly2022;Integrated Security=True;";
            List<Employee> list = new List<Employee>();
            try
            {
                cn.Open();
                SqlCommand s = new SqlCommand();
                s.Connection = cn;
                s.CommandType = System.Data.CommandType.StoredProcedure;
                s.CommandText = "DisplayEmployees1";
                SqlDataReader dr = s.ExecuteReader();
                while (dr.Read())
                {
                    Employee e = new Employee();
                    e.EmpNo=(int)dr["EmpNo"];
                    e.Name = (string)dr["Name"];
                    e.Basic = (decimal)dr["Basic"];
                    e.DeptNo = (int)dr["DeptNo"];
                    list.Add(e);

                }
                dr.Close();

            }
            catch (Exception e1)
            {
                Console.WriteLine(e1.Message);
            }

            finally
            {
                cn.Close();
            }
            return list;
        }

        internal static void InsertEmployee(object obj)
        {
            throw new NotImplementedException();
        }

        public static Employee GetSingleEmployee(int EmpNo) {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=JKJuly2022;Integrated Security=True;";
            Employee obj = null;

            cn.Open();
            SqlCommand s = new SqlCommand();
            s.Connection = cn;
            s.CommandType = System.Data.CommandType.StoredProcedure;
            s.CommandText = "GetSingleEmployee";
            s.Parameters.AddWithValue("@EmpNo", EmpNo);

            SqlDataReader dr = s.ExecuteReader();

            

            if (dr.Read())
            {
                obj = new Employee();
                obj.EmpNo = (int)dr["EmpNo"];
                obj.Name = (string)dr["Name"];
                obj.Basic = (decimal)dr["Basic"];
                obj.DeptNo = (int)dr["DeptNo"];
            }


            cn.Close();
            return obj;

        }
        public static void InsertEmployee(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=JKJuly2022;Integrated Security=True;";


            cn.Open();
            SqlCommand s = new SqlCommand();
            s.Connection = cn;
            s.CommandType = System.Data.CommandType.StoredProcedure;
            s.CommandText = "InsertEmployee";
            s.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
            s.Parameters.AddWithValue("@Name", obj.Name);
            s.Parameters.AddWithValue("@Basic", obj.Basic);
            s.Parameters.AddWithValue("@DeptNo", obj.DeptNo);
            s.ExecuteNonQuery();
            cn.Close();
        }
        public static void UpdateEmployee(int id, Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=JKJuly2022;Integrated Security=True;";


            cn.Open();
            SqlCommand s = new SqlCommand();
            s.Connection = cn;
            s.CommandType = System.Data.CommandType.StoredProcedure;
            s.CommandText = "UpdateEmployee";
            s.Parameters.AddWithValue("@EmpNo", id);
            s.Parameters.AddWithValue("@Name", obj.Name);
            s.Parameters.AddWithValue("@Basic", obj.Basic);
            s.Parameters.AddWithValue("@DeptNo", obj.DeptNo);
            s.ExecuteNonQuery();
        }
        public static void DeleteEmployee(int obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=JKJuly2022;Integrated Security=True;";


            cn.Open();
            SqlCommand s = new SqlCommand();
            s.Connection = cn;
            s.CommandType = System.Data.CommandType.StoredProcedure;
            s.CommandText = "DeleteEmployee";
            s.Parameters.AddWithValue("@EmpNo", obj);
            s.ExecuteNonQuery();
            cn.Close();
        }

    }
}
