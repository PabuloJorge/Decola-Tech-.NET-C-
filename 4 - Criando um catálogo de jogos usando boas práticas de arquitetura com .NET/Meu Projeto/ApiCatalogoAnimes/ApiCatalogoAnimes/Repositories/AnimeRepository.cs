using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCatalogoAnimes.Entities;

namespace ApiCatalogoAnimes.Repositories
{
	public class AnimeRepository : IAnimeRepository
	{
		private static Dictionary<Guid, Anime> animes = new Dictionary<Guid, Anime>()
		{
			{Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), new Anime{ Id = Guid.Parse("0ca314a5-9282-45d8-92c3-2985f2a9fd04"), Nome = "Kimetsu no Yaiba", QuantidadeEpisodios= 26, Descricao = "Japão, era Taisho. Tanjiro, um bondoso jovem que ganha a vida vendendo carvão, descobre que sua família foi massacrada por um demônio. E pra piorar, Nezuko, sua irmã mais nova e única sobrevivente, também foi transformada num demônio. Arrasado com esta sombria realidade, Tanjiro decide se tornar um matador de demônios para fazer sua irmã voltar a ser humana, e para matar o demônio que matou sua família. Um triste conto sobre dois irmãos, onde os destinos dos humanos e dos demônios se entrelaçam, começa agora."} },
			
			
			{Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), new Anime{ Id = Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), Nome = "Hunter x Hunter", QuantidadeEpisodios= 100, Descricao = "Gon Freecss, um garoto de doze anos, um dia descobre que seu pai, que supostamente estava morto, estava vivo e bem. Seu Pai, Ging, é um Hunter, um membro de elite da sociedade com uma licença para ir a qualquer lugar ou fazer qualquer coisa. Gon, determinado a seguir os passos de seu pai, decide fazer o exame para Hunter, e um dia encontrar seu pai para provar a si mesmo como um caçador em seu próprio direito. Mas, no caminho, ele descobre que existe muito mais para se tornar um caçador, e os desafios que ele enfrentará são considerados os mais difíceis do mundo."} },
			

			{Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"), new Anime{ Id = Guid.Parse("5e99c84a-108b-4dfa-ab7e-d8c55957a7ec"), Nome = "Record of Ragnarok", QuantidadeEpisodios= 25, Descricao = "Antes de erradicar a humanidade do mundo, os deuses dão a eles uma última chance de provar que são dignos de sobreviver. Que as batalhas do Ragnarok comecem."} }
		};

		public Task<List<Anime>> Obter(int pagina, int quantidade)
		{
			return Task.FromResult(animes.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
		}

		public Task<Anime> Obter(Guid id)
		{
			if (!animes.ContainsKey(id))
				return Task.FromResult<Anime>(null);

			return Task.FromResult(animes[id]);
		}

		public Task<List<Anime>> Obter(string nome)
		{
			return Task.FromResult(animes.Values.Where(anime => anime.Nome.Equals(nome)).ToList());
		}

		public Task<List<Anime>> ObterSemLambda(string nome)
		{
			var retorno = new List<Anime>();

			foreach (var anime in animes.Values)
			{
				if (anime.Nome.Equals(nome))
					retorno.Add(anime);
			}

			return Task.FromResult(retorno);
		}

		public Task Inserir(Anime anime)
		{
			animes.Add(anime.Id, anime);
			return Task.CompletedTask;
		}

		public Task Atualizar(Anime anime)
		{
			animes[anime.Id] = anime;
			return Task.CompletedTask;
		}

		public Task Remover(Guid id)
		{
			animes.Remove(id);
			return Task.CompletedTask;
		}

		public void Dispose()
		{
			//Fechar conexão com o banco
		}
	}
}
