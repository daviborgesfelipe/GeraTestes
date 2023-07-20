using GeraTestes.Aplicacao.ModuloMateria;
using GeraTestes.Dominio.ModuloDisciplina;
using GeraTestes.Dominio.ModuloMateria;
using GeraTestes.WinApp.Compartilhado;
using GeraTestes.WinApp.ModuloDisciplina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeraTestes.WinApp.ModuloMateria
{
    internal class ControladorMateria : ControladorBase
    {
        private IRepositorioDisciplina repositorioDisciplina;
        private IRepositorioMateria repositorioMateria;

        private ServicoMateria servicoMateria;

        private TabelaMateriasControl tabelaMaterias;

        public ControladorMateria(
            IRepositorioDisciplina repositorioDisciplina,
            IRepositorioMateria repositorioMateria,
            ServicoMateria servicoMateria
            )
        {
            this.repositorioDisciplina = repositorioDisciplina;
            this.repositorioMateria = repositorioMateria;
            this.servicoMateria = servicoMateria;
        }

        public override void Excluir()
        {
            throw new NotImplementedException();
        }

        public override void Inserir()
        {
            throw new NotImplementedException();
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxMateria();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaMaterias == null)
                tabelaMaterias = new TabelaMateriasControl();

            CarregarMaterias();

            return tabelaMaterias;
        }
        private void CarregarMaterias()
        {
            List<Materia> materias = repositorioMateria.SelecionarTodos();

            tabelaMaterias.AtualizarRegistros(materias);
            mensagemRodape = string.Format("Visualizando {0} matéria{1}", materias.Count, materias.Count == 1 ? "" : "s");

            TelaPrincipalForm.InstanciaTelaPrincipal.AtualizarRodape(mensagemRodape);
        }
    }
}
