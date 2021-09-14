using System;
using Series.Classes;


namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static FilmeRepositorio repositorioFilme = new FilmeRepositorio();


        static void Main(string[] args)
        {

            var opcao = ObterOpcaoUsuario1();
            while (opcao.ToUpper() != "X")
            {
                switch (opcao)
                {

                    case "1":
                        Console.WriteLine("Acessando Séries...");
                        String opcaoUsuario = ObterOpcaoUsuario();

                        while (opcaoUsuario.ToUpper() != "X")
                        {
                            switch (opcaoUsuario)
                            {
                                case "1":
                                    ListarSeries();
                                    break;
                                case "2":
                                    InserirSerie();
                                    break;
                                case "3":
                                    AtualizarSerie();
                                    break;
                                case "4":
                                    ExcluirSerie();
                                    break;
                                case "5":
                                    VisualizarSerie();
                                    break;
                                case "C":
                                    Console.Clear();
                                    break;


                                default:
                                    throw new ArgumentOutOfRangeException();
                            }

                            opcaoUsuario = ObterOpcaoUsuario();

                        }
                        break;
                    case "2":
                        Console.WriteLine("Acessando Filmes...");
                        String opcaoUsuario1 = ObterOpcaoUsuario();

                        while (opcaoUsuario1.ToUpper() != "X")
                        {
                            switch (opcaoUsuario1)
                            {
                                case "1":
                                    ListarFilmes();
                                    break;
                                case "2":
                                    InserirFilme();
                                    break;
                                case "3":
                                    AtualizarFilme();
                                    break;
                                case "4":
                                    ExcluirFilme();
                                    break;
                                case "5":
                                    VisualizarFilme();
                                    break;
                                case "C":
                                    Console.Clear();
                                    break;


                                default:
                                    throw new ArgumentOutOfRangeException();
                            }

                            opcaoUsuario1 = ObterOpcaoUsuario();
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcao = ObterOpcaoUsuario1();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        public static string ObterOpcaoUsuario1()
        {
            Console.WriteLine("===================================================");
            Console.WriteLine("Escolha sua opção:");
            Console.WriteLine("1 - Series");
            Console.WriteLine("2 - Filmes");
            Console.WriteLine("X - SAIR");
            Console.WriteLine("===================================================");
            var opcao = Console.ReadLine();
            return opcao;

        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("===================================================");
            Console.WriteLine("DIO FILMES e SÉRIES a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar");
            Console.WriteLine("2- Inserir novo");
            Console.WriteLine("3- Atualizar");
            Console.WriteLine("4- Excluir");
            Console.WriteLine("5- Visualizar");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Voltar");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine("===================================================");
            return opcaoUsuario;
        }
        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }
        private static void ListarFilmes()
        {
            Console.WriteLine("Listar Filmes");

            var lista = repositorioFilme.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum filme cadastrado.");
                return;
            }

            foreach (var filme in lista)
            {
                var excluido = filme.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }

        private static void InserirFilme()
        {
            Console.WriteLine("Inserir novo filme");

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título do Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início do Filme: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme novoFilme = new Filme(id: repositorioFilme.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorioFilme.Insere(novoFilme);
        }
        private static void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void AtualizarFilme()
        {
            Console.Write("Digite o id do FILME: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título do FILME: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de início do FILME: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição do FILME: ");
            string entradaDescricao = Console.ReadLine();

            Filme atualizaFilme = new Filme(id: indiceFilme,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorioFilme.Atualiza(indiceFilme, atualizaFilme);
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void ExcluirFilme()
        {
            Console.Write("Digite o id do FILME: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            repositorioFilme.Exclui(indiceFilme);
        }
        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }
        private static void VisualizarFilme()
        {
            Console.Write("Digite o id do FILME: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var filme = repositorio.RetornaPorId(indiceFilme);

            Console.WriteLine(filme);
        }

    }
}
