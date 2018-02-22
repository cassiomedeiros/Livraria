using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Livraria.Models
{
    public class Livro
    {
        public int LivroId { get; set; }

        [Required]
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        public int AutorId { get; set; }
        public Autor Autor {get; set;}

        [Required]
        [Display(Name = "Ano de Publicação")]
        public int AnoPublicao { get; set; }

        public ICollection<EntradaEstoque> EntradasEstoque { get; set; }

        public ICollection<Venda> Vendas { get; set; }

        [NotMapped]
        public virtual int EmEstoque
        {
            get
            {
                int qtdEstoque = 0;
                if (EntradasEstoque != null)
                  qtdEstoque =  EntradasEstoque.Sum(e => e.Quantidade - (e.PerdasEstoque != null ? e.PerdasEstoque.Sum(p => p.Quantidade) : 0)) - (Vendas != null ? Vendas.Sum(v => v.Quantidade) : 0);

                return qtdEstoque;
            }
        }

        public override string ToString()
        {
            return Nome + ", " + AnoPublicao;
        }
 
    }
}