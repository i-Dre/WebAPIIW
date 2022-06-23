using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeService.DataRepository.Migrations
{
    public partial class Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buyer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    BuyerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SalesPointId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAmount = table.Column<float>(type: "real", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesPoint",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvidedProducts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesPoint", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Buyer",
                columns: new[] { "Id", "IsDeleted", "Name", "SalesIds" },
                values: new object[,]
                {
                    { new Guid("b0000001-e3ea-4063-9089-48cffd3f56bc"), false, "Роман Васильев", "[]" },
                    { new Guid("b0000002-479c-4e1f-a55c-2220e913d934"), false, "Игорь Вернов", "[]" },
                    { new Guid("b0000003-b0c4-4267-96e6-fe74ffe21424"), false, "Надежда Иванова", "[]" },
                    { new Guid("b0000004-ac13-47dc-b614-fc06ebf47c9b"), false, "Кирилл Сергеев", "[]" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "IsDeleted", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("a0000001-17c3-4fcc-8cbf-03a9cdfcee4c"), false, "Лампочка", 100f },
                    { new Guid("a0000002-188c-4fc9-8311-37e7eff4dbcf"), false, "Фонарик", 435f },
                    { new Guid("a0000003-df02-43a6-8d2a-0106062d5ac9"), false, "Люстра", 3153f },
                    { new Guid("a0000004-9106-413d-b45a-ac98be9bb38d"), false, "Розетка", 150f }
                });

            migrationBuilder.InsertData(
                table: "SalesPoint",
                columns: new[] { "Id", "IsDeleted", "Name", "ProvidedProducts" },
                values: new object[,]
                {
                    { new Guid("af000001-1644-4188-a3ff-3dd392de686e"), false, "Электрон", "[{\"ProductId\":\"a0000001-17c3-4fcc-8cbf-03a9cdfcee4c\",\"ProductQuantity\":130},{\"ProductId\":\"a0000002-188c-4fc9-8311-37e7eff4dbcf\",\"ProductQuantity\":25}]" },
                    { new Guid("af000002-ca00-4c80-8581-63ecc5ae86cb"), false, "Планета 220", "[{\"ProductId\":\"a0000001-17c3-4fcc-8cbf-03a9cdfcee4c\",\"ProductQuantity\":65},{\"ProductId\":\"a0000004-9106-413d-b45a-ac98be9bb38d\",\"ProductQuantity\":3}]" },
                    { new Guid("af000003-41bc-4f79-84f9-db1c6507c95c"), false, "220v", "[{\"ProductId\":\"a0000002-188c-4fc9-8311-37e7eff4dbcf\",\"ProductQuantity\":34},{\"ProductId\":\"a0000003-df02-43a6-8d2a-0106062d5ac9\",\"ProductQuantity\":5},{\"ProductId\":\"a0000004-9106-413d-b45a-ac98be9bb38d\",\"ProductQuantity\":60}]" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buyer");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropTable(
                name: "SalesPoint");
        }
    }
}
