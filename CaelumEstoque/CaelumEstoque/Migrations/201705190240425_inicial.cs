namespace CaelumEstoque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoriaDoProduto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 20),
                        Preco = c.Single(nullable: false),
                        CategoriaId = c.Int(),
                        Descricao = c.String(),
                        Quantidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoriaDoProduto", t => t.CategoriaId)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Senha = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produto", "CategoriaId", "dbo.CategoriaDoProduto");
            DropIndex("dbo.Produto", new[] { "CategoriaId" });
            DropTable("dbo.Usuario");
            DropTable("dbo.Produto");
            DropTable("dbo.CategoriaDoProduto");
        }
    }
}
