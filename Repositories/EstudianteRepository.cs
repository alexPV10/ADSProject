using ADSProject.Interfaces;
using ADSProject.Models;


namespace ADSProject.Repositories
{
    public class EstudianteRepository : IEstudiante
    {
        private List<Estudiante> lstEstudiantes = new List<Estudiante>
        {
            new Estudiante
            { IdEstudiante = 1, NombresEstudiante = "Alexander",
                ApellidosEstudiante = "Cruz", CodigoEstudiante = "PC21I04001",
                CorreoEstudiante = "PC21I04001@usonsonate.edu.sv"
            }
        };

        public int AgregarEstudiante(Estudiante estudiante)
        {
            try
            {
                if(lstEstudiantes.Count > 0)
                {
                    estudiante.IdEstudiante = lstEstudiantes.Last().IdEstudiante + 1;
                }

                lstEstudiantes.Add(estudiante);
                return estudiante.IdEstudiante;
            }
            catch (Exception)
            {
                throw;
                //throw new NotImplementedException();
            }


        }

        public int ActualizarEstudiante(int idEstudiante, Estudiante estudiante)
        {
            try
            {
                int indice = lstEstudiantes.FindIndex(tmp=>tmp.IdEstudiante==idEstudiante);
                lstEstudiantes[indice] = estudiante;
                return idEstudiante;

            }
            catch (Exception)
            {
                throw;
                //throw new NotImplementedException();
            }
        }

        public bool EliminarEstudiante(int idEstudiante)
        {
            try
            {
                int indice = lstEstudiantes.FindIndex(tmp => tmp.IdEstudiante == idEstudiante);

                lstEstudiantes.RemoveAt(indice);
                return true;

            }
            catch (Exception)
            {
                throw;
                //throw new NotImplementedException(); 
            }

        }

        public Estudiante ObtenerEstudiantePorID(int idEstudiante)
        {
            try
            {
                Estudiante estudiante = lstEstudiantes.FirstOrDefault(tmp => tmp.IdEstudiante == idEstudiante);

                return estudiante;
            }
            catch (Exception)
            {
                throw;
                //throw new NotImplementedException();
            }
        }

        public List<Estudiante> ObtenerTodosLosEstudiantes()
        {
            try
            {
                return lstEstudiantes;
            }
            catch (Exception)
            {
                throw;
                //throw new NotImplementedException();
            }
        }

        /*
        public Estudiante ObtenerTodosLosEstudiantes(int idEstudiante)
        {
            throw new NotImplementedException();
        }
        */

        /*
        public Estudiante ObtenerTodosLosEstudiantes(int idEstudiante)
        {
            throw new NotImplementedException();
        }
        */

        /*
        public Estudiante ObtenerTodosLosEstudiantes(int idEstudiante)
        {
            throw new NotImplementedException();
        }
        */
    }
}
