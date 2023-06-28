using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEYA.SHARED.ITEMS.Models
{

    public class Cuota
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El ID de la cuenta es obligatorio.")]
        public int CuentaId { get; set; }

        public int Numero { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El valor de la cuota debe ser mayor o igual a 0.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "La fecha de vencimiento es obligatoria.")]
        public DateTime FechaVencimiento { get; set; }

        public bool Pendiente { get; set; }

        [ForeignKey(nameof(CuentaId))]
        public Deuda Deuda { get; set; }
    }

}
