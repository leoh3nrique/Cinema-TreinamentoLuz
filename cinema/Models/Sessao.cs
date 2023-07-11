using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;

namespace cinema.Models
{
    public class Sessao : INotifyPropertyChanged
    {
        private string codigoFilme;
        private string codigoSala;
        private DateTime data;
        private string horario;
        private int preco;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

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
                    OnPropertyChanged(nameof(CodigoFilme));
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
                    OnPropertyChanged(nameof(CodigoSala));
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
                    OnPropertyChanged(nameof(Data));
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
                    OnPropertyChanged(nameof(Horario));
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
                    OnPropertyChanged(nameof(Preco));
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
            this.OnPropertyChanged(null);
        }
     

    }
}
