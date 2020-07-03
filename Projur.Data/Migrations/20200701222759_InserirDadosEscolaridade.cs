using Microsoft.EntityFrameworkCore.Migrations;

namespace Projur.Data.Migrations
{
    public partial class InserirDadosEscolaridade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"
                IF NOT EXISTS(SELECT TOP 1 1 FROM Escolaridades)
                BEGIN
                    SET IDENTITY_INSERT Escolaridades ON
                        INSERT INTO Escolaridades 
                            (EscolaridadeId, Descricao, Ativo, DtCriacao)
                        VALUES
                            ('1', 'Infantil', 1, GETDATE()),
                            ('2', 'Fundamental', 1, GETDATE()),
                            ('3', 'Médio', 1, GETDATE()),
                            ('4', 'Superior', 1, GETDATE())
                    SET IDENTITY_INSERT Escolaridades OFF
                END

                GO
            ";

            migrationBuilder.Sql(sql, true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sql = @"
                IF EXISTS(SELECT TOP 1 1 FROM Escolaridades)
                BEGIN
                    DELETE FROM Escolaridades
                END

                GO
            ";

            migrationBuilder.Sql(sql, true);
        }
    }
}
