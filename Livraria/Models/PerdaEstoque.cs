using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Livraria.Models
{
    public class PerdaEstoque
    {
        public int PerdaEstoqueId { get; set; }

        [Display(Name = "Entrada Estoque")]
        public int EntradaEstoqueId { get; set; }
        public EntradaEstoque EntradaEstoque {get; set;}
        
        public DateTime Data { get; set; }
        
        public int Quantidade { get; set; }
    }
}