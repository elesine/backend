using back_end.Entidades;

namespace back_end.repositorios
{
    public interface IRepositorio
    {
        List<Genero> ObternerTodosLosGeneros();
        Task<Genero> ObtenerPorId(int Id);
        //Guid ObtenerGUID();
        void CrearGenero(Genero genero);
    }
}
