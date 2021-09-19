using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoAnimes.ViewModel
{
	public class AnimeViewModel
	{
		public Guid Id { get; set; }
		public string Nome { get; set; }
		public int QuantidadeEpisodios { get; set; }
		public string Descricao { get; set; }
	}
}
