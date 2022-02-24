using Datos.Contratos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorio
{
    public class RepositorioCliente : IRepositorioCliente
    {
        CAR_CENTERE_entities context = new CAR_CENTERE_entities();

        public async Task<string> RegistrarUsuario(object cliente)
        {
            try
            {
                CLN_CLIENTE DtoCliente = JsonConvert.DeserializeObject<CLN_CLIENTE>(JsonConvert.SerializeObject(cliente));

                DtoCliente.CLN_ESTADO = 5;

                context.CLN_CLIENTE.Add(DtoCliente);
                context.SaveChanges();

                return await Task.FromResult("Exitoso");
            }
            catch (DbEntityValidationException ex)
            {

                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }

                return await Task.FromResult("No Exitoso");
            }
        }

        public async Task<string> ActualizarUsuario(object cliente)
        {
            try
            {
                CLN_CLIENTE DtoCliente = JsonConvert.DeserializeObject<CLN_CLIENTE>(JsonConvert.SerializeObject(cliente));

                using (context = new CAR_CENTERE_entities())
                {
                    var DtoCliente_actualizar = context.CLN_CLIENTE.Find(DtoCliente.CLN_NUMERO_DOCUMENTO);

                    DtoCliente_actualizar.CLN_CELULAR = DtoCliente.CLN_CELULAR;
                    DtoCliente_actualizar.CLN_DIRECCION = DtoCliente.CLN_DIRECCION;
                    DtoCliente_actualizar.CLN_EMAIL = DtoCliente.CLN_EMAIL;
                    DtoCliente_actualizar.CLN_ESTADO = DtoCliente.CLN_ESTADO;

                    context.Configuration.ValidateOnSaveEnabled = false;
                    context.SaveChanges();
                }

                return await Task.FromResult("Exitoso");
            }
            catch (DbEntityValidationException ex)
            {

                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }

                return await Task.FromResult("No Exitoso");
            }
        }

        public async Task<string> EliminarUsuario(object cliente)
        {
            try
            {
                CLN_CLIENTE DtoCliente = JsonConvert.DeserializeObject<CLN_CLIENTE>(JsonConvert.SerializeObject(cliente));

                using (context = new CAR_CENTERE_entities())
                {
                    var DtoCliente_eliminar = context.CLN_CLIENTE.Find(DtoCliente.CLN_NUMERO_DOCUMENTO);

                    context.CLN_CLIENTE.Remove(DtoCliente_eliminar);
                    context.SaveChanges();
                }

                return await Task.FromResult("Exitoso");
            }
            catch (DbEntityValidationException ex)
            {

                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }

                return await Task.FromResult("No Exitoso");
            }
        }

        public async Task<object> ConsultarUsuario(object cliente)
        {
            try
            {
                var result = "";

                CLN_CLIENTE DtoCliente = JsonConvert.DeserializeObject<CLN_CLIENTE>(JsonConvert.SerializeObject(cliente));

                using (context = new CAR_CENTERE_entities())
                {
                    var result_cliente = (from a in context.CLN_CLIENTE
                                          where a.CLN_NUMERO_DOCUMENTO == DtoCliente.CLN_NUMERO_DOCUMENTO
                                          select new { tipo_documento = a.CLN_TIPO_DOCUMENTO, numero_documento = a.CLN_NUMERO_DOCUMENTO, nombre = a.CLN_PRIMER_NOMBRE + " " + a.CLN_SEGUNDO_NOMBRE + " " + a.CLN_PRIMER_APELLIDO + " " + a.CLN_SEGUNDO_APELLIDO, celular = a.CLN_CELULAR, direccion = a.CLN_DIRECCION, email = a.CLN_EMAIL }).FirstOrDefault();

                    result = JsonConvert.SerializeObject(result_cliente);
                }

                return await Task.FromResult(result);
            }
            catch (DbEntityValidationException ex)
            {

                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }

                return await Task.FromResult("No Exitoso");
            }
        }
    }
}
