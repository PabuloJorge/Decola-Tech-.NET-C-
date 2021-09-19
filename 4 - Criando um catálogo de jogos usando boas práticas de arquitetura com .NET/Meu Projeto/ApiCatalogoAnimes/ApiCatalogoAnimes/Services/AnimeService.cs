using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCatalogoAnimes.Entities;
using ApiCatalogoAnimes.Exceptions;
using ApiCatalogoAnimes.InputModel;
using ApiCatalogoAnimes.Repositories;
using ApiCatalogoAnimes.ViewModel;

namespace ApiCatalogoAnimes.Services
{
	public class AnimeService : IAnimeService
	{
        private readonly IAnimeRepository _animeRepository;

        public AnimeService(IAnimeRepository animeRepository)
        {
            _animeRepository = animeRepository;
        }

        public async Task<List<AnimeViewModel>> Obter(int pagina, int quantidade)
        {
            var animes = await _animeRepository.Obter(pagina, quantidade);

            return animes.Select(anime => new AnimeViewModel
            {
                Id = anime.Id,
                Nome = anime.Nome,
                QuantidadeEpisodios = anime.QuantidadeEpisodios,
                Descricao = anime.Descricao
            }).ToList();
        }

        public async Task<AnimeViewModel> Obter(Guid id)
        {
            var anime = await _animeRepository.Obter(id);

            if (anime == null)
                return null;

            return new AnimeViewModel
            {
                Id = anime.Id,
                Nome = anime.Nome,
                QuantidadeEpisodios = anime.QuantidadeEpisodios,
                Descricao = anime.Descricao
            };
        }

        public async Task<AnimeViewModel> Inserir(AnimeInputModel anime)
        {
            var entidadeAnime = await _animeRepository.Obter(anime.Nome);

            if (entidadeAnime.Count > 0)
                throw new AnimeJaCadastradoException();

            var animeInsert = new Anime
            {
                Id = Guid.NewGuid(),
                Nome = anime.Nome,
                QuantidadeEpisodios = anime.QuantidadeEpisodios,
                Descricao = anime.Descricao
            };

            await _animeRepository.Inserir(animeInsert);

            return new AnimeViewModel
            {
                Id = animeInsert.Id,
                Nome = anime.Nome,
                QuantidadeEpisodios = anime.QuantidadeEpisodios,
                Descricao = anime.Descricao
            };
        }

        public async Task Atualizar(Guid id, AnimeInputModel anime)
        {
            var entidadeAnime = await _animeRepository.Obter(id);

            if (entidadeAnime == null)
                throw new AnimeNaoCadastradoException();

            entidadeAnime.Nome = anime.Nome;
            entidadeAnime.QuantidadeEpisodios = anime.QuantidadeEpisodios;
            entidadeAnime.Descricao = anime.Descricao;

            await _animeRepository.Atualizar(entidadeAnime);
        }

        public async Task Atualizar(Guid id, string nome)
        {
            var entidadeAnime = await _animeRepository.Obter(id);

            if (entidadeAnime == null)
                throw new AnimeNaoCadastradoException();

            entidadeAnime.Nome = nome;

            await _animeRepository.Atualizar(entidadeAnime);
        }

        public async Task Remover(Guid id)
        {
            var jogo = await _animeRepository.Obter(id);

            if (jogo == null)
                throw new AnimeNaoCadastradoException();

            await _animeRepository.Remover(id);
        }

        public void Dispose()
        {
            _animeRepository?.Dispose();
        }

		
	}
}
