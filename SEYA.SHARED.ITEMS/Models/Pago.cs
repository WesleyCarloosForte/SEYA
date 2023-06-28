using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEYA.SHARED.ITEMS.Models
{
    public class Pago:Entity
    {
      

        [Required(ErrorMessage = "El campo Comprobante es obligatorio.")]
        public string Comprobante { get; set; }

        [Required(ErrorMessage = "El ID de usuario es obligatorio.")]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "El ID de cuota es obligatorio.")]
        public int CuotaId { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }
        [ForeignKey(nameof(CuotaId))]
        public Cuota Cuota { get; set;}
    }
}
