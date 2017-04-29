using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcProjeto.Models
{
    public class Chamado
    {
    
        public int ChamadoID { get; set; }
        [Required, StringLength(100)]
        public string Titulo { get; set; }

        [Required, Display(Name = "Descrição"), DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [Required, Display(Name = "Tipo")]
        public int TipoID { get; set; }

        [Required, Display(Name = "Usuario")]
        public int UsuarioID { get; set; }

        [Display(Name = "Tipo")]
        public virtual Tipo _Tipo { get; set; }

        [Display(Name = "Usuario")]
        public virtual Usuario _Usuario { get; set; }

    }

}