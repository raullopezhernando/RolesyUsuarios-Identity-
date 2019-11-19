using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework.Models
{
    public class Obra
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime AnioPublicacion { get; set; }
        public string ImagenObra { get; set; }

        public int AutorId { get; set; }
        public Autor Autor { get; set; }
        public List<ObraCategoria> ObraCategorias { get; set; }
    }
}

