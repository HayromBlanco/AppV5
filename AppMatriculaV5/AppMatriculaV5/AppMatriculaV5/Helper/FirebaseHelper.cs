using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppMatriculaV5.Models;
using System.Linq;
using Firebase.Database.Query;

namespace AppMatriculaV5
{
    public class FirebaseHelper
    {

        FirebaseClient Firebase = new FirebaseClient("https://matriculaapp-598b6.firebaseio.com/");

        public async Task<List<EstudianteModel>> GetAllEstudiantes()
        {
            return (await Firebase
                .Child("Estudiantes")
                .OnceAsync<EstudianteModel>().ConfigureAwait(true)).Select(item => new EstudianteModel
                {
                    EstudianteId = item.Object.EstudianteId,
                    Nombre = item.Object.Nombre,
                    Apellido = item.Object.Apellido,
                    Enfermedad = item.Object.Enfermedad,
                    FechaNacimiento = item.Object.FechaNacimiento,
                    Cedula = item.Object.Cedula,
                    Telefono = item.Object.Telefono,
                    Curso = item.Object.Curso,
                    MontoMatricula = item.Object.MontoMatricula


                }).ToList();
              
        }


        public async Task<EstudianteModel> GetEstudiante(int pCedula)
        {
            var AllEstudiantes = await GetAllEstudiantes().ConfigureAwait(true);
            await Firebase
                .Child("Estudiantes")
                .OnceAsync<EstudianteModel>().ConfigureAwait(true);
            return AllEstudiantes.Where(a => a.Cedula == pCedula).FirstOrDefault();
        }




        public async Task AddEstudiante(int pEstudianteId, string pNombre, string pApellido, string pEnfermedad, DateTime pFechaNacimiento, int pCedula, int pTelefono, string pCurso, int pMontoMatricula)

        {
            await Firebase
                .Child("Estudiantes")
                .PostAsync(new EstudianteModel() { 
                    EstudianteId = pEstudianteId,
                    Nombre = pNombre,
                    Apellido = pApellido,
                    Enfermedad = pEnfermedad,
                    FechaNacimiento = pFechaNacimiento,
                    Cedula = pCedula,
                    Telefono = pTelefono,
                    Curso = pCurso,
                    MontoMatricula = pMontoMatricula
                    
                    }).ConfigureAwait(false);
        
        }

        public async Task UpdateEstudiante(int pEstudianteId, string pNombre, string pApellido, string pEnfermedad, DateTime pFechaNacimiento, int pCedula, int pTelefono, string pCurso, int pMontoMatricula)
        {
            var ToUpdateEstudiante = (await Firebase
                .Child("Estudiantes")
                .OnceAsync<EstudianteModel>().ConfigureAwait(true)
               ).Where(a => a.Object.Cedula == pCedula).FirstOrDefault();

            await Firebase
                .Child("Estudiantes")
                .Child(ToUpdateEstudiante.Key)
                .PutAsync(new EstudianteModel()
                {
                    EstudianteId = pEstudianteId,
                    Nombre = pNombre,
                    Apellido = pApellido,
                    Enfermedad = pEnfermedad,
                    FechaNacimiento = pFechaNacimiento,
                    Cedula = pCedula,
                    Telefono = pTelefono,
                    Curso = pCurso,
                    MontoMatricula = pMontoMatricula
                }).ConfigureAwait(true);
        
        }


        public async Task DeleteEstudiante(int pCedula)
        {
            var ToDeleteEstudiante = (await Firebase
                .Child("Estudiantes")
                .OnceAsync<EstudianteModel>().ConfigureAwait(true)
                ).Where(a => a.Object.Cedula == pCedula).FirstOrDefault();
            await Firebase.Child("Estudiantes").Child(ToDeleteEstudiante.Key).DeleteAsync().ConfigureAwait(true);
        }



    }
}
