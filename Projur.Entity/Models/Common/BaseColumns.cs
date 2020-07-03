using System;

namespace Projur.Entity.Models
{
    public class BaseColumns
    {
        public DateTime DtCriacao  { get; set; }
        public DateTime? DtUltAlteracao  { get; set; }
        public bool Ativo { get; set; }
    }
}