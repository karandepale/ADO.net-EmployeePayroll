using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollAdonet
{
    public class PayrollServices
    {
        public  void CreateDataBase()
        {
            try {
                SqlConnection con = new SqlConnection("data source=DESKTOP-HDRGJGO\\SQLEXPRESS; initial catalog=master; integrated security=true;");
                con.Open();

                string query = "create database Payroll_Service;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data Base Created Sussfully...");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
