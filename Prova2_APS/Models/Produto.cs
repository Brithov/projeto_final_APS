using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Prova2_APS.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; } 
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public double Preco { get; set; }
        public Marca Marca { get; set; } 
    }
}