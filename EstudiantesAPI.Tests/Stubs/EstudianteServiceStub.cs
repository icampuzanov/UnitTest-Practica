// EstudiantesAPI.Tests/Stubs/EstudianteServiceStub.cs
using EstudiantesAPI.Models;
using EstudiantesAPI.Services;
using System.Collections.Generic;
using System.Linq;

namespace EstudiantesAPI.Tests.Stubs
{
    public class EstudianteServiceStub : IEstudianteService
    {
        private readonly List<Estudiante> _estudiantes;

        public EstudianteServiceStub()
        {
            _estudiantes = new List<Estudiante>
            {
                new Estudiante { CI = 11111111, Nombre = "Ana Gómez", Nota = 75 },
                new Estudiante { CI = 22222222, Nombre = "Luis Martínez", Nota = 45 },
                new Estudiante { CI = 33333333, Nombre = "María Pérez", Nota = 51 }
            };
        }

        public Estudiante? GetByCI(int CI)
        {
            return _estudiantes.FirstOrDefault(e => e.CI == CI);
        }

        public bool HaAprobado(Estudiante estudiante)
        {
            return estudiante.Nota >= 51;
        }
    }
}
