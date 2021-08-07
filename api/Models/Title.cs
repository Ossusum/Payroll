using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication8.api.Model
{
    public enum Title
    {
        [Description("Software Engineer")]
        SoftwareEngineer = 0,

        [Description("Human Resources")]
        HumanResources = 1,

        [Description("Operations")]
        Operations = 2,

        [Description("Administrator")]
        Administrator = 3
    }
}