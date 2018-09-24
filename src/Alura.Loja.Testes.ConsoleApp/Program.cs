using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //GravarUsandoAdoNet();
            GravarUsandoEntity();
        }

        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var contexto = new LojaContext())
            {
                contexto.Produtos.Add(p);
                contexto.SaveChanges();
                /*
                exec sp_executesql N'SET NOCOUNT ON;
                    INSERT INTO [Produtos] ([Categoria], [Nome], [Preco])
                    VALUES (@p0, @p1, @p2);
                    SELECT [Id]
                    FROM [Produtos]
                    WHERE @@ROWCOUNT = 1 AND [Id] = scope_identity();

                    ',N'@p0 nvarchar(4000),@p1 nvarchar(4000),@p2 float',
                    @p0=N'Livros',
                    @p1=N'Harry Potter e a Ordem da Fênix',
                    @p2=19,890000000000001 
                */
            }
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
                /*
                 exec sp_executesql N'INSERT INTO Produtos (Nome, Categoria, Preco) VALUES (@nome, @categoria, @preco)',
                 N'@nome nvarchar(31),@categoria nvarchar(6),@preco float',
                 @nome=N'Harry Potter e a Ordem da Fênix',
                 @categoria=N'Livros',
                 @preco=19,890000000000001
                 */
            }
        }
    }
}
