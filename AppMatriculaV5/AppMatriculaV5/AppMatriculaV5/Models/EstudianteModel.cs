using System;
using System.Collections.Generic;
using System.Text;

namespace AppMatriculaV5.Models
{
   public class EstudianteModel
    {

        public int EstudianteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Enfermedad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Cedula { get; set; }
        public int Telefono { get; set; }
        public string Curso { get; set; }
        public int MontoMatricula { get; set; }





    }
}
