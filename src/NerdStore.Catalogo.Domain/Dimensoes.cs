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
            Altura = altura;
            Largura = largura;
            Profundidade = profundidade;

            Validar();
        }

        public string DescricaoFormatada() => $"LxAxP: {Largura} x {Altura} x {Profundidade}";

        public override string ToString()
        {
            return DescricaoFormatada();
        }

        private void Validar()
        {
            Validacoes.ValidarSeMenorQue(Altura, 1, "O campo Altura não pode ser menor ou igual a 0");
            Validacoes.ValidarSeMenorQue(Largura, 1, "O campo Largura não pode ser menor ou igual a 0");
            Validacoes.ValidarSeMenorQue(Profundidade, 1, "O campo Profundidade não pode ser menor ou igual a 0");
        }
    }
}