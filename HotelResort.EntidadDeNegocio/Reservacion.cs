using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelResort.EntidadDeNegocio
{
    public class Reservacion
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(50, ErrorMessage = "El largo maximo son 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Apellido es requerido")]
        [MaxLength(50, ErrorMessage = "El largo maximo son 50 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El Correo es requerido")]
        [MaxLength(100, ErrorMessage = "El largo maximo son 100 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El Numero de Identidad es requerido")]
        [MaxLength(25, ErrorMessage = "El largo maximo son 25 caracteres")]
        public string NIdentidad { get; set; }

        [Required(ErrorMessage = "El Movil es requerido")]
        [MaxLength(50, ErrorMessage = "El largo maximo son 50 caracteres")]
        [MinLength(8, ErrorMessage = "El largo minimo es de 8 caracteres")]
        public string Movil { get; set; }

        [Required(ErrorMessage = "El Numero de Habitacion es requerido")]
        [MaxLength(25, ErrorMessage = "El largo maximo son 4 caracteres")]
        public string NHabitacion { get; set; }

        [Required(ErrorMessage = "El Precio de Habitacion es requerido")]
        //[MaxLength(25, ErrorMessage = "El largo maximo son 10 caracteres")]
        public decimal PHabitacion { get; set; }

        [Required(ErrorMessage = "La Fecha de Entrada es requerido")]
        //[MaxLength(25, ErrorMessage = "El largo maximo son 25 caracteres")]
        public DateTime FyHRegistro { get; set; }

        [Required(ErrorMessage = "La Hora de Salida es requerido")]
        //[MaxLength(25, ErrorMessage = "El largo maximo son 25 caracteres")]
        public DateTime FyHEntrada { get; set; }

        [Required(ErrorMessage = "La Hora y Fecha de salida es requerido")]
        //[MaxLength(25, ErrorMessage = "El largo maximo son 25 caracteres")]
        public DateTime FyHSalida { get; set; }

        [NotMapped]
        public int top_aux { get; set; }//propiedad auxiliar que sirve
                                        //para expecificar el numero de registro
                                        //que queremos colsultar
    }
}
