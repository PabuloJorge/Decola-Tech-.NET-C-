using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoAnimes.Entities
{
	public class Anime
	{
		public Guid Id { get; set; }
		public string Nome { get; set; }
		public int QuantidadeEpisodios { get; set; }
		public string Descricao { get; set; }
	}
}
