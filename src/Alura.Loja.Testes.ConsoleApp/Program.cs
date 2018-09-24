namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //GravarUsandoAdoNet();
            GravarUsandoEntity();
            GravarMuitosUsandoEntity();
        }

        private static void GravarMuitosUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            Produto p2 = new Produto();
            p2.Nome = "Senhor dos Anéis 1";
            p2.Categoria = "Livros";
            p2.Preco = 19.89;

            Produto p3 = new Produto();
            p3.Nome = "O Monge e o Executivo";
            p3.Categoria = "Livros";
            p3.Preco = 19.89;

            using (var contexto = new LojaContext())
            {
                contexto.Produtos.AddRange(p, p2, p3);
                contexto.SaveChanges();
                /*
                exec sp_executesql N'SET NOCOUNT ON;
DECLARE @toInsert0 TABLE ([Categoria] nvarchar(max), [Nome] nvarchar(max), [Preco] float, [_Position] [int]);
INSERT INTO @toInsert0
VALUES (@p0, @p1, @p2, 0),
(@p3, @p4, @p5, 1),
(@p6, @p7, @p8, 2);

DECLARE @inserted0 TABLE ([Id] int, [_Position] [int]);
MERGE [Produtos] USING @toInsert0 AS i ON 1=0
WHEN NOT MATCHED THEN
INSERT ([Categoria], [Nome], [Preco])
VALUES (i.[Categoria], i.[Nome], i.[Preco])
OUTPUT INSERTED.[Id], i._Position
INTO @inserted0;

SELECT [t].[Id] FROM [Produtos] t
INNER JOIN @inserted0 i ON ([t].[Id] = [i].[Id])
ORDER BY [i].[_Position];

',N'@p0 nvarchar(4000),@p1 nvarchar(4000),@p2 float,
@p3 nvarchar(4000),@p4 nvarchar(4000),@p5 float,
@p6 nvarchar(4000),@p7 nvarchar(4000),@p8 float',
@p0=N'Livros',@p1=N'Harry Potter e a Ordem da Fênix',@p2=19,890000000000001,
@p3=N'Livros',@p4=N'Senhor dos Anéis 1',@p5=19,890000000000001,
@p6=N'Livros',@p7=N'O Monge e o Executivo',@p8=19,890000000000001
       */
            }
        }

        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var contexto = new LojaContext())
            {
                contexto.Produtos.AddRange(p);
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
