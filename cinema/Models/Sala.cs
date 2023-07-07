using System.ComponentModel;

namespace cinema.Models
{
    public class Sala : INotifyPropertyChanged
    {
        private string codigo;
        private string nome;
        private int capacidade;

        public Sala() { }

        public Sala(string codigo, string nome, int capacidade)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.capacidade = capacidade;
        }

        public string Codigo
        {
            get { return codigo; }
            set
            {
                if (codigo != value)
                {
                    codigo = value;
                    OnPropertyChanged(nameof(Codigo));
                }
            }
        }

        public string Nome
        {
            get { return nome; }
            set
            {
                if (nome != value)
                {
                    nome = value;
                    OnPropertyChanged(nameof(Nome));
                }
            }
        }

        public int Capacidade
        {
            get { return capacidade; }
            set
            {
                if (capacidade != value)
                {
                    capacidade = value;
                    OnPropertyChanged(nameof(Capacidade));
                }
            }
        }

        public Sala Clone()
        {
            return (Sala)this.MemberwiseClone();
        }

        public void EditarSala(Sala copiaSala)
        {
            this.Codigo = copiaSala.Codigo;

            this.Nome = copiaSala.Nome;

            this.Capacidade = copiaSala.Capacidade;
            
            this.OnPropertyChanged(null);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
