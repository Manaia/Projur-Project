using System.Threading.Tasks;
using Projur.Business.Services;
using Projur.Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace Projur.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public async Task<IActionResult> Get()
        {
            var service = new UsuarioService();

            var usuario = await service.GetUsuarios();

            return base.Ok(usuario);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var service = new UsuarioService();

            var usuario = await service.GetUsuario(id);

            if(!(usuario is Usuario)) return base.NoContent();

            return base.Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            var resultadoCadastro = await new UsuarioService().SalvarUsuario(usuario);

            if(!resultadoCadastro.Sucesso)
                return base.BadRequest(resultadoCadastro);

            return base.CreatedAtAction("Get", resultadoCadastro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Usuario usuario)
        {
            var resultadoEdicao = await new UsuarioService().SalvarUsuario(usuario);

            if(!resultadoEdicao.Sucesso)
                return base.BadRequest(resultadoEdicao);

            return base.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultadoExclusao = await new UsuarioService().Excluir(id);

            if(!resultadoExclusao.Sucesso) 
                return base.BadRequest(resultadoExclusao);

            return base.NoContent();
        }
    }
}