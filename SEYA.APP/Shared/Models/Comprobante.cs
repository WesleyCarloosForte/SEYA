using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEYA.APP.Shared.Models
{
    public class Comprobante:Entity
    {
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo numero actual es obligatorio.")]
        public int NumeroActual { get; set; }

        [Required(ErrorMessage = "El campo numero final es obligatorio.")]
        public int NumeroFinal { get; set; }

        [Required(ErrorMessage = "El campo inicio Vigencia es obligatorio.")]
       
        public DateTime InicioVigencia { get; set; }

        [Required(ErrorMessage = "El campo Fin Vigencia es obligatorio.")]
        public DateTime FinVigencia { get; set; }
        [Required(ErrorMessage = "El campo Punto de expedicion es obligatorio.")]
        public string PuntoExpedicion { get; set; }
        [Required(ErrorMessage = "El campo Timbrado es obligatorio.")]
        public string Timbrado { get; set; }

        [Required(ErrorMessage = "El campo Sucursal es obligatorio.")]
        public string Sucursal { get; set; }
    }
}
