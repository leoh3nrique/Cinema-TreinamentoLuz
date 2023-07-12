using cinema.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

public class MySqlDatabase
{
    private const string connectionString = "server=localhost;port=3307;user=root;password=0909;database=cinema";

    private void ExecuteQuery(string query)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
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

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            string selectQuery = "SELECT * FROM filmes";

            try
            {
                using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Filme filme = new Filme
                            {
                                Codigo = reader.GetString("codigo"),
                                Nome = reader.GetString("nome"),
                                AnoLancamento = reader.GetInt32("anoLancamento"),
                                Diretor = reader.GetString("diretor")
                            };

                            filmes.Add(filme);
                        }
                    }
                }
            }
            catch(Exception ex)
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
        string updateQuery = $"UPDATE filmes SET nome = '{filme.Nome}', anoLancamento = {filme.AnoLancamento}, diretor = '{filme.Diretor}' WHERE codigo = '{filme.Codigo}'";

        ExecuteQuery(updateQuery);
    }

    //Salas
    public List<Sala> GetSalas()
    {
        List<Sala> salas = new List<Sala>();
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            string selectQuery = "SELECT * FROM sala";
            try
            {
                using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Sala sala = new Sala
                            {
                                Codigo = reader.GetString("codigo"),
                                Nome = reader.GetString("nome"),
                                Capacidade = reader.GetInt32("capacidade")
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
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            string selectQuery = "SELECT * FROM sessao";

            try
            {
                using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Sessao sessao = new Sessao
                            {
                                CodigoFilme = reader.GetString("codigoFilme"),
                                CodigoSala = reader.GetString("codigoSala"),
                                Data = reader.GetDateTime("data"),
                                Horario = reader.GetString("horario"),
                                Preco = reader.GetInt32("preco")
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
