namespace Projur.Entity.Models
{
    public class Escolaridade : BaseColumns
    {
        public int EscolaridadeId { get; set; }
        public string Descricao { get; set; }
        public Escolaridade() { }
    }
}