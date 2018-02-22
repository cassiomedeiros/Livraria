using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Livraria.Models
{
    public class Empresa
    {
        public int EmpresaId { get; set; }

        [Required]
        public string CNPJ { get; set; }

        [Required]
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [Required]
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }

        public ICollection<UsuarioEmpresa> UsuariosEmpresas { get; set; }

        public ICollection<Cliente> Clientes {get; set;}
        
        public ICollection<Fornecedor> Fornecedores { get; set; }

        public ICollection<Livro> Livros { get; set; }

        public override string ToString()
        {
            return NomeFantasia;
        }

    }
}