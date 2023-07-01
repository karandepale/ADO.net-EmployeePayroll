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

        // ------------ UC1:- Create DataBase --------------
        public void CreateDataBase()
        {
            try
            {
                SqlConnection con = new SqlConnection("data source=DESKTOP-HDRGJGO\\SQLEXPRESS; initial catalog=master; integrated security=true;");
                con.Open();

                string query = "create database Payroll_Service;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data Base Created Sussfully...");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }


        //------- UC2:- CREATE  DATABASE  TABLE------------------
        public void CreateTable()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-HDRGJGO\SQLEXPRESS; initial catalog=Payroll_Service; integrated security=true;");
                con.Open();

                string query = "create table employeePayroll(" +
                    "Columns_Id int identity(1,1) Primary key," +
                    "Name varchar(20)," +
                    "Salary varchar(10)," +
                    "StartDate date," +
                    "Gender varchar(200)," +
                    "Phone int," +
                    "Address varchar (200)," +
                    "Department varchar(200)," +
                    "Deduction int," +
                    "Taxable_Pay int," +
                    "Income_Tax int," +
                    "Net_Pay int," +
                    ")";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table Created Sussessfully...");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }


        //-------- UC3:- INSERTING RECORDS INTO TABLE ------------------
        public void InsertData()
        {
            try
            {
                PayrollModal model = new PayrollModal();

                Console.WriteLine("Enter Name:");
                model.Name = Console.ReadLine();

                Console.WriteLine("Enter Salary:");
                model.Salary = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter StartDate (yyyy-MM-dd):");
                model.StartDate = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Enter Gender:");
                model.Gender = Console.ReadLine();

                Console.WriteLine("Enter Phone:");
                model.Phone = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Address:");
                model.Address = Console.ReadLine();

                Console.WriteLine("Enter Department:");
                model.Department = Console.ReadLine();

                Console.WriteLine("Enter Deduction:");
                model.Deduction = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Taxable Pay:");
                model.Taxable_Pay = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Income Tax:");
                model.Income_Tax = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Net Pay:");
                model.Net_Pay = Convert.ToInt32(Console.ReadLine());

                SqlConnection con = new SqlConnection(@"data source=DESKTOP-HDRGJGO\SQLEXPRESS; initial catalog=Payroll_Service; integrated security=true;");
                con.Open();

                string query = "INSERT INTO employeePayroll (Name, Salary, StartDate, Gender, Phone, Address, Department, Deduction, Taxable_Pay, Income_Tax, Net_Pay) " +
                               "VALUES (@Name, @Salary, @StartDate, @Gender, @Phone, @Address, @Department, @Deduction, @TaxablePay, @IncomeTax, @NetPay)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Name", model.Name);
                cmd.Parameters.AddWithValue("@Salary", model.Salary);
                cmd.Parameters.AddWithValue("@StartDate", model.StartDate);
                cmd.Parameters.AddWithValue("@Gender", model.Gender);
                cmd.Parameters.AddWithValue("@Phone", model.Phone);
                cmd.Parameters.AddWithValue("@Address", model.Address);
                cmd.Parameters.AddWithValue("@Department", model.Department);
                cmd.Parameters.AddWithValue("@Deduction", model.Deduction);
                cmd.Parameters.AddWithValue("@TaxablePay", model.Taxable_Pay);
                cmd.Parameters.AddWithValue("@IncomeTax", model.Income_Tax);
                cmd.Parameters.AddWithValue("@NetPay", model.Net_Pay);

                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} row(s) inserted.");
                Console.WriteLine("Inserted data sussfully...");

                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }



        //---------- UC4:- RETRIVING ALL THE RECORDS FROM TABLE-----------------
        public void RetrieveData()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-HDRGJGO\SQLEXPRESS; initial catalog=Payroll_Service; integrated security=true;");
                con.Open();

                string query = "SELECT * FROM employeePayroll";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine("Records from employeePayroll table:");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Columns_Id\tName\tSalary\tStartDate\tGender\tPhone\tAddress\tDepartment\tDeduction\tTaxable_Pay\tIncome_Tax\tNet_Pay");
                    Console.WriteLine("-------------------------------------------------------------");

                    while (reader.Read())
                    {
                        int columnsId = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string salary = reader.GetString(2);
                        DateTime startDate = reader.GetDateTime(3);
                        string gender = reader.GetString(4);
                        int phone = reader.GetInt32(5);
                        string address = reader.GetString(6);
                        string department = reader.GetString(7);
                        int deduction = reader.GetInt32(8);
                        int taxablePay = reader.GetInt32(9);
                        int incomeTax = reader.GetInt32(10);
                        int netPay = reader.GetInt32(11);

                        Console.WriteLine($"{columnsId}\t\t{name}\t{salary}\t{startDate.ToShortDateString()}\t{gender}\t{phone}\t{address}\t{department}\t{deduction}\t{taxablePay}\t{incomeTax}\t{netPay}");
                    }
                }
                else
                {
                    Console.WriteLine("No records found in the employeePayroll table.");
                }

                reader.Close();
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }




        //---- UC5(PART:-01) RETRIVING ONLY SALARY FOR PARTICULAR EMPLOYEE BY NAME---------
        public void RetrieveSalaryData(string employeeName)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-HDRGJGO\SQLEXPRESS; initial catalog=Payroll_Service; integrated security=true;");
                con.Open();

                string query = $"SELECT Salary FROM employeePayroll WHERE Name = '{employeeName}'";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine($"Salary data for employee '{employeeName}':");
                    Console.WriteLine("----------------------");

                    while (reader.Read())
                    {
                        string salary = reader.GetString(0);
                        Console.WriteLine($"Salary: {salary}");
                    }
                }
                else
                {
                    Console.WriteLine($"No salary data found for employee '{employeeName}'.");
                }

                reader.Close();
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        // ------ UC5(PART:-02) RETRIVING RECORDS FROM GIVEN DATE RANGE ------------
        public void RetrieveEmployeesByDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-HDRGJGO\SQLEXPRESS; initial catalog=Payroll_Service; integrated security=true;");
                con.Open();

                string query = $"SELECT * FROM employeePayroll WHERE StartDate BETWEEN '{startDate.ToString("yyyy-MM-dd")}' AND '{endDate.ToString("yyyy-MM-dd")}'";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine($"Employees who have joined between {startDate.ToShortDateString()} and {endDate.ToShortDateString()}:");
                    Console.WriteLine("-------------------------------------------------------------");
                    Console.WriteLine("Columns_Id\tName\tSalary\tStartDate\tGender\tPhone\tAddress\tDepartment\tDeduction\tTaxable_Pay\tIncome_Tax\tNet_Pay");
                    Console.WriteLine("-------------------------------------------------------------");

                    while (reader.Read())
                    {
                        int columnsId = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string salary = reader.GetString(2);
                        DateTime empStartDate = reader.GetDateTime(3);
                        string gender = reader.GetString(4);
                        int phone = reader.GetInt32(5);
                        string address = reader.GetString(6);
                        string department = reader.GetString(7);
                        int deduction = reader.GetInt32(8);
                        int taxablePay = reader.GetInt32(9);
                        int incomeTax = reader.GetInt32(10);
                        int netPay = reader.GetInt32(11);

                        Console.WriteLine($"{columnsId}\t\t{name}\t{salary}\t{empStartDate.ToShortDateString()}\t{gender}\t{phone}\t{address}\t{department}\t{deduction}\t{taxablePay}\t{incomeTax}\t{netPay}");
                    }
                }
                else
                {
                    Console.WriteLine("No employees found within the specified date range.");
                }

                reader.Close();
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        // ---------- UC6(PART:-01):- ADDING GENDER COLUMN  ---------
        public void AddGenderToEmployeePayrollTable()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-HDRGJGO\SQLEXPRESS; initial catalog=Payroll_Service; integrated security=true;");
                con.Open();

                string query = "ALTER TABLE employeePayroll ADD Gender varchar(10)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                Console.WriteLine("Gender field added to the employeePayroll table.");

                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        //------------ UC6(PART:-02):- UPDATE RECORDS ---------------
        public void UpdateEmployeeGender(string employeeName, string gender)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-HDRGJGO\SQLEXPRESS; initial catalog=Payroll_Service; integrated security=true;");
                con.Open();

                string query = $"UPDATE employeePayroll SET Gender = '{gender}' WHERE Name = '{employeeName}'";

                SqlCommand cmd = new SqlCommand(query, con);
                int rowsAffected = cmd.ExecuteNonQuery();

                Console.WriteLine($"{rowsAffected} row(s) updated.");

                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }



        // UC7:- PERFORM  AGGREGATE FUNCTIONS:-
        public void AggregateAndGenderAnalysis()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-HDRGJGO\SQLEXPRESS; initial catalog=Payroll_Service; integrated security=true;");
                con.Open();

                string query = "SELECT Gender, SUM(CAST(Salary AS decimal)) AS TotalSalary, AVG(CAST(Salary AS decimal)) AS AverageSalary, " +
                               "MIN(CAST(Salary AS decimal)) AS MinSalary, MAX(CAST(Salary AS decimal)) AS MaxSalary, COUNT(*) AS EmployeeCount " +
                               "FROM employeePayroll " +
                               "GROUP BY Gender";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine("Gender\tTotal Salary\tAverage Salary\tMinimum Salary\tMaximum Salary\tEmployee Count");
                    Console.WriteLine("-------------------------------------------------------------------------------");

                    while (reader.Read())
                    {
                        string gender = reader.GetString(0);
                        decimal totalSalary = reader.GetDecimal(1);
                        decimal averageSalary = reader.GetDecimal(2);
                        decimal minSalary = reader.GetDecimal(3);
                        decimal maxSalary = reader.GetDecimal(4);
                        int employeeCount = reader.GetInt32(5);

                        Console.WriteLine($"{gender}\t{totalSalary}\t{averageSalary}\t{minSalary}\t{maxSalary}\t{employeeCount}");
                    }
                }
                else
                {
                    Console.WriteLine("No gender analysis data found.");
                }

                reader.Close();
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public void RetrieveDepartmentsForEmployee(int employeeId)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-HDRGJGO\SQLEXPRESS; initial catalog=Payroll_Service; integrated security=true;");
                con.Open();

                string query = $"SELECT d.ID, d.Name FROM Department d " +
                               $"INNER JOIN EmployeeDepartment ed ON d.ID = ed.DepartmentID " +
                               $"WHERE ed.EmployeeID = {employeeId}";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine($"Departments for Employee ID {employeeId}:");
                    Console.WriteLine("Department ID\tDepartment Name");
                    Console.WriteLine("---------------------------------");

                    while (reader.Read())
                    {
                        int departmentId = reader.GetInt32(0);
                        string departmentName = reader.GetString(1);

                        Console.WriteLine($"{departmentId}\t\t{departmentName}");
                    }
                }
                else
                {
                    Console.WriteLine($"No departments found for Employee ID {employeeId}.");
                }

                reader.Close();
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }







        // UC8:- EXTEND TABLE (ADDING EXTRA COLUMNS INTO TABLE)
        public void ExtendEmployeePayrollTable()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-HDRGJGO\SQLEXPRESS; initial catalog=Payroll_Service; integrated security=true;");
                con.Open();

                // Add new columns to the employeePayroll table
                string query = @"ALTER TABLE employeePayroll
                        ADD Basic_Pay DECIMAL(18, 2),
                            Deductions DECIMAL(18, 2),
                            Taxable_Pay DECIMAL(18, 2),
                            Income_Tax DECIMAL(18, 2),
                            Net_Pay DECIMAL(18, 2)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Extended employeePayroll table successfully.");

                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }







    }
}