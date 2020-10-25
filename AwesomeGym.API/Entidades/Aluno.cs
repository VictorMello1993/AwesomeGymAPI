using AwesomeGym.API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeGym.API.Entidades
{
    public class Aluno
    {
        protected Aluno() { }
        public Aluno(string nome, string endereco, DateTime dataNascimento, int idUnidade, int idProfessor)
        {
            Nome = nome;
            Endereco = endereco;
            DataNascimento = dataNascimento;
            Status = StatusAlunoEnum.Ativo;
            IdProfessor = idProfessor;
            IdUnidade = idUnidade;
        }        

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public StatusAlunoEnum Status { get; private set; }

        public int IdUnidade { get; private set; }
        public Unidade Unidade { get; private set; }
        
        public int IdProfessor { get; private set; }
        public Professor Professor { get; private set; }

        public void MudarStatus(StatusAlunoEnum status)
        {
            switch (status)
            {
                case StatusAlunoEnum.Inativo:
                    Status = StatusAlunoEnum.Inativo;
                    break;
                default:
                    Status = StatusAlunoEnum.Ativo;
                    break;
                    
            }
        }

        public void SetEndereco(string endereco)
        {
            Endereco = endereco;
        }

        public void SetNome(string nome)
        {
            Nome = nome;
        }

        public void SetDataNascimento(DateTime dataNascimento)
        {
            DataNascimento = dataNascimento;
        }
    }
}
