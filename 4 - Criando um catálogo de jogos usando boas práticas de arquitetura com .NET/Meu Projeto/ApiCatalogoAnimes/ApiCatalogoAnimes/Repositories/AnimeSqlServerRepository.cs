using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ApiCatalogoAnimes.Entities;
using Microsoft.Extensions.Configuration;

namespace ApiCatalogoAnimes.Repositories
{
    public class AnimeSqlServerRepository : IAnimeRepository
    {
        private readonly SqlConnection sqlConnection;

        public AnimeSqlServerRepository(IConfiguration configuration)
        {
            sqlConnection = new SqlConnection(configuration.GetConnectionString("Default"));
        }

        public async Task<List<Anime>> Obter(int pagina, int quantidade)
        {
            var animes = new List<Anime>();

            var comando = $"select * from Animes order by id offset {((pagina - 1) * quantidade)} rows fetch next {quantidade} rows only";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                animes.Add(new Anime
                {
                    Id = (Guid)sqlDataReader["Id"],
                    Nome = (string)sqlDataReader["Nome"],
                    QuantidadeEpisodios = (int)sqlDataReader["QuantidadeEpisodios"],
                    Descricao = (string)sqlDataReader["Descricao"]
                });
            }

            await sqlConnection.CloseAsync();

            return animes;
        }

        public async Task<Anime> Obter(Guid id)
        {
            Anime anime = null;

            var comando = $"select * from Animes where Id = '{id}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                anime = new Anime
                {
                    Id = (Guid)sqlDataReader["Id"],
                    Nome = (string)sqlDataReader["Nome"],
                    QuantidadeEpisodios = (int)sqlDataReader["QuantidadeEpisodios"],
                    Descricao = (string)sqlDataReader["Descricao"]
                };
            }

            await sqlConnection.CloseAsync();

            return anime;
        }

        public async Task<List<Anime>> Obter(string nome)
        {
            var animes = new List<Anime>();

            var comando = $"select * from Animes where Nome = '{nome}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            while (sqlDataReader.Read())
            {
                animes.Add(new Anime
                {
                    Id = (Guid)sqlDataReader["Id"],
                    Nome = (string)sqlDataReader["Nome"],
                    QuantidadeEpisodios = (int)sqlDataReader["QuantidadeEpisodios"],
                    Descricao = (string)sqlDataReader["Descricao"]
                });
            }

            await sqlConnection.CloseAsync();

            return animes;
        }

        public async Task Inserir(Anime anime)
        {
            var comando = $"insert Animes (Id, Nome, QuantidadeEpisodios, Descricao) values ('{anime.Id}', '{anime.Nome}', '{anime.QuantidadeEpisodios}', '{anime.Descricao}')";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
        }

        public async Task Atualizar(Anime anime)
        {
            var comando = $"update Animes set Nome = '{anime.Nome}', QuantidadeEpisodios = '{anime.QuantidadeEpisodios}', Descricao = '{anime.Descricao}' where Id = '{anime.Id}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
        }

        public async Task Remover(Guid id)
        {
            var comando = $"delete from Animes where Id = '{id}'";

            await sqlConnection.OpenAsync();
            SqlCommand sqlCommand = new SqlCommand(comando, sqlConnection);
            sqlCommand.ExecuteNonQuery();
            await sqlConnection.CloseAsync();
        }

        public void Dispose()
        {
            sqlConnection?.Close();
            sqlConnection?.Dispose();
        }
    }
}
