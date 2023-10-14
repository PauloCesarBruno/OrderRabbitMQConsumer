using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderConsumerAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data_Registro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MarcaAparelho = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ModeloAparelho = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Concertado = table.Column<bool>(type: "bit", nullable: false),
                    ValorConserto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orders");
        }
    }
}
