using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using EmployeesMvc.Model;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework.Config;

namespace EmployeesMvc
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            IDictionary<string, string> properties = new Dictionary<string, string>();

            properties.Add("connection.driver_class", "NHibernate.Driver.SQLite20Driver, NHibernate");
            properties.Add("dialect", "NHibernate.Dialect.SQLiteDialect");
            properties.Add("connection.provider", "NHibernate.Connection.DriverConnectionProvider");
            properties.Add("connection.connection_string", "Data Source=c:\\sqlite\\employees.db");
            properties.Add("proxyfactory.factory_class", "NHibernate.ByteCode.Castle.ProxyFactoryFactory, NHibernate.ByteCode.Castle");

            InPlaceConfigurationSource source = new InPlaceConfigurationSource();

            source.Add(typeof(ActiveRecordBase), properties);

            ActiveRecordStarter.Initialize(source, typeof(JobTitle), typeof(Employee));

            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }
    }
}