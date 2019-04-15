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


            routes.MapRoute(
                     null, "{page}", new
                     {
                         controller = "book",
                         action = "ListAll",
                         page = UrlParameter.Optional
                     }
                      );



            routes.MapRoute(
           name: "Paging",
           url: "BookListPage/{page}",
           defaults: new { controller = "book", action = "list", page = UrlParameter.Optional }
       );




            routes.MapRoute(
                       null, "{specialization}", new
                       {
                           controller = "book",
                           action = "list",
                           page = UrlParameter.Optional
                       }
                       );

            routes.MapRoute(
                    null, "{specialization}/{page}", new
                    {
                       controller = "book",
                       action = "list",
                       page = UrlParameter.Optional
                    }
                    );



            routes.MapRoute(
                       null,"" , new { controller = "book",
                           action = "listall",
                           specialization =(string)null,
                            page = UrlParameter.Optional }
                        );


   

            


          





         


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "book", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
