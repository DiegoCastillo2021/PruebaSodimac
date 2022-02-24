using Datos.Contratos;
using Datos.Repositorio;
using Dominio.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ServicioCliente : IServicioCliente
    {
        IRepositorioCliente repoUsuario = new RepositorioCliente();
        public async Task<string> RegistroUsuario(object usuario)
        {
            var result = await repoUsuario.RegistrarUsuario(usuario);

            return await Task.FromResult(result);
        }

        public async Task<string> ActualizarUsuario(object usuario)
        {
            var result = await repoUsuario.ActualizarUsuario(usuario);

            return await Task.FromResult(result);
        }

        public async Task<string> EliminarUsuario(object usuario)
        {
            var result = await repoUsuario.EliminarUsuario(usuario);

            return await Task.FromResult(result);
        }

        public async Task<object> ConsultarUsuario(object usuario)
        {
            var result = await repoUsuario.ConsultarUsuario(usuario);

            return await Task.FromResult(result);
        }
    }
}
