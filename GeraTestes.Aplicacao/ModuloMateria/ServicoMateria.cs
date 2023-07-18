using GeraTestes.Dominio.ModuloMateria;

namespace GeraTestes.Aplicacao.ModuloMateria
{
    public class ServicoMateria
    {
        private IRepositorioMateria repositorioMateria;

        private ValidadorMateria validadorMateria;
        public ServicoMateria(
            IRepositorioMateria _repositorioMateria,
            ValidadorMateria _validadorMatria
            )
        {
            this.repositorioMateria = _repositorioMateria;
            this.validadorMateria = _validadorMatria;
        }
    }
}
