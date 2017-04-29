using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcProjeto.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }

        [Required, StringLength(20)]
        public string Nome { get; set; }
        public string Cpf { get; set; }



    }
}