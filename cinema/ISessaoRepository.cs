using cinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema
{
    public interface ISessaoRepository
    {
        List<Sessao> GetSessoes();
        void AddSessao(Sessao sessao);
        void RemoveSessao(Sessao sessao);
        void EditaSessao(Sessao sessao);

    }
}
