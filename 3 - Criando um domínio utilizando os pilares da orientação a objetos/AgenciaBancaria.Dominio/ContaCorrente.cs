using System;

namespace AgenciaBancaria.Dominio
{
    public class ContaCorrente : ContaBancaria
    {
        public decimal TaxaManutencao { get; private set; }
        public decimal ChequeEspecial { get; private set; }
        public ContaCorrente(Cliente cliente) : base(cliente)
        {
            TaxaManutencao = 0.05M;
            ChequeEspecial = 100;
        }

        public override void Sacar(decimal valor, string senha)
        {
            if (Senha != senha)
            {
                throw new Exception("Senha inválida!");

            }

            if (Saldo + ChequeEspecial < valor)
            {
                throw new Exception("Saldo insuficiente!");
            }

            Saldo -= valor;
            ChequeEspecial -= valor;
        }
    }
}