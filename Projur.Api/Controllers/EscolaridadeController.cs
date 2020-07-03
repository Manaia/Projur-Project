using System.Threading.Tasks;
using Projur.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Projur.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscolaridadeController : ControllerBase
    {
        public async Task<IActionResult> Get()
        {
            var service = new EscolaridadeService();

            var escolaridades = await service.GetEscolaridades();

            return base.Ok(escolaridades);
        }
    }
}