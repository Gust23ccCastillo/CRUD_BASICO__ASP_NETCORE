using System;
using System.Collections.Generic;


namespace Proyect_Crud.Models
{
    public partial class Contacto
    {
        public int IdContacto { get; set; }
        
        public string? Nombre { get; set; }
      
        public string? CorreoElectronico { get; set; }
       
        public string? Telefono { get; set; }
        
        public DateTime? FechaNacimiento { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
