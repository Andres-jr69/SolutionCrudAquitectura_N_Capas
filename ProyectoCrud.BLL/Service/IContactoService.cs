using ProyectoCrud.Models;

namespace ProyectoCrud.BLL.Service
{
    public interface IContactoService
    {
        Task<bool> Insertar(Contacto entity);
        Task<bool> Actualizar(Contacto entity);
        Task<bool> Eliminar(int id);
        Task<Contacto> Obtener(int id);
        Task<IQueryable<Contacto>> ObtenerTodo();

        Task<Contacto> ObtenerNombre(string nombreContacto);

    }
}
