using Domain.Commands;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _ClienteService;

        public ClienteController(IClienteService ClienteService)
        {
            _ClienteService = ClienteService;
        }

        [HttpPost]
        [Route("CadastrarCliente")]
        public async Task<IActionResult> PostAsync([FromBody] ClienteCommand command)
        {
            return Ok(await _ClienteService.PostAsync(command));
        }
    }
}
