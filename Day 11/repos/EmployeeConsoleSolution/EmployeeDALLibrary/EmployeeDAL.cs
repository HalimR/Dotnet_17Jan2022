using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using EmployeeModelLibrary;

namespace EmployeeDALLibrary
{
    public class EmployeeDAL
    {
        SqlConnection conn;

        public EmployeeDAL()
        {
            conn = MyConnection.GetConnection();
        }

        public ICollection<Employee> GetAllEmployee()
        {
            List<Employee> employees = new List<Employee>();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("proc_GetAllEmployee", conn);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.Fill(ds);
            Employee employee;
            //if (ds.Tables[0].Rows.Count == 0)
                //throw new NoPizzaException();
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                    employee = new Employee();
                    employee.Id = Convert.ToInt32(item[0]);
                    employee.Name = item[1].ToString();
                    employee.Age = Convert.ToInt32(item[2]);
                    employees.Add(employee);
            }
            return employees;
        }

        //public ICollection<Employee> GetEmployeeById(int id)
        //{
        //    List<Employee> employees = new List<Employee>();
        //    DataSet ds = new DataSet();
        //    SqlDataAdapter adapter = new SqlDataAdapter("proc_GetAllEmployee", conn);
        //    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@emp_id", id);
        //    adapter.Fill(ds);
        //    Employee employee;
        //    if (ds.Tables[0].Rows.Count == 0)
        //        //throw new NoPizzaException();
        //        foreach (DataRow item in ds.Tables[0].Rows)
        //        {
        //            employee = new Employee();
        //            employee.Id = Convert.ToInt32(item[0]);
        //            employee.Name = item[1].ToString();
        //            employee.Age = Convert.ToInt32(item[2]);
        //            employee.Add(employee);
        //        }
        //    return employees;
        //}
        public bool InsertNewEmployee(Employee employee)
        {
            SqlCommand cmd = new SqlCommand("proc_InsertEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@emp_name", employee.Name);
            cmd.Parameters.AddWithValue("@emp_age", employee.Age);
            conn.Open();
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            return false;
        }
        public bool UpdateEmployeeDetail(Employee employee)
        {
            SqlCommand cmd = new SqlCommand("proc_UpdateEmployeeDetail", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@emp_id", employee.Id);
            cmd.Parameters.AddWithValue("@emp_name", employee.Name);
            cmd.Parameters.AddWithValue("@emp_age", employee.Age);
            conn.Open();
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            return false;
        }

        public bool DeleteEmployeeDetail(int id)
        {
            SqlCommand cmd = new SqlCommand("proc_DeleteEmployeeById", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@emp_id", id);
            conn.Open();
            if (cmd.ExecuteNonQuery() > 0)
                return true;
            return false;
        }
    }
}
