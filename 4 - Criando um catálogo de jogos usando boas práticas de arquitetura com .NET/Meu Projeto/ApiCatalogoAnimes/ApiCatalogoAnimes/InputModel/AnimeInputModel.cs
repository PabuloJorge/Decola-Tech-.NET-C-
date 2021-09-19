using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoAnimes.InputModel
{
	public class AnimeInputModel
	{
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "O NOME do anime deve conter entre 2 e 100 caracteres")]
        public string Nome { get; set; }



        [Required]
        [Range(1, 1000, ErrorMessage = "A quantidade deve ser de no mínimo 1 e no máximo 1000 EPISÓDIOS")]
        public int QuantidadeEpisodios { get; set; }



        [Required]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "A DESCRIÇÃO do anime deve conter entre 10 e 200 caracteres")]
        public string Descricao { get; set; }
    }
}
