using System;

namespace EmployeePayrollAdonet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Employee payroll Connectivity Database with .Net applications using Ado.Net!");

            PayrollServices obj = new PayrollServices();
            // obj.CreateDataBase();   UC1
            // obj.CreateTable();      UC2
            // obj.InsertData();       UC3
            // obj.RetrieveData();      UC4


            //UC5 part-01:- Salary for particular employee
            // obj.RetrieveSalaryData("Karan");


            //UC5 Part-02:- Retrieve employees who have joined within a particular date range
            // DateTime startDate = new DateTime(2018, 1, 1);
            // DateTime endDate = DateTime.Now;
            // obj.RetrieveEmployeesByDateRange(startDate, endDate);



            // UC6 :- Add Geneder and update table row
            //obj.AddGenderToEmployeePayrollTable();

            // Update the gender of employees
            //obj.UpdateEmployeeGender("karan", "M");
            //obj.UpdateEmployeeGender("krishna", "M");



            // UC7:- PERFORM AGGREGATE FUNCTION ON TABLE DATA 
            obj.AggregateAndGenderAnalysis();


        }
    }
}