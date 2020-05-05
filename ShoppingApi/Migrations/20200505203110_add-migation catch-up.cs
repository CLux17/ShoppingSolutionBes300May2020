using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingApi.Migrations
{
    public partial class addmigationcatchup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PurchasedBy",
                table: "ShoppingItems",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CurbsideOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    For = table.Column<string>(nullable: true),
                    Items = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurbsideOrders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ShoppingItems",
                columns: new[] { "Id", "Description", "Purchased", "PurchasedBy", "PurchasedFrom" },
                values: new object[] { 1, "Beer", false, null, null });

            migrationBuilder.InsertData(
                table: "ShoppingItems",
                columns: new[] { "Id", "Description", "Purchased", "PurchasedBy", "PurchasedFrom" },
                values: new object[] { 2, "Toilet Paper", true, null, "Acme" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurbsideOrders");

            migrationBuilder.DeleteData(
                table: "ShoppingItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShoppingItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "PurchasedBy",
                table: "ShoppingItems");
        }
    }
}
