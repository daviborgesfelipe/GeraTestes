﻿using GeraTestes.Dominio;

namespace GeraTestes.WinApp.Compartilhado
{
    public delegate Result GravarRegistroDelegate<TEntidade>(TEntidade disciplina)
        where TEntidade : EntidadeBase<TEntidade>;
}
