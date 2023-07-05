using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Models
{
    public class Sala
    {
        private string codigo;
        private string nome;
        private string capacidade;

        public Sala() { }

        public Sala(string codigo, string nome, string capacidade)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.capacidade = capacidade;
        }
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public string Capacidade
        {
            get { return capacidade; }
            set { capacidade = value; }

        }
    }
}
