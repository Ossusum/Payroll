using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using WebApplication8.api.Butlers;
using WebApplication8.api.Butlers.Interfaces;
using WebApplication8.api.Repositories;
using WebApplication8.api.Repositories.Interfaces;

namespace WebApplication8.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<ICompanyRepository, CompanyRepository>();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            container.RegisterType<IDependentRepository, DependentRepository>();

            container.RegisterType<IEmployeeButler, EmployeeButler>();
            container.RegisterType<ICompanyButler, CompanyButler>();

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}