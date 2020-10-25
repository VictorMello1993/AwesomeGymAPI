using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeGym.API.ViewModels
{
    public class UnidadeViewModel
    {
        public UnidadeViewModel(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; private set; }
    }
}
