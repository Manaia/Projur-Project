using System.Threading.Tasks;
using Projur.Entity.Models;
using Projur.Data.DBConfiguration.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Projur.Business.Validations;
using Projur.Entity;

namespace Projur.Business.Services
{
    public class UsuarioService
    {
        private readonly ApplicationContext _context;
        public UsuarioService() => this._context = new ApplicationContext();
        internal UsuarioService(ApplicationContext context) => this._context = context;
        private async Task<IList<Usuario>> Get()
        {
            return await _context.Usuarios
                        .Where(v => v.Ativo)
                        .Include(v => v.Escolaridade)
                        .OrderByDescending(v => v.DtCriacao)
                        .ToListAsync();
        } 
        private async Task<Usuario> Get(int id)
            => (await Get()).FirstOrDefault(v => v.UsuarioId == id);
        public async Task<IList<Usuario>> GetUsuarios()
        {
            var usuarioDbList = await Get();

            if(!(usuarioDbList is IList<Usuario>)) return null;

            return usuarioDbList;
        }
        public async Task<Usuario> GetUsuario(int usuarioId)
        {
            Usuario usuarioDb = await Get(id: usuarioId);
            
            if(!(usuarioDb is Usuario)) return null;

            return usuarioDb;
        }
        public async Task<Resultado> SalvarUsuario(Usuario entityUsuario)
        {
            var resultadoValidacao = ValidacaoUsuario(entityUsuario);
            
            if(!resultadoValidacao.Sucesso) return resultadoValidacao;

            if (entityUsuario.UsuarioId == 0) Criar(entityUsuario);

            else {
                var resultadoEdicao = await Editar(entityUsuario);

                if(!resultadoEdicao.Sucesso) return resultadoEdicao;
            }
            
            await _context.SaveChangesAsync();
            
            return new Resultado(true, "Registro salvo com sucesso");
        }
        private void Criar(Usuario entityUsuario) 
        {
            var usuarioDb = new Usuario();

            usuarioDb.UsuarioId = entityUsuario.UsuarioId;
            usuarioDb.EscolaridadeId = entityUsuario.EscolaridadeId;
            usuarioDb.Nome = entityUsuario.Nome;
            usuarioDb.Sobrenome = entityUsuario.Sobrenome;
            usuarioDb.Email = entityUsuario.Email;
            usuarioDb.DtNascimento = entityUsuario.DtNascimento;

            usuarioDb.Ativo = true;
            usuarioDb.DtCriacao = System.DateTime.Now;

            _context.Set<Usuario>().Attach(usuarioDb);

            _context.Entry<Usuario>(usuarioDb).State = Microsoft.EntityFrameworkCore.EntityState.Added;
        }
        private async Task<Resultado> Editar(Usuario entityUsuario) 
        {
            var usuarioDb = await Get(id: entityUsuario.UsuarioId);

            if(!(usuarioDb is Usuario)) 
                return new Resultado("Usuário não encontrado.");

            usuarioDb.UsuarioId = entityUsuario.UsuarioId;
            usuarioDb.EscolaridadeId = entityUsuario.EscolaridadeId;
            usuarioDb.Nome = entityUsuario.Nome;
            usuarioDb.Sobrenome = entityUsuario.Sobrenome;
            usuarioDb.Email = entityUsuario.Email;
            usuarioDb.DtNascimento = entityUsuario.DtNascimento;

            usuarioDb.DtUltAlteracao = System.DateTime.Now;

            return new Resultado(true);
        }
        public async Task<Resultado> Excluir(int usuarioId)
        {
            var usuarioDb = await Get(id: usuarioId);
            
            if(!(usuarioDb is Usuario)) return new Resultado("Usuário não foi encontrado.");

            usuarioDb.Ativo = false;
            usuarioDb.DtUltAlteracao = System.DateTime.Now;
            
            await _context.SaveChangesAsync();

            return new Resultado(true, "Excluído com sucesso.");
        }
        private Resultado ValidacaoUsuario(Usuario modelUsuario)
        {
            var validator = new UsuarioValidation();  

            var validResult = validator.Validate(modelUsuario);  

            if(!validResult.IsValid)
                return new Resultado(descricao: validResult.Errors?.FirstOrDefault()?.ErrorMessage);
            
            return new Resultado(true);
        } 
    }
}