using cinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema
{
    public interface IDatabase
    {
        //Filmes
        List<Filme> GetFilmes();
        void AddFilme (Filme filme);
        void RemoveFilme (Filme filme);
        void EditaFilme(Filme filme);

        //Salas
        List<Sala> GetSalas();
        void AddSala (Sala sala);
        void RemoveSala (Sala sala);

        void EditaSala (Sala sala);

        //Sessao
        List<Sessao> GetSessoes();
        void AddSessao (Sessao sessao);
        void RemoveSessao (Sessao sessao);
        void EditaSessao (Sessao sessao);



    }
}
