using System;

namespace segundoProjeto
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            int indexAluno = 0;
            string opcaoUsuario = obterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        var aluno = new Aluno();
                        Console.WriteLine("Digite o nome:");
                        aluno.Nome = Console.ReadLine();
                        Console.WriteLine("Digite o nota:");

                        while (true)
                        {
                            if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                            {
                                aluno.Nota = nota;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Nota Inválida! Digite novamente:");
                            }
                        }

                        alunos[indexAluno] = aluno;
                        indexAluno++;

                        break;
                    case "2":
                        foreach (var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"ALUNO: {a.Nome} - NOTA: {a.Nota}");
                            }
                        }
                        break;
                    case "3":
                        decimal somaNotas = 0;
                        int qtdAlunos = 0;
                        foreach (var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                somaNotas += a.Nota;
                                qtdAlunos++;
                            }

                        
                        }
                        Console.WriteLine($"MÉDIA GERAL: {somaNotas/qtdAlunos}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = obterOpcaoUsuario();

            }


        }

        private static string obterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            String opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
