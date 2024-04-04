using ADSProject.Models;
using ADSProject.Interfaces;

namespace ADSProject.Repositories
{
    public class ProfesorRepository : IProfesor
    {
        private List<Profesor> lstProfesor = new List<Profesor>()
        {
            new Profesor
            {
                IdProfesor = 1, NombresProfesor = "Dimas", ApellidosProfesor = "Carabantes", Email = "dimas.carabantes@usonsonate.edu.sv"
            }
        };
        public int AgregarProfesor(Profesor profesor)
        {
            try
            {
                if (lstProfesor.Count > 0)
                {
                    profesor.IdProfesor = lstProfesor.Last().IdProfesor + 1;
                }

                lstProfesor.Add(profesor);
                return profesor.IdProfesor;
            }
            catch (Exception)
            {
                throw;
                //throw new NotImplementedException();
            }


        }

        public int ActualizarProfesor(int idProfesor, Profesor profesor)
        {
            try
            {
                int indice = lstProfesor.FindIndex(tmp => tmp.IdProfesor == idProfesor);
                lstProfesor[indice] = profesor;
                return idProfesor;

            }
            catch (Exception)
            {
                throw;
                //throw new NotImplementedException();
            }
        }

        public bool EliminarProfesor(int idProfesor)
        {
            try
            {
                int indice = lstProfesor.FindIndex(tmp => tmp.IdProfesor == idProfesor);

                lstProfesor.RemoveAt(indice);
                return true;

            }
            catch (Exception)
            {
                throw;
                //throw new NotImplementedException(); 
            }

        }

        public List<Profesor> ObtenerTodosLosProfesores()
        {
            try
            {
                return lstProfesor;
            }
            catch (Exception)
            {
                throw;
                //throw new NotImplementedException();
            }
        }

        public Profesor ObtenerProfesorPorID(int idProfesor)
        {
            try
            {
                Profesor profesor = lstProfesor.FirstOrDefault(tmp => tmp.IdProfesor == idProfesor);

                return profesor;
            }
            catch (Exception)
            {
                throw;
                //throw new NotImplementedException();
            }
        }
    }
}
