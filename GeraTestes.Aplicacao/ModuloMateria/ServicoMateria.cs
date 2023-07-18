using GeraTestes.Dominio.ModuloMateria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeraTestes.Aplicacao.ModuloMateria
{
    public class ServicoMateria
    {
        private IRepositorioMateria repositorioMateria;
        public ServicoMateria(IRepositorioMateria repositorioMateria)
        {
            this.repositorioMateria = repositorioMateria;
        }
    }
}
