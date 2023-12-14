using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova2_APS.Models
{
    public class Item
    {   
        public int ItemId { get; set; }
        public double Preco { get; set; } 
        public int Percentual { get; set; }
        public int Quantidade { get; set; }
    }
}