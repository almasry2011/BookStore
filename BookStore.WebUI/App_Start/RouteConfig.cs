using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            //localhost:xxxx/Programming
            //routes.MapRoute(
            //           null, "scart/{returnURL}/{cart}", new
            //           {
            //               controller = "cart",
            //               action = "index",
            //               cart = Equals("cart", "scart0")

            //           });

            //localhost:xxxx/Programming
            routes.MapRoute(
                       null, "{specialization}", new
                       {
                           controller = "book",
                           action = "list",
                       });



            //localhost:xxxx
            routes.MapRoute(
                       null, "", new
                       {
                           controller = "book",
                           action = "ListAll",
                       });

            //localhost:xxxx/3
            routes.MapRoute(
                     null, "{page}",

                     new
                     {
                         controller = "book",
                         action = "ListAll",
                         page = UrlParameter.Optional
                     },
                        new { page = @"\d+" }         // The regular expression \d + matches one or more integers.
                      );
 
      

            //localhost:xxxx/Programming/2
            routes.MapRoute(
                    null, "{specialization}/{page}", new
                    {
                        controller = "book",
                        action = "list",
                        page = UrlParameter.Optional
                    }, 
                    new { page = @"\d+" }
                    );

                       
                       
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "book", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
