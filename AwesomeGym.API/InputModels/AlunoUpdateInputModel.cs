using System;

namespace AwesomeGym.API.InputModels
{
    public class AlunoUpdateInputModel
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
