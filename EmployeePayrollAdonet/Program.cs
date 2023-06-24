using System;

namespace EmployeePayrollAdonet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Employee payroll Connectivity Database with .Net applications using Ado.Net!");

            PayrollServices obj = new PayrollServices();
            // obj.CreateDataBase();
            obj.CreateTable();
        }
    }
}