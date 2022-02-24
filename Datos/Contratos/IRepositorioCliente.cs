using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Contratos
{
    public interface IRepositorioCliente
    {
        Task<string> RegistrarUsuario(object usuario);
        Task<string> ActualizarUsuario(object usuario);
        Task<string> EliminarUsuario(object usuario);
        Task<object> ConsultarUsuario(object usuario);
    }
}
