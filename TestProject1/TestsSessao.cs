using cinema;
using cinema.Models;
using cinema.ViewModel;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace TestsSessao
{
    public class TestsSessao
    {
        private List<Sessao> sessoes;
        private Mock<IDatabase> mockDatabase;

        [SetUp]
        public void Setup()
        {
            mockDatabase = new Mock<IDatabase>();

            mockDatabase.Setup(db => db.GetSessoes()).Returns(new List<Sessao>
            {
                new Sessao
                {
                    CodigoFilme = "F001",
                    CodigoSala = "S001",
                    Data = new DateTime(2022, 1, 1),
                    Horario = "14:00",
                    Preco = 10
                },
                new Sessao
                {
                    CodigoFilme = "F002",
                    CodigoSala = "S002",
                    Data = new DateTime(2022, 1, 2),
                    Horario = "16:00",
                    Preco = 12
                }
            });

            sessoes = mockDatabase.Object.GetSessoes();
        }
        private readonly List<Sessao> sessoesReferencia = new List<Sessao> {
        new Sessao { CodigoFilme = "F001", CodigoSala = "S001", Data = new DateTime(2022, 1, 1), Horario = "14:00", Preco = 10 },
        new Sessao { CodigoFilme = "F002", CodigoSala = "S002", Data = new DateTime(2022, 1, 2), Horario = "16:00", Preco = 12 }
    };

        [Test]
        public void TestGetSessoes()
        {
            Assert.That(sessoes, Has.Count.EqualTo(2));
            Assert.Multiple(() =>
            {
                for (int i = 0; i < sessoes.Count; i++)
                {
                    Assert.That(sessoes[i].CodigoFilme, Is.EqualTo(sessoesReferencia[i].CodigoFilme));
                    Assert.That(sessoes[i].CodigoSala, Is.EqualTo(sessoesReferencia[i].CodigoSala));
                }
            });
        }

        [Test]
        public void TestAddSessao()
        {
            mockDatabase.Setup(db => db.AddSessao(It.IsAny<Sessao>()))
                .Callback<Sessao>(sessao => sessoes.Add(sessao));

            Sessao sessao = new()
            {
                CodigoFilme = "F003",
                CodigoSala = "S003",
                Data = new DateTime(2022, 1, 3),
                Horario = "18:00",
                Preco = 14
            };

            mockDatabase.Object.AddSessao(sessao);

            sessoes = mockDatabase.Object.GetSessoes();

            Assert.That(sessoes, Has.Count.EqualTo(3));
            Assert.That(sessoes[2].CodigoFilme, Is.EqualTo("F003"));
        }

        [Test]
        public void TestRemoveSessao()
        {
            mockDatabase.Setup(db => db.RemoveSessao(It.IsAny<Sessao>()))
            .Callback<Sessao>(sessao => sessoes.Remove(sessao));

            Sessao sessao = new()
            {
                CodigoFilme = "F001",
                CodigoSala = "S001",
                Data = new DateTime(2022, 1, 1),
                Horario = "14:00",
                Preco = 10
            };

            mockDatabase.Object.RemoveSessao(sessao);

            sessoes = mockDatabase.Object.GetSessoes();

            Assert.That(sessoes.Count, Is.EqualTo(1));
            Assert.That(sessoes[0].CodigoFilme, Is.EqualTo("F002"));
        }

        [Test]
        public void TestEditaSessao()
        {
            mockDatabase.Setup(db => db.EditaSessao(It.IsAny<Sessao>()))
                .Callback<Sessao>(sessao =>
                {
                    var index = sessoes.FindIndex(s => s.CodigoFilme == sessao.CodigoFilme && s.CodigoSala == sessao.CodigoSala);

                    if (index != -1)
                    {
                        sessoes[index] = sessao;
                    }
                });

            Sessao sessao = new()
            {
                CodigoFilme = "F001",
                CodigoSala = "S001",
                Data = new DateTime(2022, 1, 4),
                Horario = "20:00",
                Preco = 16
            };

            mockDatabase.Object.EditaSessao(sessao);

            sessoes = mockDatabase.Object.GetSessoes();

            Assert.That(sessoes, Has.Count.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(sessoes[0].CodigoFilme, Is.EqualTo("F001"));
                Assert.That(sessoes[0].Data, Is.EqualTo(new DateTime(2022, 1, 4)));
                Assert.That(sessoes[0].Horario, Is.EqualTo("20:00"));
                Assert.That(sessoes[0].Preco, Is.EqualTo(16));
            });
        }


    }
}
