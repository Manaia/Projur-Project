using System.Collections.Generic;

namespace Projur.Entity
{
    public class Resultado
    {
        public bool Sucesso { get; set; }

        public string Descricao {get; set;}

        public Resultado(bool sucesso) => Sucesso = sucesso;

        public Resultado(string descricao)
        {
            Descricao = descricao;
            Sucesso = false;
        }

        public Resultado(bool sucesso, string descricao) 
            : this(sucesso) => Descricao = descricao;
    }
}