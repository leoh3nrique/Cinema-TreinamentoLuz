using cinema.Models;
using cinema.View;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace cinema.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<Filme> ListaFilmes { get; private set; }

        public List<Sala> ListaSalas { get; private set; }

        public List<Sessao> ListaSessao { get; private set; }

        public Filme FilmeSelecionado { get; set; }
        public Sala SalaSelecionada { get; set; }
        public Sessao SessaoSelecionada { get; set; }

        public ICommand AddFilme { get; private set; }
        public ICommand RemoveFilme { get; private set; }
        public ICommand EditFilme { get; private set; }

        public ICommand AddSala { get; private set; }
        public ICommand RemoveSala { get; private set; }
        public ICommand EditSala { get; private set; }

        public ICommand AddSessao { get; private set; }
        public ICommand RemoveSessao { get; private set; }
        public ICommand EditSessao { get; private set; }

        private MySqlDatabase database;

        public MainVM()
        {
            database = new MySqlDatabase();

            ListaFilmes = database.GetFilmes();

            ListaSalas = database.GetSalas();

            ListaSessao = database.GetSessoes();

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
                    database.AddSala(novaSala);
                    ListaSalas = database.GetSalas();
                    OnPropertyChanged("ListaSalas");
                }
            });

            RemoveSala = new RelayCommand((object_) =>
            {

                database.RemoveSala(SalaSelecionada);
                ListaSalas = database.GetSalas();
                OnPropertyChanged("ListaSalas");

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
                        database.EditaSala(salaTemporaria);
                        ListaSalas = database.GetSalas();
                        OnPropertyChanged("ListaSalas");
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

                    database.AddFilme(novoFilme);
                    ListaFilmes = database.GetFilmes();
                    OnPropertyChanged("ListaFilmes");
                }
            });

            RemoveFilme = new RelayCommand((object_) =>
            {

                database.RemoveFilme(FilmeSelecionado);
                ListaFilmes = database.GetFilmes();
                OnPropertyChanged("ListaFilmes");

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
                        database.EditaFilme(filmeTemporario);
                        ListaFilmes = database.GetFilmes();
                        OnPropertyChanged("ListaFilmes");
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


                    database.AddSessao(novaSessao);
                    ListaSessao = database.GetSessoes();
                    OnPropertyChanged("ListaSessao");

                }
            });
            RemoveSessao = new RelayCommand((object_) =>
            {

                database.RemoveSessao(SessaoSelecionada);
                ListaSessao = database.GetSessoes();
                OnPropertyChanged("ListaSessao");

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

                        database.EditaSessao(sessaoTemporaria);
                        ListaSessao = database.GetSessoes();
                        OnPropertyChanged("ListaSessao");

                    }
                }
            });
        }
    }
    }
