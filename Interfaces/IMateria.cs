using ADSProject.Models;

namespace ADSProject.Interfaces
{
    public interface IMateria
    {
        public int AgregarMateria(Materia materia);
        public int ActualizarMateria(int idMateria, Materia materia);
        public bool EliminarMateria(int idMateria);
        public List<Materia> ObtenerTodasLasMaterias();
        public Materia ObtenerMateriasPorID(int idMateria);
    }
}
