using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BootstrapMvcSample.Controllers;
using NavigationRoutes;
using NIBMProject.Controllers;

namespace BootstrapMvcSample
{
    public class ExampleLayoutsRouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapNavigationRoute<HomeController>("Home", c => c.Index());

            routes.MapNavigationRoute<RegisterController>("Registration", c => c.Index());
                  //.AddChildRoute<ExampleLayoutsController>("Marketing", c => c.Marketing())
            routes.MapNavigationRoute<PatientController>("AddPatient", c => c.Index());
            routes.MapNavigationRoute<LogInController>("Login", c => c.Index());
            routes.MapNavigationRoute<PatientController>("MapView", c => c.MapView());
            routes.MapNavigationRoute<LogInController>("Logout", c => c.Logout());
        }
    }
}
