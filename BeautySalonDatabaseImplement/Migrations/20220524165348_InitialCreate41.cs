using Microsoft.EntityFrameworkCore.Migrations;

namespace BeautySalonDatabaseImplement.Migrations
{
    public partial class InitialCreate41 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Receipts_ReceiptId",
                table: "Purchases");

            migrationBuilder.AlterColumn<int>(
                name: "ReceiptId",
                table: "Purchases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Receipts_ReceiptId",
                table: "Purchases",
                column: "ReceiptId",
                principalTable: "Receipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Receipts_ReceiptId",
                table: "Purchases");

            migrationBuilder.AlterColumn<int>(
                name: "ReceiptId",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Receipts_ReceiptId",
                table: "Purchases",
                column: "ReceiptId",
                principalTable: "Receipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
