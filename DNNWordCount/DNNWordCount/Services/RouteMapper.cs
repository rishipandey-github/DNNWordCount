using DotNetNuke.Web.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;

namespace DNN.ModuleDNNWordCount.Services
{
    public class RouteMapper: IServiceRouteMapper
    {        
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute(
            "DNNWordCount",
            "default",
            "{controller}/{action}",
            new string[] { "DNN.ModuleDNNWordCount.Services" });            
        }
    }
}
