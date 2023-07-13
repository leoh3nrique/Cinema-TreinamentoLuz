using System;

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

        public string CodigoFilme
        {
            get { return codigoFilme; }
            set
            {
                if (codigoFilme != value)
                {
                    codigoFilme = value;

                }
            }
        }

        public string CodigoSala
        {
            get { return codigoSala; }
            set
            {
                if (codigoSala != value)
                {
                    codigoSala = value;

                }
            }
        }

        public DateTime Data
        {
            get { return data; }
            set
            {
                if (data != value)
                {
                    data = value;

                }
            }
        }

        public string Horario
        {
            get { return horario; }
            set
            {
                if (horario != value)
                {
                    horario = value;

                }
            }
        }

        public int Preco
        {
            get { return preco; }
            set
            {
                if (preco != value)
                {
                    preco = value;

                }
            }
        }


        public Sessao Clone()
        {
            return (Sessao)this.MemberwiseClone();
        }

        public void EditarSessao(Sessao copiaSessao)
        {
            this.CodigoFilme = copiaSessao.CodigoFilme;
            this.CodigoSala = copiaSessao.CodigoSala;
            this.Data = copiaSessao.Data;
            this.Horario = copiaSessao.Horario;
            this.Preco = copiaSessao.Preco;

        }


    }
}
