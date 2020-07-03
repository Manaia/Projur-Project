using System;

namespace Projur.Entity.Models
{
    public class Usuario : BaseColumns
    {
        public int UsuarioId { get; set; }
        public int EscolaridadeId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DtNascimento { get; set; }
        public Escolaridade Escolaridade { get; set; }
        public Usuario() { }
    }
}