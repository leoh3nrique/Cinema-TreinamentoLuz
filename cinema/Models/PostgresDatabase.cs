using cinema;
using cinema.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Windows;

public class PostgresDatabase : IDatabase
{
    private const string connectionString = "host=localhost;port=5432;username=postgres;password=0909;database=cinema-postgres";

    private void ExecuteQuery(string query)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            try
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }



    //Filmes
    public List<Filme> GetFilmes()
    {
        List<Filme> filmes = new List<Filme>();

        //troquei o try de lugar, mudar isso em todos

        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            string selectQuery = "SELECT * FROM filmes";
            try
            {
                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery, connection))
                {
                    connection.Open();
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Filme filme = new Filme
                            {
                                Codigo = (string)reader.GetValue(reader.GetOrdinal("codigo")),
                                Nome = (string)reader.GetValue(reader.GetOrdinal("nome")),
                                AnoLancamento = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("anoLancamento"))),
                                Diretor = (string)reader.GetValue(reader.GetOrdinal("diretor"))
                            };

                            filmes.Add(filme);
                        }
                    }
                }

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        return filmes;
    }

    public void AddFilme(Filme filme)
    {
        string insertQuery = $"INSERT INTO filmes (codigo, nome, anoLancamento, diretor) VALUES ('{filme.Codigo}', '{filme.Nome}', {filme.AnoLancamento}, '{filme.Diretor}')";
        ExecuteQuery(insertQuery);
    }

    public void RemoveFilme(Filme filme)
    {
        string deleteQuery = $"DELETE FROM filmes WHERE codigo = '{filme.Codigo}'";
        ExecuteQuery(deleteQuery);
    }

    public void EditaFilme(Filme filme)
    {
        string insertQuery = $"INSERT INTO filmes (codigo, nome, anoLancamento, diretor) VALUES ('{filme.Codigo}', '{filme.Nome}', {filme.AnoLancamento}, '{filme.Diretor}')";
        ExecuteQuery(insertQuery);
    }

    //Salas
    public List<Sala> GetSalas()
    {
        List<Sala> salas = new List<Sala>();
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            string selectQuery = "SELECT * FROM sala";
            try
            {
                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery, connection))
                {
                    connection.Open();
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Sala sala = new Sala
                            {
                                Codigo = reader.GetString(reader.GetOrdinal("codigo")),
                                Nome = reader.GetString(reader.GetOrdinal("nome")),
                                Capacidade = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("capacidade")))
                            };

                            salas.Add(sala);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        return salas;
    }

    public void AddSala(Sala sala)
    {
        string insertQuery = $"INSERT INTO sala (codigo, nome, capacidade) VALUES ('{sala.Codigo}', '{sala.Nome}', {sala.Capacidade})";
        ExecuteQuery(insertQuery);
    }

    public void RemoveSala(Sala sala)
    {
        string deleteQuery = $"DELETE FROM sala WHERE codigo = '{sala.Codigo}'";
        ExecuteQuery(deleteQuery);
    }

    public void EditaSala(Sala sala)
    {
        string updateQuery = $"UPDATE sala SET nome = '{sala.Nome}', capacidade = {sala.Capacidade} WHERE codigo = '{sala.Codigo}'";
        ExecuteQuery(updateQuery);
    }

    //Sessoes
    public List<Sessao> GetSessoes()
    {
        List<Sessao> sessoes = new List<Sessao>();
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            string selectQuery = "SELECT * FROM sessao";

            try
            {
                using (NpgsqlCommand command = new NpgsqlCommand(selectQuery, connection))
                {
                    connection.Open();
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Sessao sessao = new Sessao
                            {
                                CodigoFilme = reader.GetString(reader.GetOrdinal("codigoFilme")),
                                CodigoSala = reader.GetString(reader.GetOrdinal("codigoSala")),
                                Data = reader.GetDateTime(reader.GetOrdinal("data")),
                                Horario = reader.GetString(reader.GetOrdinal("horario")),
                                Preco = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("preco")))
                            };

                            sessoes.Add(sessao);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        return sessoes;
    }

    public void AddSessao(Sessao sessao)
    {
        string insertQuery = $"INSERT INTO sessao (codigoFilme, codigoSala, data, horario, preco) VALUES ('{sessao.CodigoFilme}', '{sessao.CodigoSala}', '{sessao.Data}', '{sessao.Horario}', {sessao.Preco})";
        ExecuteQuery(insertQuery);
    }

    public void RemoveSessao(Sessao sessao)
    {
        string deleteQuery = $"DELETE FROM sessao WHERE codigoFilme = '{sessao.CodigoFilme}' AND codigoSala = '{sessao.CodigoSala}'";
        ExecuteQuery(deleteQuery);
    }

    public void EditaSessao(Sessao sessao)
    {
        string updateQuery = $"UPDATE sessao SET data = '{sessao.Data}', horario = '{sessao.Horario}', preco = {sessao.Preco} WHERE codigoFilme = '{sessao.CodigoFilme}' AND codigoSala = '{sessao.CodigoSala}'";
        ExecuteQuery(updateQuery);
    }

}