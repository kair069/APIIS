using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api_es.Models;
using web_api_es.DLAC;
namespace web_api_es.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiNegociosController : ControllerBase
    {
       
        [HttpGet("solicitudes")]
        public async Task<IActionResult> GetSolicitudes()
        {
            return Ok(await Task.Run(() => new solicitudDLAC().listado()));
        }

        [HttpGet("actividades")]
        public async Task<IActionResult> GetActividades()
        {
            return Ok(await Task.Run(() => new actividadDLAC().listado()));
        }
        [HttpPut("actualizar")]
        public async Task<IActionResult> PutActualizar(Solicitud reg)
        {
            return Ok(await Task.Run(() => new solicitudDLAC().actualizar(reg)));
        }
        [HttpPost("registrar")]
        public async Task<IActionResult> PostRegistrar(Solicitud reg)
        {
            return Ok(await Task.Run(() => new solicitudDLAC().insertar(reg)));
        }


    }
}