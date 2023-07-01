using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollAdonet
{
    internal class PayrollModal
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public DateTime StartDate { get; set; }
        public string Gender { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public int Deduction { get; set; }
        public int Taxable_Pay { get; set; }
        public int Income_Tax { get; set; }
        public int Net_Pay { get; set; }

        public List<DepartmentModal> Departments { get; set; }
    }
    internal class DepartmentModal
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}