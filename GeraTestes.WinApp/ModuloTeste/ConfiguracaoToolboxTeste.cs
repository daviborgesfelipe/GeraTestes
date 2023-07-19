﻿using GeraTestes.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeraTestes.WinApp.ModuloTeste
{
    internal class ConfiguracaoToolboxTeste : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Criação de Testes";
        public override string TooltipInserir => "Novo Teste";
        public override string TooltipEditar => "";
        public override string TooltipExcluir => "Excluir um Teste existente";
        public override string TooltipDuplicar => "Duplicar o Teste selecionado";
        public override string TooltipVisualizar => "Visualizar o Teste selecionado";
        public override string TooltipGerarPdf => "Gerar PDF do Teste Selecionado";

        public override bool EditarHabilitado => false;
        public override bool DuplicarHabilitado => true;
        public override bool VisualizarHabilitado => true;
        public override bool GerarPdfHabilitado => true;
    }
}
