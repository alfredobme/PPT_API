using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PPT.Application.DTO;
using PPT.Application.Interfaces;

namespace PPT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatallasController(IBatallaService batallaService) : ControllerBase
    {
        private readonly IBatallaService _batallaService = batallaService;

        [HttpPost]
        public async Task<IActionResult> CrearBatalla([FromBody] BatallaCreateDTO batallaCreateDTO)
        {
            try
            {
                // Validar Jugador1Id, Jugador2Id
                if (batallaCreateDTO.Jugador1Id <= 0 || batallaCreateDTO.Jugador2Id <= 0) return BadRequest(new { Message = "Validar Datos1" });

                // Validar que Jugador1Id, Jugador2Id no sean iguales
                if (batallaCreateDTO.Jugador1Id == batallaCreateDTO.Jugador2Id) return BadRequest(new { Message = "Validar Datos2" });

                // Validar GanadorId
                // Si no es nulo, que sea Jugador1Id o Jugador2Id
                if (batallaCreateDTO.GanadorId.HasValue)
                {
                    if (batallaCreateDTO.GanadorId <= 0)
                    {
                        return BadRequest(new { Message = "Validar Datos1" });
                    }
                    else
                    {
                        if (batallaCreateDTO.GanadorId != batallaCreateDTO.Jugador1Id && batallaCreateDTO.GanadorId != batallaCreateDTO.Jugador2Id) return BadRequest(new { Message = "Validar Datos3" });
                    }
                }

                int result = await _batallaService.CrearBatallaAsync(batallaCreateDTO);

                if (result == 0) return StatusCode(500, new { Message = "Error" });

                return Ok(new { Message = "Creada" });
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
