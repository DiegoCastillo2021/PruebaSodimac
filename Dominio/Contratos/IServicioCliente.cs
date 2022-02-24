using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Contratos
{
    public interface IServicioCliente
    {
        Task<string> RegistroUsuario(object usuario);
        Task<string> ActualizarUsuario(object usuario);
        Task<string> EliminarUsuario(object usuario);
        Task<object> ConsultarUsuario(object usuario);
    }
}
