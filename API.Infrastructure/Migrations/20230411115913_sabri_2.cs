using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Infrastructure.Migrations
{
    public partial class sabri_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CreatedDate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    year = table.Column<int>(type: "int", nullable: false),
                    month = table.Column<int>(type: "int", nullable: false),
                    day = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatedDate", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedId",
                table: "Products",
                column: "CreatedId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_CreatedDate_CreatedId",
                table: "Products",
                column: "CreatedId",
                principalTable: "CreatedDate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_CreatedDate_CreatedId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "CreatedDate");

            migrationBuilder.DropIndex(
                name: "IX_Products_CreatedId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedId",
                table: "Products");
        }
    }
}
