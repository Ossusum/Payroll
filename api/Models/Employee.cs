using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication8.api.Model
{
    public class Employee: Person
    {
        public Title Title { get; set; }
        public decimal Wage { get; set; }
        public DateTime HireDate { get; set; }
        public IList<Dependent> Dependents { get; set; }

    }
}