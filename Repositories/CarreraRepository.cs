using ADSProject.Interfaces;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class CarreraRepository : ICarrera
    {
        private List<Carrera> lstCarrera = new List<Carrera>
        {
            new Carrera
            {
                Id = 1, Codigo = "I04", Nombre = "Sistemas Computacionales"
            }
        };

        public int ActualizarCarrera(int id, Carrera carrera)
        {
            try
            {
                int indice = lstCarrera.FindIndex(tmp => tmp.Id == id);
                lstCarrera[indice] = carrera;
                return id;

            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public int AgregarCarrera(Carrera carrera)
        {
            try
            {
                if(lstCarrera.Count > 0)
                {
                    carrera.Id = lstCarrera.Last().Id + 1;
                }

                lstCarrera.Add(carrera);
                return carrera.Id;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool EliminarCarrera(int id)
        {
            try
            {
                int indice = lstCarrera.FindIndex(tmp => tmp.Id == id);
                lstCarrera.RemoveAt(indice);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Carrera ObtenerCarreraPorID(int id)
        {
            try
            {
                Carrera carrera = lstCarrera.FirstOrDefault(tmp => tmp.Id == id);
                return carrera;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Carrera> ObtenerTodosLasCarreras()
        {
            try
            {
                return lstCarrera;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
