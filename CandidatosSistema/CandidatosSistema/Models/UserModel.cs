using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CandidatosSistema.Models
{
    public class UserModel
    {
        [Required] // Dato requerido
        [StringLength(80)] // Logitud maxima del campo
        [Display(Name = "Usiario")] // Mensaje de que el camppo es obligatorio    
        public string Usuario1 { get; set; }


        [Required] // dato requerido
        [DataType(DataType.Password)] // idica que el campo es de tipo passsword
        [StringLength(20, MinimumLength = 10)] // longitud minima y maxima
        [Display(Name = "Contraseña")] // Mensaje indica quie es obligatorio
        public string Clave { get; set; }

    }
}