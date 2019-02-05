using Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace PlayerLoto.Domain
{
    public class DrawingResult : Entity
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Date)]
        [Display(Name ="Fecha")]
        public DateTime Date { get; set; }

        [Display(Name = "Tiro")]
        public DrawType Type { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Fijo")]
        public int Pick3 { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Corrido 1")]
        public int Pick4First { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Corrido 2")]
        public int Pick4Second { get; set; }
    }

    public enum DrawType
    {
        Midday, Evening
    }
}
