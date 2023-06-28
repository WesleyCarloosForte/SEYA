using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEYA.APP.Shared.Models
{
    public class Funcionario:Persona
    {
        [Required(ErrorMessage = "El Rol es obligatorio.")]
        public int RolId { get; set; }
        [ForeignKey(nameof(RolId))]
        public Rol Rol { get; set; }
        [Required(ErrorMessage = "El password es obligatorio.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "El Nombre de usuario es obligatorio.")]
        public string UserName { get; set; }
    }
}
