using cinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema
{
    public interface ISalaRepository
    {
        List<Sala> GetSalas();
        void AddSala(Sala sala);
        void RemoveSala(Sala sala);

        void EditaSala(Sala sala);
    }
}
