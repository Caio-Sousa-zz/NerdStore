using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    // Value object
    public class Dimensoes
    {
        public decimal Altura { get; private set; }

        public decimal Largura { get; private set; }

        public decimal Profundidade { get; private set; }

        public Dimensoes(decimal altura, decimal largura, decimal profundidade)
        {
            Validar();

            Altura = altura;
            Largura = largura;
            Profundidade = profundidade;
        }

        public string DescricaoFormatada() => $"LxAxP: {Largura} x {Altura} x {Profundidade}";

        public override string ToString()
        {
            return DescricaoFormatada();
        }

        private void Validar()
        {
            Validacoes.ValidarSeMenorQue(Altura, 1, "O campo Altura não pode ser menor ou igual a 0");
            Validacoes.ValidarSeMenorQue(Altura, 1, "O campo Largura não pode ser menor ou igual a 0");
            Validacoes.ValidarSeMenorQue(Altura, 1, "O campo Profundidade não pode ser menor ou igual a 0");
        }
    }
}