using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Models
{
    public class Filme
    {
        private string codigo;
        private string nome;
        private string anoLancamento;
        private string diretor;

        public Filme() { }

        public Filme(string codigo, string nome, string anoLancamento, string diretor)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.anoLancamento = anoLancamento;
            this.diretor = diretor;
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
        public string AnoLancamento
        {
            get { return anoLancamento;}
            set { anoLancamento = value;}
        }
        public string Diretor
        {
            get { return diretor; }
            set { diretor = value; }
        }
    }
}
