using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Livraria.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }
        
        [Required]
        [Display(Name = "E-mail")]
        [MaxLength (50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string Senha { get; set; }

        public bool Ativo { get; set; }

        public ICollection<Empresa> Empresas { get; set; }

        public ICollection<UsuarioEmpresa> UsuariosEmpresas { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }
}