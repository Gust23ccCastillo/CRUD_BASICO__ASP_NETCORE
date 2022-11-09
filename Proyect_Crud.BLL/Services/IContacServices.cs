using Proyect_Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_Crud.BLL.Services
{
    public interface IContacServices
    {
        Task<bool> Insertar(Contacto contacto);
        Task<bool> Actualizar(Contacto contacto);
        Task<bool> Eliminar(int id);
        Task<Contacto> Obtener(int id);
        Task<IQueryable<Contacto>> ObtenerTodos();

        Task<Contacto> ObtenerPorNombre(string Nombre);
    }
}
