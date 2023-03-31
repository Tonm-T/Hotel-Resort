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
    public class TipoCargo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Cargo es requerido")]
        [MaxLength(25, ErrorMessage = "El largo maximo son 100 caracteres")]
        public string Cargo { get; set; }

        public List<Empleado> Empleados { get; set; } //propiedad de navegacion

        [NotMapped]
        public int top_aux { get; set; }//propiedad auxiliar que sirve
                                        //para expecificar el numero de registro
                                        //que queremos colsultar
    }
}
