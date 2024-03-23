using ADSProject.Models;

namespace ADSProject.Interfaces
{
    public interface ICarrera
    {
        public int AgregarCarrera(Carrera carrera);
        public int ActualizarCarrera(int id, Carrera carrera);
        public bool EliminarCarrera(int id);
        public List<Carrera> ObtenerTodosLasCarreras();
        public Carrera ObtenerCarreraPorID(int id);
    }
}
