using System.Threading.Tasks;
using Projur.Entity.Models;
using entity = Projur.Entity;
using Projur.Data.DBConfiguration.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Projur.Business.Services
{
    public class EscolaridadeService
    {
        private readonly ApplicationContext _context;
        public EscolaridadeService() => this._context = new ApplicationContext();
        internal EscolaridadeService(ApplicationContext context) => this._context = context;
        private async Task<IList<Escolaridade>> Get()
            => await _context.Escolaridades.ToListAsync();
        private async Task<Escolaridade> Get(int id)
            => await _context.Escolaridades.FindAsync(id);
        public async Task<IList<Escolaridade>> GetEscolaridades()
        {
            var escolaridadeDbList = await Get();

            if(!(escolaridadeDbList is IList<Escolaridade>)) return null;

            return escolaridadeDbList;
        }
        public async Task<Escolaridade> GetEscolaridade(int escolaridadeId)
        {
            var escolaridadeDb = await Get(id: escolaridadeId);

            if(!(escolaridadeDb is Escolaridade)) return null;

            return escolaridadeDb;
        }
    }
}