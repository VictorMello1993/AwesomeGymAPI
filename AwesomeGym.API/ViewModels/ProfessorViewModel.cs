using AwesomeGym.API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeGym.API.ViewModels
{
    public class ProfessorViewModel
    {
        public ProfessorViewModel(string nome, StatusProfessorEnum status)
        {
            Nome = nome;
            Status = status;
        }

        public String Nome { get; private set; }
        public StatusProfessorEnum Status { get; private set; }
    }
}
