using System;
using System.Linq;
using Curso.Domain;
using Curso.ValueObjects;
using Microsoft.EntityFrameworkCore;


namespace CursoEFCore
{
    class Program
    {

        static void Main(string[] args)
        {
            /* Codigo para ver se possue migração pendente 
            
            using var db = new Data.ApplicationContext();

            var existe = db.DataBase.GetPendingMigrations().Any();

           if(existe)
            {

            }*/

            //InserirDados();

            InserirDadosEmMassa();
        }

        private static void InserirDadosEmMassa()
        {
            var produto = new Produto
            {
                Descricao = "Produto teste",
                CodigoBarras = "1234567891231",
                Valor = 10m,
                TipoProduto = TipoProduto.MercadoriaParaRevenda,
                Ativo = true
            };

            var cliente = new Cliente
            {
                Nome = "cliente teste",
                CEP = "19880000",
                Cidade = "Cândido Mota",
                Estado = "SP",
                Telefone = "990000111"
            };

            var listaCliente = new[]
            {
                new Cliente
                {
                    Nome = "teste 1",
                    CEP = "19880000",
                    Cidade = "Cândido Mota",
                    Estado = "SP",
                    Telefone = "990000111"
                },

                 new Cliente
                {
                    Nome = "teste 2",
                    CEP = "19880000",
                    Cidade = "Cândido Mota",
                    Estado = "SP",
                    Telefone = "990000111"
                }
            };

            using var db = new Data.ApplicationContext();
            //db.AddRange(produto, cliente);
            //db.Set<Cliente>().AddRange(listaCliente);
            db.Clientes.AddRange(listaCliente);

            var registros = db.SaveChanges();
            Console.WriteLine($"Total Registro(s): {registros}");

        }

        private static void InserirDados()
        {

            var produto = new Produto
            {
                Descricao = "Produto teste",
                CodigoBarras = "1234567891231",
                Valor = 10m,
                TipoProduto = TipoProduto.MercadoriaParaRevenda,
                Ativo = true
            };


            using var db = new Data.ApplicationContext();
            //db.Produtos.Add(produto);
            //db.Set<Produto>().Add(produto);
            //db.Entry(produto).State = EntityState.Added;
            db.Add(produto);

            var registros = db.SaveChanges();
            Console.WriteLine($"Total registro(s):  {registros}");

        }
    }
}
