using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PPT.Application.DTO;
using PPT.Application.Interfaces;

namespace PPT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadoresController(IJugadorService jugadorService) : ControllerBase
    {
        private readonly IJugadorService _jugadorService = jugadorService;

        [HttpGet]
        public async Task<IActionResult> ListarJugadores()
        {
            var jugadores = await _jugadorService.ListarJugadoresAsync();
            return Ok(jugadores);
        }

        [HttpGet("batallas")]
        public async Task<IActionResult> ListarJugadoresBatallas()
        {
            var jugadores = await _jugadorService.ListarJugadoresBatallasAsync();
            return Ok(jugadores);
        }

        [HttpPost]
        public async Task<IActionResult> CrearJugador([FromBody] JugadorCreateDTO jugadorCreateDTO)
        {
            try
            {
                if (jugadorCreateDTO.Nombre.Length == 0) return BadRequest(new { Message = "Validar Datos1" });

                var existe = await _jugadorService.ExisteJugadorAsync(jugadorCreateDTO.Nombre);

                if (existe) return BadRequest(new { Message = "Validar Datos2" });

                int result = await _jugadorService.CrearJugadorAsync(jugadorCreateDTO);

                if (result == 0) return StatusCode(500, new { Message = "Error" });

                return Ok(new { Message = "Creado" });
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new { Message = "Error" });
            }
            catch (Exception)
            {
                return StatusCode(500, new { Message = "Error" });
            }
        }
    }
}
