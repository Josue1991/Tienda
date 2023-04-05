using BusinessService1;
using BusinessService1.impl;
using Repository;
using Swashbuckle.Application;
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
            container.RegisterType<IEmpleadoService, EmpleadoService>();
            container.RegisterType<IFacturaService, FacturaService>();
            container.RegisterType<IFormaPagoService, FormaPagoService>();
            container.RegisterType<IProductoService, ProductoService>();
            container.RegisterType<IServiciosService, ServiciosService>();
            container.RegisterType<IUnidadService, UnidadService>();
            container.RegisterType<IUsuarioService, UsuarioService>();


            config.DependencyResolver = new UnityResolver(container);

            // Configuración y servicios de Web API

            // Rutas de Web API
            config.MapHttpAttributeRoutes();
             
          
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var thisAssembly = typeof(SwaggerConfig).Assembly;



            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
        }
    }
}
