using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Favoritos
    {
        public int Id { get; set; }
        public Users User { get; set; }
        public Articulos Articulo { get; set; }
        public Marcas Marca { get; set; }
        public Categorias Categoria { get; set; }
    }
}
