using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Infrastructure.Migrations
{
    public partial class _9022021Loginislemleri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_userOperationClaims",
                table: "userOperationClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_operationClaims",
                table: "operationClaims");

            migrationBuilder.RenameTable(
                name: "userOperationClaims",
                newName: "UserOperationClaims");

            migrationBuilder.RenameTable(
                name: "operationClaims",
                newName: "OperationClaims");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserOperationClaims",
                table: "UserOperationClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperationClaims",
                table: "OperationClaims",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserOperationClaims",
                table: "UserOperationClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OperationClaims",
                table: "OperationClaims");

            migrationBuilder.RenameTable(
                name: "UserOperationClaims",
                newName: "userOperationClaims");

            migrationBuilder.RenameTable(
                name: "OperationClaims",
                newName: "operationClaims");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userOperationClaims",
                table: "userOperationClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_operationClaims",
                table: "operationClaims",
                column: "Id");
        }
    }
}
