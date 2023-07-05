using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Models
{
    public class Sessao
    {
        private string codigoFilme;
        private string codigoSala;
        private DateTime data;
        private string horario;
        private int preco;

        public Sessao() { }

        public Sessao(string codigoFilme, string codigoSala, DateTime data, string horario, int preco)
        {
            this.codigoFilme = codigoFilme;
            this.codigoSala = codigoSala;
            this.data = data;
            this.horario = horario;
            this.preco = preco;
        }
        public string CodigoFilme { 
            get {  return codigoFilme; }
            set {  codigoFilme = value; } 
        }
        public string CodigoSala
        {
            get { return codigoSala; }
            set { codigoSala = value;}
        }
        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }
        public string Horario
        {
            get { return horario; }
            set { horario = value; }
        }
        public int Preco
        {
            get { return preco; }
            set { preco = value; }
        }

    }
}
