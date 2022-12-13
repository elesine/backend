using back_end.Entidades;

namespace back_end.repositorios
{
    public class RepositorioEnMemoria: IRepositorio
    {
        private List<Genero> generos;

        public RepositorioEnMemoria()
        {
            generos = new List<Genero>() {
                new Genero() { Id = 1, Nombre = "comedia"},
                new Genero() { Id = 2, Nombre = "terror" },
                new Genero() { Id = 3, Nombre = "anime" }
            };
            guid = Guid.NewGuid();
        }

        public Guid guid;

        public List<Genero> ObternerTodosLosGeneros()
        {
            return generos;
        }
        public async Task<Genero> ObtenerPorId(int Id)
        {
            await Task.Delay(TimeSpan.FromSeconds(3));
            return generos.FirstOrDefault(x => x.Id == Id);

        }
        //public Guid ObtenerGUID()
        //{
        //    return guid;
        //}

        public void CrearGenero(Genero genero)
        {
            genero.Id = generos.Count() + 1;
            generos.Add(genero);
        }
    }
}
