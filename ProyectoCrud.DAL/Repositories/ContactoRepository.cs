using ProyectoCrud.DAL.DataContext;
using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.DAL.Repositories
{
    public class ContactoRepository : IGenericRepository<Contacto>
    {
        private readonly DBPRUEBASContext _dbcontext;

        public ContactoRepository(DBPRUEBASContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<bool> Actualizar(Contacto entity)
        {
            _dbcontext.Contactos.Update(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Contacto contacto = _dbcontext.Contactos.First(c => c.IdContacto == id);
            _dbcontext.Contactos.Remove(contacto);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Contacto entity)
        {
            _dbcontext.Contactos.Add(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<Contacto> Obtener(int id)
        {
            return await _dbcontext.Contactos.FindAsync(id);
        }

        public async Task<IQueryable<Contacto>> ObtenerTodo()
        {
            IQueryable<Contacto> queryContactoSQL = _dbcontext.Contactos;
            return  queryContactoSQL;
        }
    }
}
