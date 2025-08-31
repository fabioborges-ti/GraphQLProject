using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GraphQLProject.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartySize = table.Column<int>(type: "int", nullable: false),
                    SpecialRequest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReservationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_Categories_CategoryModelId",
                        column: x => x.CategoryModelId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "massas.jpg", "Massas" },
                    { 2, "carnes.jpg", "Carnes" },
                    { 3, "saladas.jpg", "Saladas" },
                    { 4, "peixes.jpg", "Peixes" },
                    { 5, "sobremesas.jpg", "Sobremesas" }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "Id", "CategoryId", "CategoryModelId", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, null, "Pizza tradicional com molho de tomate, mussarela e manjericão fresco", null, "Pizza Margherita", 45.899999999999999 },
                    { 2, 3, null, "Alface romana, croutons, parmesão e molho caesar tradicional", null, "Salada Caesar", 28.899999999999999 },
                    { 3, 1, null, "Lasanha tradicional com molho bolonhesa, bechamel e queijo gratinado", null, "Lasanha Bolonhesa", 38.75 },
                    { 4, 4, null, "Filé de salmão grelhado com legumes salteados e molho de ervas", null, "Salmão Grelhado", 65.0 },
                    { 5, 5, null, "Sobremesa italiana com café, mascarpone e cacau em pó", null, "Tiramisù", 18.899999999999999 },
                    { 6, 2, null, "Corte especial de bife ancho grelhado, acompanhado de batatas rústicas e molho chimichurri", null, "Bife Ancho Grelhado", 59.899999999999999 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerName", "Email", "PartySize", "PhoneNumber", "ReservationDate", "SpecialRequest" },
                values: new object[,]
                {
                    { 1, "João Silva", "joao.silva@email.com", 2, "11999999999", new DateTime(2025, 8, 30, 19, 0, 0, 0, DateTimeKind.Unspecified), "Mesa próxima à janela" },
                    { 2, "Maria Oliveira", "maria.oliveira@email.com", 4, "11988888888", new DateTime(2025, 8, 31, 20, 30, 0, 0, DateTimeKind.Unspecified), "Cadeira para criança" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menus_CategoryModelId",
                table: "Menus",
                column: "CategoryModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
