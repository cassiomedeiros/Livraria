using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Livraria.Models
{
    public class Autor
    {
        public int AutorId { get; set; }

        [Required]
        public string Nome { get; set; }

        public ICollection<Livro> Livros {get; set;}

        public override string ToString()
        {
            return Nome;
        }
    }
}