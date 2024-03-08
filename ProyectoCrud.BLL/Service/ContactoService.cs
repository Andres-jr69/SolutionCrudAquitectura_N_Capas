using ProyectoCrud.DAL.Repositories;
using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.BLL.Service
{
    public class ContactoService : IContactoService
    {
        private readonly IGenericRepository<Contacto> _contactRepo;

        public ContactoService(IGenericRepository<Contacto> contactRepo)
        {
            _contactRepo = contactRepo;
        }

        public async Task<bool> Actualizar(Contacto entity)
        {
            return await _contactRepo.Actualizar(entity);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _contactRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(Contacto entity)
        {
            return await _contactRepo.Insertar(entity);
        }

        public async Task<Contacto> Obtener(int id)
        {
            return await _contactRepo.Obtener(id);
        }

        public async Task<Contacto> ObtenerNombre(string nombreContacto)
        {
            IQueryable<Contacto> querycontactosSQL = await _contactRepo.ObtenerTodo();
            Contacto contacto = querycontactosSQL.Where(c => c.Nombre == nombreContacto).FirstOrDefault();
            return contacto;
        }

        public async Task<IQueryable<Contacto>> ObtenerTodo()
        {
            return await _contactRepo.ObtenerTodo();
        }
    }
}
