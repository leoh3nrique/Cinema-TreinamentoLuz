using System.ComponentModel;

namespace cinema.Models
{
    public class Filme : INotifyPropertyChanged
    {
        private string codigo;
        private string nome;
        private int anoLancamento;
        private string diretor;

        public Filme() { }

        public Filme(string codigo, string nome, int anoLancamento, string diretor)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.anoLancamento = anoLancamento;
            this.diretor = diretor;
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

        public int AnoLancamento
        {
            get { return anoLancamento; }
            set
            {
                if (anoLancamento != value)
                {
                    anoLancamento = value;
                    OnPropertyChanged(nameof(AnoLancamento));
                }
            }
        }

        public string Diretor
        {
            get { return diretor; }
            set
            {
                if (diretor != value)
                {
                    diretor = value;
                    OnPropertyChanged(nameof(Diretor));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Filme Clone()
        {
            return (Filme)this.MemberwiseClone();
        }
        public void EditarFilme(Filme copiaFilme)
        {
            this.Codigo = copiaFilme.Codigo;
            this.Nome = copiaFilme.Nome;
            this.AnoLancamento = copiaFilme.AnoLancamento;
            this.Diretor = copiaFilme.Diretor;
            this.OnPropertyChanged(null);
        }
    }
}
