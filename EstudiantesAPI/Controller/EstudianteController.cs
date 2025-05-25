using Microsoft.AspNetCore.Mvc;
using EstudiantesAPI.Services;
using EstudiantesAPI.Models;

namespace EstudiantesAPI.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class EstudianteController : ControllerBase
    {
        private IEstudianteService _estudianteService;

        public EstudianteController(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }

        [HttpGet("aprobado/{CI}")]
        public ActionResult<string> HaAprobado(int CI)
        {
            Estudiante? estudiante = _estudianteService.GetByCI(CI);
            bool haAprobado = _estudianteService.HaAprobado(estudiante);

            if (haAprobado) {
                return $"{estudiante.Nombre} con CI {estudiante.CI} ha aprobado.";
            }
            else
            {
                return $"{estudiante.Nombre} con CI {estudiante.CI} no ha aprobado.";
            }

        }

    }
}