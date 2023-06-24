﻿using System;
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

        public void CreateTable()
        {
            try {
                SqlConnection con = new SqlConnection(@"data source=DESKTOP-HDRGJGO\SQLEXPRESS; initial catalog=Payroll_Service; integrated security=true;");
                con.Open();

                string query = "create table employeePayroll(" +
                    "Columns_Id int identity(1,1) Primary key," +
                    "Name varchar(20)," +
                    "Salary varchar(10)," +
                    "StartDate date," +
                    "Gender varchar(200)," +
                    "Phone int,"+
                    "Address varchar (200),"+
                    "Department varchar(200),"+
                    "Deduction int,"+
                    "Taxable_Pay int,"+
                    "Income_Tax int,"+
                    "Net_Pay int,"+
                    ")";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table Created Sussessfully...");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

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



    }
}
