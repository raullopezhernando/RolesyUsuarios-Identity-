using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework.Models
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public DateTime FechaNacimiento { get; set; }

        //public Autobiografia Autobiografia { get; set; }

        public List<Obra> Obras { get; set; }

    }
}
