﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity_Framework.Models
{
    public class ObraCategoria
    {
        public int Id { get; set; }

        public Obra Obra { get; set; }

        public Categoria Categoria { get; set; }
    }
}
