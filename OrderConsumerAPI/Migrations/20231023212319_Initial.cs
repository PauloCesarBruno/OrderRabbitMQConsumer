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
                    DataRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(14)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Cartao = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    NumeroCartao = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    DataVencimento = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    CVV = table.Column<string>(type: "nvarchar(3)", nullable: false)
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
