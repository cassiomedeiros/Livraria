using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Livraria.Models
{
    public class UsuarioEmpresa
    {
        public int UsuarioEmpresaId { get; set; }

        [Display(Name = "Usuário")]
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Display(Name = "Empresa")]
        public int EmpresaId { get; set;}
        public Empresa Empresa { get; set; }

    }
}