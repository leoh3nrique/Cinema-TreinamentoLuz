using cinema;
using cinema.Models;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows;

public class MySqlDatabase : IDatabase
{
    private const string connectionString = "server=localhost;port=3307;user=root;password=0909;database=cinema";

    private readonly MySqlConnection connection;
    public MySqlDatabase()
    {
        connection = new MySqlConnection(connectionString);
    }

    private void ExecuteQuery(string query, params object[] values)
    {
        try
        {
            connection.Open();  
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    command.Parameters.AddWithValue($"@value{i}", values[i]);
                }

                command.ExecuteNonQuery();
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally { connection.Close(); }
    }

    //Filmes
    public List<Filme> GetFilmes()
    {
        List<Filme> filmes = new List<Filme>();

        string selectQuery = "SELECT * FROM filmes";

        try
        {
            connection.Open();
            using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
            {
            
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Filme filme = new Filme
                        (
                            reader.GetString("codigo"),
                            reader.GetString("nome"),
                            reader.GetInt32("anoLancamento"),
                            reader.GetString("diretor")
                        );

                        filmes.Add(filme);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally { connection.Close(); }
    
        return filmes;
           
    }

    public void AddFilme(Filme filme)
    {
        string insertQuery = "INSERT INTO filmes (codigo, nome, anoLancamento, diretor) VALUES (@value0, @value1, @value2, @value3)";

        ExecuteQuery(insertQuery, filme.Codigo, filme.Nome, filme.AnoLancamento, filme.Diretor);
    }

    public void RemoveFilme(Filme filme)
    {
        string deleteQuery = "DELETE FROM filmes WHERE codigo = @value0";

        ExecuteQuery(deleteQuery, filme.Codigo);
    }

    public void EditaFilme(Filme filme)
    {
        string updateQuery = "UPDATE filmes SET nome = @value0, anoLancamento = @value1, diretor = @value2 WHERE codigo = @value3";

        ExecuteQuery(updateQuery, filme.Nome, filme.AnoLancamento, filme.Diretor, filme.Codigo);
    }


    //Salas
    public List<Sala> GetSalas()
    {
        List<Sala> salas = new List<Sala>();
        string selectQuery = "SELECT * FROM sala";
        
        try
        {
            connection.Open();
            using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
            {
                
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
        }finally { connection.Close(); }
        return salas;
    }

    public void AddSala(Sala sala)
    {
        string insertQuery = "INSERT INTO sala (codigo, nome, capacidade) VALUES (@value0, @value1, @value2)";

        ExecuteQuery(insertQuery, sala.Codigo, sala.Nome, sala.Capacidade);
    }

    public void RemoveSala(Sala sala)
    {
        string deleteQuery = "DELETE FROM sala WHERE codigo = @value0";

        ExecuteQuery(deleteQuery, sala.Codigo);
    }

    public void EditaSala(Sala sala)
    {
        string updateQuery = "UPDATE sala SET nome = @value0, capacidade = @value1 WHERE codigo = @value2";

        ExecuteQuery(updateQuery, sala.Nome, sala.Capacidade, sala.Codigo);
    }



    //Sessoes
    public List<Sessao> GetSessoes()
    {
        List<Sessao> sessoes = new List<Sessao>();
        string selectQuery = "SELECT * FROM sessao";

        
        try
        {
            connection.Open();
            using (MySqlCommand command = new MySqlCommand(selectQuery, connection))
            {
           
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
        }finally { connection.Close(); }
        return sessoes;
    }

    public void AddSessao(Sessao sessao)
    {
        string insertQuery = "INSERT INTO sessao (codigoFilme, codigoSala, data, horario, preco) VALUES (@value0, @value1, @value2, @value3, @value4)";

        ExecuteQuery(insertQuery, sessao.CodigoFilme, sessao.CodigoSala, sessao.Data.ToString("yyyy-MM-dd"), sessao.Horario, sessao.Preco);
    }

    public void RemoveSessao(Sessao sessao)
    {
        string deleteQuery = "DELETE FROM sessao WHERE codigoFilme = @value0 AND codigoSala = @value1";

        ExecuteQuery(deleteQuery, sessao.CodigoFilme, sessao.CodigoSala);
    }

    public void EditaSessao(Sessao sessao)
    {
        string updateQuery = "UPDATE sessao SET data = @value0, horario = @value1, preco = @value2 WHERE codigoFilme = @value3 AND codigoSala = @value4";

        ExecuteQuery(updateQuery, sessao.Data.ToString("yyyy-MM-dd"), sessao.Horario, sessao.Preco, sessao.CodigoFilme, sessao.CodigoSala);
    }
}
