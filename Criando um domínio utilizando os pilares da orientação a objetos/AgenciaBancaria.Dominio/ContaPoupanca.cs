namespace AgenciaBancaria.Dominio
{
    public class ContaPoupanca : ContaBancaria
    {
        public decimal PercentualRendimento { get; private set; }
        public ContaPoupanca(Cliente cliente) : base(cliente)
        {
            PercentualRendimento = 0.003M;
        }
    }
}