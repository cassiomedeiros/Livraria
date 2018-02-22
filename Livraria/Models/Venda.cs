using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Livraria.Models
{
    public class Venda
    {
        public int VendaId { get; set; }

        [Display(Name = "Livro")]
        public int LivroId { get; set; }
        public Livro Livro { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [Required]
        [Display(Name = "Nota Fiscal")]
        [MaxLength(20)]
        public string NotaFiscal { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        [Display(Name = "Valor Unitário")]
        public decimal ValorUnitario { get; set; }

    }
}