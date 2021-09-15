using System;
using AgenciaBancaria.Dominio;

namespace AgenciaBancaria.app
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Endereco endereco = new Endereco("Rua da Fé", "54080055", "Recife", "PE");
                Cliente cliente = new Cliente("Pablo Jorge", "123", "321", endereco);
                ContaPoupanca conta = new ContaPoupanca(cliente);


                Console.WriteLine("++++++++++++++++++++++++++++++++++");
                Console.WriteLine($"NOME COMPLETO: {conta.Cliente.Nome}");
                Console.WriteLine($"CONTA {conta.Situacao} {conta.NumeroConta}-{conta.DigitoVerificador}");
                string senha = "abc12345";
                conta.Abrir(senha);
                Console.WriteLine($"CONTA {conta.Situacao} {conta.NumeroConta}-{conta.DigitoVerificador}");
                Console.WriteLine($"Saldo: {conta.Saldo} ");
                conta.Sacar(100, senha);
                Console.WriteLine("++++++++++++++++++++++++++++++++++");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


        }
    }
}
