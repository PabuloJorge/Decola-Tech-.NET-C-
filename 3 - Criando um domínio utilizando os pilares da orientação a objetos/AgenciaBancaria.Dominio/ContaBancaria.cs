using System;
using System.Text.RegularExpressions;

namespace AgenciaBancaria.Dominio
{
    public abstract class ContaBancaria
    {
        public int NumeroConta { get; private set; }
        public int DigitoVerificador { get; private set; }
        public decimal Saldo { get; protected set; }
        public DateTime? DataAbertura { get; private set; }
        public DateTime? DataEncerramento { get; private set; }
        public SituacaoConta Situacao { get; private set; }
        public string Senha { get; private set; }
        public Cliente Cliente { get; private set; }

        public ContaBancaria(Cliente cliente)
        {
            Random random = new Random();
            NumeroConta = random.Next(500000, 1000000);
            DigitoVerificador = random.Next(0, 9);
            Situacao = SituacaoConta.Criada;
            Cliente = cliente ?? throw new Exception("Cliente deve ser informado!");
        }

        public void Abrir(string senha)
        {
            SetaSenha(senha);
            Situacao = SituacaoConta.Aberta;
            DataAbertura = DateTime.Now;
        }

        private void SetaSenha(string senha)
        {
            senha.ValidaStringVazia();
            if (!Regex.IsMatch(senha, @"^(?=.*?[a-z])(?=.*?[0-9]).{8,}$"))
            {
                throw new Exception("Senha inválida!");
            }
            Senha = senha;
        }

        public virtual void Sacar(decimal valor, string senha)
        {
            if (senha != Senha)
            {
                throw new Exception("Senha inválida!");

            }

            if (Saldo < valor)
            {
                throw new Exception("Saldo insuficiente!");
            }

            Saldo -= valor;
            
        }
    }
}