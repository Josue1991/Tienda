using BusinessService1;
using BusinessService1.impl;
using Repository;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity;
namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IClienteService, ClienteService>();
            container.RegisterType<IDetalleFacturaService, DetalleFacturaService>();
            container.RegisterType<IEstadoService, EstadoService>();
            container.RegisterType<IFacturaService, FacturaService>();
            container.RegisterType<IFormaPagoService, FormaPagoService>();
            container.RegisterType<IProductoService, ProductoService>();

           
            config.DependencyResolver = new UnityResolver(container);

            // Configuración y servicios de Web API

            // Rutas de Web API
            config.MapHttpAttributeRoutes();
             
          
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
        }
    }
}
