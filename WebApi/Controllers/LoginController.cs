using BusinessEntity;
using BusinessService1.impl;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        IUsuarioService _usuarioService;
        IEmpleadoService _empleadoService; 
        public LoginController(IUsuarioService usuarioService, IEmpleadoService empleadoService)
        {
            _usuarioService = usuarioService;
            _empleadoService = empleadoService;
        }

        [Route("Login")]
        [HttpPost]
        public HttpResponseMessage Login([FromBody] UsuarioEntity user)
        {
            var usuario = _usuarioService.Validar(user);
            if (user is null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Invalid client request");
            }
            if (usuario != null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Ur-565656565656565656"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:5001",
                    audience: "https://localhost:5001",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Request.CreateResponse(new AuthenticatedResponse{ Token = tokenString, Rol = usuario.ROL});
            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);
        }
        [Route("Logout")]
        [HttpPost]
        public HttpResponseMessage Logout([FromBody] ClientesEntity nuevo)
        {
            return Request.CreateResponse(HttpStatusCode.Unauthorized);
        }
        private class AuthenticatedResponse
        {
           public string Token { get; set; }
           public int Rol { get; set; }
        }
    }
}