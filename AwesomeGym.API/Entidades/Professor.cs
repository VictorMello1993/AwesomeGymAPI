using AwesomeGym.API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeGym.API.Entidades
{
    public class Professor
    {
        protected Professor() { }
        public Professor(string nome, string endereco, int idUnidade)
        {
            Nome = nome;
            Endereco = endereco;
            Status = StatusProfessorEnum.Ativo;
            Alunos = new List<Aluno>();
            IdUnidade = idUnidade;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public StatusProfessorEnum Status { get; private set; }

        public List<Aluno> Alunos { get; private set; }

        public int IdUnidade { get; private set; }
        public Unidade Unidade { get; private set; }


        public void mudarStatus(StatusProfessorEnum status)
        {            
            switch (status)
            {
                case StatusProfessorEnum.Ferias:
                    Status = StatusProfessorEnum.Ferias;
                    break;
                case StatusProfessorEnum.Inativo:
                    Status = StatusProfessorEnum.Inativo;
                    break;
                case StatusProfessorEnum.VinculoTerminado:
                    Status = StatusProfessorEnum.VinculoTerminado;
                    break;
                default:
                    Status = StatusProfessorEnum.Ativo;
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
    }
}
