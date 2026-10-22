using Backoffice.Dtos;

namespace Backoffice.Services
{
    public class CategoriaServiceMemoria : ICategoriaService
    {
        private readonly List<CategoriaDto> _categorias;
        private readonly object _lock = new();
        private int _siguienteId = 3;

        public CategoriaServiceMemoria()
        {
            _categorias = new List<CategoriaDto>
            {
                new() { Id = 1, Nombre = "electronica", Descripcion = "dispositivos electronicos" },
                new() { Id = 2, Nombre = "libros", Descripcion = "Materiales escolares" }
            };
        }

        public IEnumerable<CategoriaDto> Listar()
        {
            lock (_lock)
            {
                return _categorias.ToList();
            }
        }
        public CategoriaDto? ObtenerPorId(int id)
        {
            lock (_lock)
            {
                return _categorias.FirstOrDefault(c => c.Id == id);
            }
        }
      public CategoriaDto Crear(CategoriaCrearDto dto)
        {
            lock (_lock)
            {
                var nueva=new CategoriaDto
                {
                    Id = _siguienteId++,
                    Nombre = dto.Nombre,
                    Descripcion = dto.Descripcion
                };
                _categorias.Add(nueva);
                return nueva;
            }
        }
    }
}