using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelResort.EntidadDeNegocio
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(50, ErrorMessage = "El largo maximo son 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Apellido es requerido")]
        [MaxLength(50, ErrorMessage = "El largo maximo son 50 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El Email es requerido")]
        [MaxLength(100, ErrorMessage = "El largo maximo son 100 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El Movil es requerido")]
        [MaxLength(15, ErrorMessage = "El largo maximo son 15 caracteres")]
        [MinLength(8, ErrorMessage = "El largo minimo es de 8 caracteres")]
        public string Movil { get; set; }

        [Required(ErrorMessage = "La direccion es requerido")]
        [MaxLength(50, ErrorMessage = "El largo maximo son 50 caracteres")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El DUI es requerido")]
        [MaxLength(50, ErrorMessage = "El largo maximo son 50 caracteres")]
        public string Dui { get; set; }

        [Required(ErrorMessage = "El Password es obligatorio")]
        [DataType(DataType.Password)]
        [StringLength(10, ErrorMessage = "Password debe estar entre 4 a 10 caracteres", MinimumLength = 4)]
        public string ClaveEmpleado { get; set; }

        [Display(Name = "Fecha registro")]
        public DateTime FechaRegistro { get; set; }

        [Required(ErrorMessage = "El Id de Tipo cargo es requerido")]
        [ForeignKey("TipoCargo")]
        [Display(Name = "Tipo Cargo")]
        public int TipoCargoId { get; set; }

        public TipoCargo TipoCargo { get; set; } //propiedad de navegacion
        [NotMapped]
        public int top_aux { get; set; }//propiedad auxiliar

        [NotMapped]
        [Required(ErrorMessage = "Confirmar la Clave del Empleado")]
        [StringLength(10, ErrorMessage = "Password debe estar entre 4 a 20 caracteres", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Compare("ClaveEmpleado", ErrorMessage = "Password y confirmar password deben de ser iguales")]
        [Display(Name = "Confirmar la Clave del Empleado")]
        public string confirmClaveEmpleado_aux { get; set; }
    }
    
}
