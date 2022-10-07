using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmanTask.Core.Model
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }


        public int DepartmentId { get; set; }
        public Department Departments{ get; set; }
    }
}
