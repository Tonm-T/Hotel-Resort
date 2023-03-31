using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelResort.EntidadDeNegocio
{
    public class CatalogoHotel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        //[MaxLength(50, ErrorMessage = "El largo maximo son 50 caracteres")]
        public string ClaseHabitacion { get; set; }

        [Required(ErrorMessage = "El Apellido es requerido")]
        //[MaxLength(50, ErrorMessage = "El largo maximo son 50 caracteres")]
        public string Detalles { get; set; }

        [Required(ErrorMessage = "El precio es requerido")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El Apellido es requerido")]
        [MaxLength(10, ErrorMessage = "El largo maximo son 10 caracteres")]
        public string NumHabitacion { get; set; }

        [NotMapped]
        public int top_aux { get; set; }//propiedad auxiliar que sirve
                                        //para expecificar el numero de registro
                                        //que queremos colsultar

    }
}
