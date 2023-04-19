using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lanche.Models
{
    public class Lanches
    {
        public int id { get; set; }
        public string? nome { get; set; }
        public double preco { get; set; }
        public bool vegetariano { get; set; }
        public string? tipoCarne { get; set; }
    }
}