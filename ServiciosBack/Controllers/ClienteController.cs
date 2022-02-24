using Dominio;
using Dominio.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ServiciosBack.Controllers
{
    [RoutePrefix("api/usuario")]
    public class ClienteController : ApiController
    {
        private IServicioCliente obj_usuario = new ServicioCliente();

        [Route("registro")]
        [HttpPost]
        public async Task<IHttpActionResult> RegistrarUsuario([FromBody] object cliente)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var result = await obj_usuario.RegistroUsuario(cliente);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("actualizar")]
        [HttpPost]
        public async Task<IHttpActionResult> ActualizarUsuario([FromBody] object cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var result = await obj_usuario.ActualizarUsuario(cliente);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("eliminar")]
        [HttpPost]
        public async Task<IHttpActionResult> EliminarUsuario([FromBody] object cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var result = await obj_usuario.EliminarUsuario(cliente);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("consultar")]
        [HttpPost]
        public async Task<IHttpActionResult> ConsultarUsuario([FromBody] object cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var result = await obj_usuario.ConsultarUsuario(cliente);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
