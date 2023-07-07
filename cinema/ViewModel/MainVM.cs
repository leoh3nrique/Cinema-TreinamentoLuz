using cinema.Models;
using cinema.View;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace cinema.ViewModel
{
    public class MainVM
    {
        public ObservableCollection<Filme> ListaFilmes { get; private set;}
        
        public ObservableCollection<Sala> ListaSalas { get; private set; }

        public ObservableCollection<Sessao> ListaSessao { get; private set; }

        public Filme FilmeSelecionado { get; set; }

        public Sala SalaSelecionada { get;  set; }
        public Sessao SessaoSelecionada { get; set;}

        public ICommand AddFilme { get; private set; }
        public ICommand RemoveFilme { get; private set; }
        public ICommand EditFilme { get; private set; }
      
        public ICommand AddSala { get; private set; }
        public ICommand RemoveSala { get; private set; }
        public ICommand EditSala { get; private set; }

        public ICommand AddSessao { get; private set; }
        public ICommand RemoveSessao { get; private set; }
        public ICommand EditSessao { get; private set; }
       


        public MainVM() 
        {
            ListaSalas = new ObservableCollection<Sala>
            {
                new Sala()
                {
                    Codigo = "s001",
                    Nome= "Sala 01",
                    Capacidade = 60
                }
            };
            ListaFilmes = new ObservableCollection<Filme>()
            {
                new Filme()
                {
                    Codigo = "f001",
                    Nome = "Filme 1",
                    AnoLancamento = 2000,
                    Diretor = "Diretor 1"
                }
            };
            ListaSessao = new ObservableCollection<Sessao>()
            {
                new Sessao()
                {
                    CodigoFilme = "f001",
                    CodigoSala = "s001",
                    Data = "2023-01-01",
                    Horario = "20:00",
                    Preco = 30
                }
            };
            IniciaComandosSala();
            IniciaComandosFilmes();
            IniciaComandosSessao();
        }

   
        public void IniciaComandosSala()
        {
            AddSala = new RelayCommand((object_) =>
            {
                SalaView telaSala = new SalaView();

                Sala novaSala = new Sala();

                telaSala.DataContext = novaSala;

                if (telaSala.ShowDialog().Equals(true))
                {
                    ListaSalas.Add(novaSala);
                }
            });

            RemoveSala = new RelayCommand((object_) => {

                ListaSalas.Remove(SalaSelecionada);

            });

            EditSala = new RelayCommand((object _) =>
            {
                if (SalaSelecionada != null)
                {
                    Sala salaTemporaria = SalaSelecionada.Clone(); 

                    SalaView telaSala = new SalaView();

                    telaSala.DataContext = salaTemporaria;

     

                    if (telaSala.ShowDialog().Equals(true))
                    {
                        SalaSelecionada.EditarSala(salaTemporaria);
                    }
                }
            });
        }


        public void IniciaComandosFilmes()
        {
            AddFilme = new RelayCommand((object_) =>
            {
                FilmeView telaFilme = new FilmeView();

                Filme novoFilme = new Filme();

                telaFilme.DataContext = novoFilme;

                if (telaFilme.ShowDialog().Equals(true))
                {
  
                    ListaFilmes.Add(novoFilme);
                }
            });

            RemoveFilme = new RelayCommand((object_) => {

                ListaFilmes.Remove(FilmeSelecionado);

            });

            EditFilme = new RelayCommand((object_) =>
            {

                if (FilmeSelecionado != null)
                {
                    FilmeView telaFilme = new FilmeView();

                    Filme filmeTemporario = FilmeSelecionado.Clone();

                    telaFilme.DataContext = filmeTemporario;

                    if (telaFilme.ShowDialog().Equals(true))
                    {
                        FilmeSelecionado.EditarFilme(filmeTemporario);
                    }
                }
            });
        }

        public void IniciaComandosSessao()
        {
            AddSessao = new RelayCommand((object_) =>
            {
                SessaoView telaSessao = new SessaoView();

                Sessao novaSessao = new Sessao();

                telaSessao.DataContext = novaSessao;


                if (telaSessao.ShowDialog().Equals(true))
                {
                    bool verificaFilme = novaSessao.VerificarExistenciaFilme(ListaFilmes, novaSessao.CodigoFilme);
                    bool verificaSala = novaSessao.VerificarExistenciaSala(ListaSalas, novaSessao.CodigoSala);

                    if (verificaFilme && verificaSala )
                    {
                        ListaSessao.Add(novaSessao);
                    }
                    else
                    {
                        MessageBox.Show("Filme ou Sala inválidos!");
                    }
                }
            });
            RemoveSessao = new RelayCommand((object_) => {

                ListaSessao.Remove(SessaoSelecionada);

            });
            EditSessao = new RelayCommand((object_) =>
            {
                if (SessaoSelecionada != null)
                {
                    SessaoView telaSessao = new SessaoView();

                    Sessao sessaoTemporaria = SessaoSelecionada.Clone();

                    telaSessao.DataContext = sessaoTemporaria;

                    if (telaSessao.ShowDialog().Equals(true))
                    {
                        bool verificaFilme = sessaoTemporaria.VerificarExistenciaFilme(ListaFilmes, sessaoTemporaria.CodigoFilme);
                        bool verificaSala = sessaoTemporaria.VerificarExistenciaSala(ListaSalas, sessaoTemporaria.CodigoSala);

                        if (verificaFilme && verificaSala)
                        {
                            SessaoSelecionada.EditarSessao(sessaoTemporaria);
                        }
                        else
                        {
                            MessageBox.Show("Filme ou Sala inválidos!");
                        }
                    }
                }
            });
        }
        
    }
}
