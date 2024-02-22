using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLBH.Models.Migrations
{
    /// <inheritdoc />
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    public partial class update : Migration
#pragma warning restore CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addess_Receive_Account_AccountID",
                table: "Addess_Receive");

            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Account_AccountID",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Status_Bill_Status_BillID",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Account_AccountID",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfirmEmail_Account_AccountID",
                table: "ConfirmEmail");

            migrationBuilder.DropForeignKey(
                name: "FK_Decentralization_Account_AccountID",
                table: "Decentralization");

            migrationBuilder.DropForeignKey(
                name: "FK_Decentralization_Role_RoleID",
                table: "Decentralization");

            migrationBuilder.DropForeignKey(
                name: "FK_Detail_Cart_Cart_CartID",
                table: "Detail_Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Detail_Cart_Product_ProductID",
                table: "Detail_Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Details_Product_ProductID",
                table: "Details");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedBack_Account_AccountID",
                table: "FeedBack");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedBack_Product_ProductID",
                table: "FeedBack");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageProduct_Product_ProductID",
                table: "ImageProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Details_Bill_BillID",
                table: "Invoice_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Details_Product_ProductID",
                table: "Invoice_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Account_AccountID",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_Type_Product_Product_ProductID",
                table: "Type_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_Account_AccountID",
                table: "Voucher");

            migrationBuilder.AlterColumn<long>(
                name: "AccountID",
                table: "Voucher",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ProductID",
                table: "Type_Product",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "AccountID",
                table: "Notification",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "Quantity",
                table: "Invoice_Details",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ProductID",
                table: "Invoice_Details",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "BillID",
                table: "Invoice_Details",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ProductID",
                table: "ImageProduct",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ProductID",
                table: "FeedBack",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "AccountID",
                table: "FeedBack",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ProductID",
                table: "Details",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "Quantity",
                table: "Detail_Cart",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ProductID",
                table: "Detail_Cart",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CartID",
                table: "Detail_Cart",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "RoleID",
                table: "Decentralization",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "AccountID",
                table: "Decentralization",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "AccountID",
                table: "ConfirmEmail",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "AccountID",
                table: "Cart",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "Status_BillID",
                table: "Bill",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "AccountID",
                table: "Bill",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "AccountID",
                table: "Addess_Receive",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Addess_Receive_Account_AccountID",
                table: "Addess_Receive",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Account_AccountID",
                table: "Bill",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Status_Bill_Status_BillID",
                table: "Bill",
                column: "Status_BillID",
                principalTable: "Status_Bill",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Account_AccountID",
                table: "Cart",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfirmEmail_Account_AccountID",
                table: "ConfirmEmail",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Decentralization_Account_AccountID",
                table: "Decentralization",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Decentralization_Role_RoleID",
                table: "Decentralization",
                column: "RoleID",
                principalTable: "Role",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Detail_Cart_Cart_CartID",
                table: "Detail_Cart",
                column: "CartID",
                principalTable: "Cart",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Detail_Cart_Product_ProductID",
                table: "Detail_Cart",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Details_Product_ProductID",
                table: "Details",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBack_Account_AccountID",
                table: "FeedBack",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBack_Product_ProductID",
                table: "FeedBack",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageProduct_Product_ProductID",
                table: "ImageProduct",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Details_Bill_BillID",
                table: "Invoice_Details",
                column: "BillID",
                principalTable: "Bill",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Details_Product_ProductID",
                table: "Invoice_Details",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Account_AccountID",
                table: "Notification",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Type_Product_Product_ProductID",
                table: "Type_Product",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_Account_AccountID",
                table: "Voucher",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addess_Receive_Account_AccountID",
                table: "Addess_Receive");

            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Account_AccountID",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Status_Bill_Status_BillID",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Account_AccountID",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfirmEmail_Account_AccountID",
                table: "ConfirmEmail");

            migrationBuilder.DropForeignKey(
                name: "FK_Decentralization_Account_AccountID",
                table: "Decentralization");

            migrationBuilder.DropForeignKey(
                name: "FK_Decentralization_Role_RoleID",
                table: "Decentralization");

            migrationBuilder.DropForeignKey(
                name: "FK_Detail_Cart_Cart_CartID",
                table: "Detail_Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Detail_Cart_Product_ProductID",
                table: "Detail_Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Details_Product_ProductID",
                table: "Details");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedBack_Account_AccountID",
                table: "FeedBack");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedBack_Product_ProductID",
                table: "FeedBack");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageProduct_Product_ProductID",
                table: "ImageProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Details_Bill_BillID",
                table: "Invoice_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Details_Product_ProductID",
                table: "Invoice_Details");

            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Account_AccountID",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_Type_Product_Product_ProductID",
                table: "Type_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_Account_AccountID",
                table: "Voucher");

            migrationBuilder.AlterColumn<long>(
                name: "AccountID",
                table: "Voucher",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProductID",
                table: "Type_Product",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AccountID",
                table: "Notification",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Quantity",
                table: "Invoice_Details",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProductID",
                table: "Invoice_Details",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "BillID",
                table: "Invoice_Details",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProductID",
                table: "ImageProduct",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProductID",
                table: "FeedBack",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AccountID",
                table: "FeedBack",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProductID",
                table: "Details",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Quantity",
                table: "Detail_Cart",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProductID",
                table: "Detail_Cart",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CartID",
                table: "Detail_Cart",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "RoleID",
                table: "Decentralization",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AccountID",
                table: "Decentralization",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AccountID",
                table: "ConfirmEmail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AccountID",
                table: "Cart",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Status_BillID",
                table: "Bill",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AccountID",
                table: "Bill",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AccountID",
                table: "Addess_Receive",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addess_Receive_Account_AccountID",
                table: "Addess_Receive",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Account_AccountID",
                table: "Bill",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Status_Bill_Status_BillID",
                table: "Bill",
                column: "Status_BillID",
                principalTable: "Status_Bill",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Account_AccountID",
                table: "Cart",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConfirmEmail_Account_AccountID",
                table: "ConfirmEmail",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Decentralization_Account_AccountID",
                table: "Decentralization",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Decentralization_Role_RoleID",
                table: "Decentralization",
                column: "RoleID",
                principalTable: "Role",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Detail_Cart_Cart_CartID",
                table: "Detail_Cart",
                column: "CartID",
                principalTable: "Cart",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Detail_Cart_Product_ProductID",
                table: "Detail_Cart",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Details_Product_ProductID",
                table: "Details",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBack_Account_AccountID",
                table: "FeedBack",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBack_Product_ProductID",
                table: "FeedBack",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageProduct_Product_ProductID",
                table: "ImageProduct",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Details_Bill_BillID",
                table: "Invoice_Details",
                column: "BillID",
                principalTable: "Bill",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Details_Product_ProductID",
                table: "Invoice_Details",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Account_AccountID",
                table: "Notification",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Type_Product_Product_ProductID",
                table: "Type_Product",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_Account_AccountID",
                table: "Voucher",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
