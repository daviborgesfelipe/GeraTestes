using GeraTestes.Dominio.ModuloQuestao;

namespace GeraTestes.Aplicacao.ModuloQuestao
{
    public class ServicoQuestao
    {
        private IRepositorioQuestao repositorioQuestao;

        private ValidadorQuestao validadorQuestao;
        private ValidadorAlternativa validadorAlternativa;

        public ServicoQuestao(
            IRepositorioQuestao _repositorioQuestao,
            ValidadorQuestao _validadorQuestao, 
            ValidadorAlternativa _validadorAlternativa)
        {
            this.repositorioQuestao = _repositorioQuestao;
            this.validadorQuestao = _validadorQuestao;
            this.validadorAlternativa = _validadorAlternativa;
        }
    }
}
