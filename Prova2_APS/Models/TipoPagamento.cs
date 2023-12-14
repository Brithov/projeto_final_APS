using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Prova2_APS.Models
{
    public class TipoPagamento
    {
        public int TipoPagamentoId { get; set; } 
        public string NomeDoCobrado { get; set; }
        public string InformacoesAdicionais { get; set; }   
    }
}