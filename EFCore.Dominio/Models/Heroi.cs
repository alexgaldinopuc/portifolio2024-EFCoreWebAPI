using System.Threading.Tasks.Dataflow;

namespace EFCore.Dominio.Models
{
    public class Heroi
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IdentidadeSecreta IdentidadeSecreta { get; set; }
        public IEnumerable<Arma> Armas { get; set; }
        public IEnumerable<Batalha> HeroisBatalhas { get; set; }
    }
}
