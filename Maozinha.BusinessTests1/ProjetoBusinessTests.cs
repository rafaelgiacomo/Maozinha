using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maozinha.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maozinha.Model;
namespace Maozinha.Business.Tests
{
    [TestClass()]
    public class ProjetoBusinessTests
    {

        public List<ProjetoModel> CriaProjetos()
        {
            List<ProjetoModel> ListaProjetos = new List<ProjetoModel>();

            ListaProjetos.Add(new ProjetoModel { Id = 1, EntidadeId = 10, CategoriaId = 10 });
            ListaProjetos.Add(new ProjetoModel { Id = 2, EntidadeId = 10, CategoriaId = 11 });
            ListaProjetos.Add(new ProjetoModel { Id = 3, EntidadeId = 11, CategoriaId = 12 });
            ListaProjetos.Add(new ProjetoModel { Id = 4, EntidadeId = 12, CategoriaId = 13 });
            ListaProjetos.Add(new ProjetoModel { Id = 5, EntidadeId = 13, CategoriaId = 13 });



            return ListaProjetos;
        }


        [TestMethod()]
        public void SelecionarProjetoPorIdTest()
        {
            int IdTeste = 3;
            List<ProjetoModel> ProjetosTeste = CriaProjetos();

            ProjetoModel teste = ProjetosTeste.Where(x => x.Id == 3).FirstOrDefault();

            Assert.AreEqual(IdTeste, teste.Id);
            
        }

        [TestMethod()]
        public void ListarPorEntidadeTest()
        {
            int IdTeste = 2;
            List<ProjetoModel> ProjetosTeste = CriaProjetos();

            int Total = ProjetosTeste.Where(x => x.EntidadeId == 10).Count();

            Assert.AreEqual(IdTeste, Total);

        }

        [TestMethod()]
        public void InserirProjetoTest()
        {
            ProjetoModel Teste = new ProjetoModel { Id = 6, EntidadeId = 14, CategoriaId = 14 };

            List<ProjetoModel> ProjetosTeste = CriaProjetos();

            ProjetosTeste.Add(new ProjetoModel { Id = 6, EntidadeId = 14, CategoriaId = 14 });

            ProjetoModel ProjetoInserido = new ProjetoModel();
            ProjetoInserido = ProjetosTeste.Where(x => x.Id == 6).First();

            Assert.AreEqual(ProjetoInserido, Teste);

        }

        [TestMethod()]
        public void AlterarProjetoTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ExcluirProjetoTest()
        {
            Assert.Fail();
        }
    }
}