namespace GeraTestes.Dominio.ModuloQuestao
{
    public class Alternativa : EntidadeBase<Alternativa>
    {
        public Alternativa()
        {
        }

        public Alternativa(int id, char letra, string? resposta, bool correta)
        {
            Id = id;
            Letra = letra;
            Resposta = resposta;
            Correta = correta;
        }

        public bool Correta { get; set; }
        public char Letra { get; set; }
        public Questao Questao { get; set; }
        public string Resposta { get; set; }

        public override void Atualizar(Alternativa registro)
        {
            this.Correta = registro.Correta;
            this.Letra = registro.Letra;
            this.Resposta = registro.Resposta;
        }
        public override bool Equals(object obj)
        {
            return obj is Alternativa alternativa &&
                   Correta == alternativa.Correta &&
                   Letra == alternativa.Letra &&
                   Resposta == alternativa.Resposta;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Correta, Letra, Questao, Resposta);
        }
        public override string ToString()
        {
            return string.Format($"({Letra}) -> {Resposta}");
        }
    }
}
