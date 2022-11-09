using Proyect_Crud.DAL.DataContext;
using Proyect_Crud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect_Crud.DAL.Repositories
{
    public class ContacRepository : IGenericRepository<Contacto>
    {
        private readonly CRUD_ASPNET_CORE_BASICOContext _DbContext;
       
        public ContacRepository(CRUD_ASPNET_CORE_BASICOContext dbContext)
        {
            _DbContext = dbContext;
        }

        public  async Task<bool> Actualizar(Contacto model)
        {
            try
            {
                if (model != null)
                {
                    _DbContext.Contactos.Update(model);
                    await _DbContext.SaveChangesAsync();
                    return true;
                    
                }
                else return false;


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
                if (id != 0)
                {
                    Contacto model = _DbContext.Contactos.First(c=>c.IdContacto == id);
                    if (model != null)
                    {
                        _DbContext.Contactos.Remove(model);
                        await _DbContext.SaveChangesAsync();
                        return true;
                    }
                    else return false;

                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Insertar(Contacto model)
        {
            try
            {
                if (model != null)
                {
                    await _DbContext.Contactos.AddAsync(model);
                    await _DbContext.SaveChangesAsync();
                    return true;
                }
                else return false;
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
                if (id != 0)
                {
                    return await _DbContext.Contactos.FindAsync(id);
                }
                return null;
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
                IQueryable<Contacto> queryContactSql = _DbContext.Contactos;
                if (queryContactSql!=null)
                {
                    return queryContactSql;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
