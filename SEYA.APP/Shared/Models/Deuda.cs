using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEYA.APP.Shared.Models
{
    public class Deuda
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; }

        [StringLength(20, ErrorMessage = "El número de comprobante no debe exceder los 20 caracteres.")]
        public string NumeroComprobante { get; set; }

        [Required(ErrorMessage = "El ID del cliente es obligatorio.")]
        public int ClienteId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "La cantidad de cuotas debe ser mayor a 0.")]
        public int CantidadCuotas { get; set; }
        [Required(ErrorMessage = "El valor es obligatorio")]
        [Range(1, double.MaxValue, ErrorMessage = "El valor total debe ser mayor a 0.")]
        public decimal ValorTotal { get; set; }
        [Required(ErrorMessage = "La Descripcion es obligatoria.")]
        public string Descripcion { get; set; }
        public List<Cuota> Cuotas { get; set; }
        [ForeignKey(nameof(ClienteId))]
        public Cliente Cliente { get; set; } 
    }
}
