using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Prova2_APS.Models
{
    public class NotaVenda
    {
        public int NotaVendaId { get; set; } 
        public DateTime Data { get; set; }
        public bool Tipo { get; set; }

        public bool Cancelar()
        {
            Console.WriteLine("Nota de venda cancelada.");
            return true; 
        }

        public bool Devolver()
        {
            Console.WriteLine("Produto devolvido.");
            return true;
        }
    }
}