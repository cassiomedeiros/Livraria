using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Livraria.Models;

namespace Livraria.Models
{
    public class EntradaEstoque
    {
        public int EntradaEstoqueId { get; set; }

        [Display(Name = "Livro")]
        public int LivroId { get; set; }
        public Livro Livro { get; set; }

        [Display(Name = "Fornecedor")]
        public int FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }

        public DateTime Data { get; set; }

        [Display(Name = "Nota Fiscal")]
        public string NotaFiscal { get; set; }

        public int Quantidade { get; set; }

        [Display(Name = "Valor Unitário")]
        public decimal ValorUnitario { get; set; }

        public ICollection<PerdaEstoque> PerdasEstoque {get; set;}

        public override string ToString()
        {
            return Livro.Nome + ", Nota Fiscal " + Fornecedor.Nome;
        }

    }
}