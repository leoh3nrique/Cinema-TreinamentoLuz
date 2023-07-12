using System.ComponentModel;

namespace cinema.Models
{
    public class Filme 
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
                    
                }
            }
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
           
        }
    }
}
