using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Prova2_APS.Models
{
    public class PagamentoCartao : TipoPagamento
    {
        public int PagamentoCartaoId { get; set; }
        public string NumeroCartao { get; set; } 
        public string Bandeira { get; set; }
    }
}