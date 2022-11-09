using Proyect_Crud.DAL.Repositories;
using Proyect_Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_Crud.BLL.Services
{
    public class ContactServices : IContacServices
    {
        private readonly IGenericRepository<Contacto> GenericRepository;

        public ContactServices(IGenericRepository<Contacto> genericRepository)
        {
            GenericRepository = genericRepository;
        }

       
        public async Task<bool> Actualizar(Contacto contacto)
        {
            try
            {
                return await GenericRepository.Actualizar(contacto);
                
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                return await GenericRepository.Eliminar(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Insertar(Contacto contacto)
        {
            try
            {
                return await GenericRepository.Insertar(contacto);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Contacto> Obtener(int id)
        {
            try
            {
                return await GenericRepository.Obtener(id);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<Contacto> ObtenerPorNombre(string Nombre)
        {
            try
            {
                 IQueryable<Contacto> queryCaontactSql = await GenericRepository.ObtenerTodos();
                 Contacto modelo = queryCaontactSql.Where(z => z.Nombre == Nombre).FirstOrDefault();
                 return modelo;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public async Task<IQueryable<Contacto>> ObtenerTodos()
        {
            try
            {
                return await GenericRepository.ObtenerTodos();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
