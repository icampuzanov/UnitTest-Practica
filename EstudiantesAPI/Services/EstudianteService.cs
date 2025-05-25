using EstudiantesAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EstudiantesAPI.Services
{
    public class EstudianteService : IEstudianteService
    {
        private List<Estudiante> _estudiantes;

        public EstudianteService()
        {
            _estudiantes = new List<Estudiante>();
        }

        public Estudiante? GetByCI(int CI)
        {
            var estudiante = _estudiantes.Find(e => e.CI == CI);
            return estudiante;
        }

        public bool HaAprobado(Estudiante estudiante)
        {
            return estudiante.Nota >= 51;
        }
    }
}