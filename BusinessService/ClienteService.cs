using BusinessEntity;
using BusinessService1.impl;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService1
{
    public class ClienteService : IClienteService
    {
        base1Entities _repositorio;        
        public ClienteService()
        {
            _repositorio = new base1Entities();
        }

        public List<ClientesEntity> ListaCliente()
        {
            List<ClientesEntity> retorno = new List<ClientesEntity>();
            var lista = _repositorio.CLIENTE.ToList();
            
            lista.ForEach(x =>
            {
                var estados = _repositorio.ESTADO.Where(e => e.ID_ESTADO == x.ESTADO_CLIENTE).FirstOrDefault();
                var item = new ClientesEntity();
                item.ID_CLIENTE = x.ID_CLIENTE;
                item.CEDULA = x.CEDULA;
                item.NOMBRE = x.NOMBRE;
                item.APELLIDO = x.APELLIDO;
                item.DIRECCION = x.DIRECCION;
                item.TELEFONO = x.TELEFONO;
                item.EMAIL = x.EMAIL;
                item.ID_FORMAPAGO = x.ID_FORMAPAGO;
                item.ESTADO_CLIENTE = x.ESTADO_CLIENTE.Value;
                retorno.Add(item);
            });
            return retorno;
        }
        public ClientesEntity obtenerCliente(string cedula, int estado)
        {
            ClientesEntity retorno = new ClientesEntity();
            var elemento = _repositorio.CLIENTE.Where(x => x.CEDULA == cedula).FirstOrDefault();
            var estados = _repositorio.ESTADO.Where(x=> x.ID_ESTADO == estado).FirstOrDefault();
            var estadoCli = new EstadoEntity();
            estadoCli.ID_ESTADO = estados.ID_ESTADO;
            estadoCli.DESCRIPCION_ESTADO = estados.DESCRIPCION_ESTADO;

            if (elemento != null)
            {
                var item = new ClientesEntity();
                item.ID_CLIENTE = elemento.ID_CLIENTE;
                item.CEDULA = elemento.CEDULA;
                item.NOMBRE = elemento.NOMBRE;
                item.APELLIDO = elemento.APELLIDO;
                item.DIRECCION = elemento.DIRECCION;
                item.ESTADO_CLIENTE = estados.ID_ESTADO;
                item.TELEFONO = elemento.TELEFONO;
                item.EMAIL = elemento.EMAIL;
                item.ID_FORMAPAGO = elemento.ID_FORMAPAGO;
                item.ESTADO_CLIENTE = estados.ID_ESTADO;
                retorno = item;
            }
            return retorno;
        }
        public bool ingresarCliente(ClientesEntity cliente)
        {
            var retorno = false;
            var elemento = _repositorio.CLIENTE.Where(x => x.CEDULA == cliente.CEDULA).FirstOrDefault();
            try
            {
                if (elemento == null)
                {
                    using (var context = new base1Entities())
                    {
                        var item = new CLIENTE();
                        item.CEDULA = cliente.CEDULA;
                        item.NOMBRE = cliente.NOMBRE;
                        item.EMAIL = cliente.EMAIL;
                        item.APELLIDO = cliente.APELLIDO;
                        item.DIRECCION = cliente.DIRECCION;
                        item.TELEFONO = cliente.TELEFONO;
                        item.ID_FORMAPAGO = cliente.ID_FORMAPAGO;
                        item.ESTADO_CLIENTE = cliente.ESTADO_CLIENTE;
                        context.CLIENTE.Add(item);
                        context.SaveChanges();
                        retorno = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo ingresar el elemento!",ex);
            }
            return retorno;
        }
        public bool editarCliente(ClientesEntity cliente)
        {
            var retorno = false;
            var elemento = _repositorio.CLIENTE.Where(x=> x.CEDULA == cliente.CEDULA).FirstOrDefault();  
            try
            {
                if (elemento != null)
                {
                    using (var context = new base1Entities())
                    {
                        context.Entry(elemento).CurrentValues.SetValues(cliente);
                        context.SaveChanges();
                        retorno = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo modificar el elemento!", ex);
            }

            return retorno;
        }
        public bool eliminarCliente(ClientesEntity cliente)
        {
            var retorno = false;
            var elemento = _repositorio.CLIENTE.Where(x => x.CEDULA == cliente.CEDULA).FirstOrDefault();
            try
            {
                if (elemento != null)
                {
                    using (var context = new base1Entities())
                    {
                        cliente.ESTADO_CLIENTE = 2;
                        context.Entry(elemento).CurrentValues.SetValues(cliente);
                        context.SaveChanges();
                        retorno = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo modificar el elemento!", ex);
            }

            return retorno;
        }
    }
}
