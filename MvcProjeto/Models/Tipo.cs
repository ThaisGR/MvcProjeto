using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcProjeto.Models
{
    public class Tipo
    {
        [Key]
        public int TipoID { get; set; }
        [Required]
        public string  Nome { get; set; }

        


    }
}