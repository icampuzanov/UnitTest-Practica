using EstudiantesAPI.Models;

namespace EstudiantesAPI.Services
{
    public interface IEstudianteService
    {
        Estudiante? GetByCI(int CI);
        bool HaAprobado(Estudiante estudiante);
    }
}