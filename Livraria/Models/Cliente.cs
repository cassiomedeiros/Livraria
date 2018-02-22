using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Livraria.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Display(Name = "Empresa")]
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

        [Display(Name = "Pessoa Física")]
        public bool PessoaFisica { get; set; }

        [Display(Name = "CNPJ/CPF")]
        [MaxLength(14)]
        public string CNPJCPF { get; set; }

        [Display(Name = "Nome/Nome Fantasia")]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Display(Name = "Razão Social")]
        [MaxLength(100)]
        public string RazaoSocial { get; set; }

        public ICollection<Venda> Vendas { get; set; }

        public override string ToString()
        {
            return Nome;
        }

    }
}