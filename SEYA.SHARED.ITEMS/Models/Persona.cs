using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEYA.SHARED.ITEMS.Models
{
    public class Persona : Entity
    {
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Apellido es obligatorio.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es obligatorio.")]
        [RegularExpression(@"^0[67][0-9]{7}$", ErrorMessage = "El Teléfono debe tener el formato válido de Paraguay.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo Correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "El Correo no es válido.")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El campo Dirección es obligatorio.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo Cédula es obligatorio.")]
        [RegularExpression(@"^[0-9]{1,2}.[0-9]{3}.[0-9]{3}-[0-9]$", ErrorMessage = "La Cédula debe tener el formato válido de Paraguay.")]
        public string Cedula { get; set; }
    }
}
