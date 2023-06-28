using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEYA.SHARED.ITEMS.Models
{
    public class Funcionario:Persona
    {
        public int RolId { get; set; }
        [ForeignKey(nameof(RolId))]
        public Rol Rol { get; set; }
    }
}
