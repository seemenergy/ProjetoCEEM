namespace ProjetoCEEM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        Login = c.String(maxLength: 100, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        Senha = c.String(maxLength: 100, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        DataInativacao = c.DateTime(nullable: false),
                        DataInicioBloqueio = c.DateTime(nullable: false),
                        DataFimBloqueio = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contato",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        TipoContatoId = c.Int(nullable: false),
                        Descricao = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoContato", t => t.TipoContatoId)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .Index(t => t.UsuarioId)
                .Index(t => t.TipoContatoId);
            
            CreateTable(
                "dbo.TipoContato",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Equipamento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        QuantPontoMax = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PontoMedida",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        DataMedida = c.DateTime(nullable: false),
                        MedidaCorrente = c.Double(nullable: false),
                        MedidaTensao = c.Double(nullable: false),
                        EquipamentoId = c.Int(nullable: false),
                        DataHoraBandeiraId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipamento", t => t.EquipamentoId)
                .Index(t => t.EquipamentoId);
            
            CreateTable(
                "dbo.DataHoraBandeira",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Verao = c.Boolean(nullable: false),
                        Inicio = c.DateTime(nullable: false),
                        Fim = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DataHoraBandeiraTarifa",
                c => new
                    {
                        DataHoraBandeiraId = c.Int(nullable: false),
                        BandeiraTarifaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DataHoraBandeiraId, t.BandeiraTarifaId })
                .ForeignKey("dbo.DataHoraBandeira", t => t.DataHoraBandeiraId)
                .Index(t => t.DataHoraBandeiraId);
            
            CreateTable(
                "dbo.DataHoraBandeiraPontoMedida",
                c => new
                    {
                        DataHoraBandeira_Id = c.Int(nullable: false),
                        PontoMedida_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DataHoraBandeira_Id, t.PontoMedida_Id })
                .ForeignKey("dbo.DataHoraBandeira", t => t.DataHoraBandeira_Id)
                .ForeignKey("dbo.PontoMedida", t => t.PontoMedida_Id)
                .Index(t => t.DataHoraBandeira_Id)
                .Index(t => t.PontoMedida_Id);
            
            CreateTable(
                "dbo.EquipamentoUsuario",
                c => new
                    {
                        Equipamento_Id = c.Int(nullable: false),
                        Usuario_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Equipamento_Id, t.Usuario_Id })
                .ForeignKey("dbo.Equipamento", t => t.Equipamento_Id)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id)
                .Index(t => t.Equipamento_Id)
                .Index(t => t.Usuario_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EquipamentoUsuario", "Usuario_Id", "dbo.Usuario");
            DropForeignKey("dbo.EquipamentoUsuario", "Equipamento_Id", "dbo.Equipamento");
            DropForeignKey("dbo.PontoMedida", "EquipamentoId", "dbo.Equipamento");
            DropForeignKey("dbo.DataHoraBandeiraPontoMedida", "PontoMedida_Id", "dbo.PontoMedida");
            DropForeignKey("dbo.DataHoraBandeiraPontoMedida", "DataHoraBandeira_Id", "dbo.DataHoraBandeira");
            DropForeignKey("dbo.DataHoraBandeiraTarifa", "DataHoraBandeiraId", "dbo.DataHoraBandeira");
            DropForeignKey("dbo.Endereco", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Contato", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Contato", "TipoContatoId", "dbo.TipoContato");
            DropIndex("dbo.EquipamentoUsuario", new[] { "Usuario_Id" });
            DropIndex("dbo.EquipamentoUsuario", new[] { "Equipamento_Id" });
            DropIndex("dbo.DataHoraBandeiraPontoMedida", new[] { "PontoMedida_Id" });
            DropIndex("dbo.DataHoraBandeiraPontoMedida", new[] { "DataHoraBandeira_Id" });
            DropIndex("dbo.DataHoraBandeiraTarifa", new[] { "DataHoraBandeiraId" });
            DropIndex("dbo.PontoMedida", new[] { "EquipamentoId" });
            DropIndex("dbo.Endereco", new[] { "UsuarioId" });
            DropIndex("dbo.Contato", new[] { "TipoContatoId" });
            DropIndex("dbo.Contato", new[] { "UsuarioId" });
            DropTable("dbo.EquipamentoUsuario");
            DropTable("dbo.DataHoraBandeiraPontoMedida");
            DropTable("dbo.DataHoraBandeiraTarifa");
            DropTable("dbo.DataHoraBandeira");
            DropTable("dbo.PontoMedida");
            DropTable("dbo.Equipamento");
            DropTable("dbo.Endereco");
            DropTable("dbo.TipoContato");
            DropTable("dbo.Contato");
            DropTable("dbo.Usuario");
        }
    }
}
