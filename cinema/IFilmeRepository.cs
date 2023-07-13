using cinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema
{
    public interface IFilmeRepository
    {
        List<Filme> GetFilmes();
        void AddFilme(Filme filme);
        void RemoveFilme(Filme filme);
        void EditaFilme(Filme filme);
    }
}
