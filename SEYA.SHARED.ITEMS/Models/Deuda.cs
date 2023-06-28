using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEYA.SHARED.ITEMS.Models
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

        [Range(0, double.MaxValue, ErrorMessage = "El valor total debe ser mayor o igual a 0.")]
        public decimal ValorTotal { get; set; }

        public bool Pendiente { get; set; }

        public List<Cuota> Cuotas { get; set; }
    }
}
