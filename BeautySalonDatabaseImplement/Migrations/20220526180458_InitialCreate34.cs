using Microsoft.EntityFrameworkCore.Migrations;

namespace BeautySalonDatabaseImplement.Migrations
{
    public partial class InitialCreate34 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReceipt_Purchases_PurchaseId",
                table: "PurchaseReceipt");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReceipt_Receipts_ReceiptId",
                table: "PurchaseReceipt");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseReceipt",
                table: "PurchaseReceipt");

            migrationBuilder.RenameTable(
                name: "PurchaseReceipt",
                newName: "PurchaseReceipts");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseReceipt_ReceiptId",
                table: "PurchaseReceipts",
                newName: "IX_PurchaseReceipts_ReceiptId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseReceipt_PurchaseId",
                table: "PurchaseReceipts",
                newName: "IX_PurchaseReceipts_PurchaseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseReceipts",
                table: "PurchaseReceipts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReceipts_Purchases_PurchaseId",
                table: "PurchaseReceipts",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReceipts_Receipts_ReceiptId",
                table: "PurchaseReceipts",
                column: "ReceiptId",
                principalTable: "Receipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReceipts_Purchases_PurchaseId",
                table: "PurchaseReceipts");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReceipts_Receipts_ReceiptId",
                table: "PurchaseReceipts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseReceipts",
                table: "PurchaseReceipts");

            migrationBuilder.RenameTable(
                name: "PurchaseReceipts",
                newName: "PurchaseReceipt");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseReceipts_ReceiptId",
                table: "PurchaseReceipt",
                newName: "IX_PurchaseReceipt_ReceiptId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseReceipts_PurchaseId",
                table: "PurchaseReceipt",
                newName: "IX_PurchaseReceipt_PurchaseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseReceipt",
                table: "PurchaseReceipt",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReceipt_Purchases_PurchaseId",
                table: "PurchaseReceipt",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReceipt_Receipts_ReceiptId",
                table: "PurchaseReceipt",
                column: "ReceiptId",
                principalTable: "Receipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
