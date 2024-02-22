using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLBH.Models.Migrations
{
    /// <inheritdoc />
    public partial class Update7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Receive_Account_AccountID",
                table: "Address_Receive");

            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Account_AccountID",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Address_Receive_Address_ReceiveID",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Status_Bill_Status_BillID",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Account_AccountID",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Product_Account_AccountID",
                table: "Comment_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Product_Product_ProductID",
                table: "Comment_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfirmEmail_Account_AccountID",
                table: "ConfirmEmail");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfirmEmail_Address_Receive_Address_ReceiveID",
                table: "ConfirmEmail");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfirmEmail_MailSetting_MailSettingID",
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
                name: "FK_Image_Comment_Comment_Product_Comment_ProductID",
                table: "Image_Comment");

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
                name: "FK_Product_Account_AccountID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductCategory_ProductCatogoryID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_RefeshToken_Account_AccountID",
                table: "RefeshToken");

            migrationBuilder.DropForeignKey(
                name: "FK_Type_Product_Product_ProductID",
                table: "Type_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_Account_AccountID",
                table: "Voucher");

            migrationBuilder.RenameColumn(
                name: "Cash",
                table: "Invoice_Details",
                newName: "UnitPrice");

            migrationBuilder.RenameColumn(
                name: "Document",
                table: "Comment_Product",
                newName: "Opinion");

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
                table: "RefeshToken",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProductCatogoryID",
                table: "Product",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Price_Sale",
                table: "Product",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AccountID",
                table: "Product",
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

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Invoice_Details",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Invoice_Details",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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
                name: "Comment_ProductID",
                table: "Image_Comment",
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
                name: "MailSettingID",
                table: "ConfirmEmail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Address_ReceiveID",
                table: "ConfirmEmail",
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
                name: "ProductID",
                table: "Comment_Product",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AccountID",
                table: "Comment_Product",
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
                name: "Address_ReceiveID",
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

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Bill",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<long>(
                name: "AccountID",
                table: "Address_Receive",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Receive_Account_AccountID",
                table: "Address_Receive",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Account_AccountID",
                table: "Bill",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Address_Receive_Address_ReceiveID",
                table: "Bill",
                column: "Address_ReceiveID",
                principalTable: "Address_Receive",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Status_Bill_Status_BillID",
                table: "Bill",
                column: "Status_BillID",
                principalTable: "Status_Bill",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Account_AccountID",
                table: "Cart",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Product_Account_AccountID",
                table: "Comment_Product",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Product_Product_ProductID",
                table: "Comment_Product",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ConfirmEmail_Account_AccountID",
                table: "ConfirmEmail",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ConfirmEmail_Address_Receive_Address_ReceiveID",
                table: "ConfirmEmail",
                column: "Address_ReceiveID",
                principalTable: "Address_Receive",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ConfirmEmail_MailSetting_MailSettingID",
                table: "ConfirmEmail",
                column: "MailSettingID",
                principalTable: "MailSetting",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Decentralization_Account_AccountID",
                table: "Decentralization",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Decentralization_Role_RoleID",
                table: "Decentralization",
                column: "RoleID",
                principalTable: "Role",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Detail_Cart_Cart_CartID",
                table: "Detail_Cart",
                column: "CartID",
                principalTable: "Cart",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Detail_Cart_Product_ProductID",
                table: "Detail_Cart",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Details_Product_ProductID",
                table: "Details",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBack_Account_AccountID",
                table: "FeedBack",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBack_Product_ProductID",
                table: "FeedBack",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Comment_Comment_Product_Comment_ProductID",
                table: "Image_Comment",
                column: "Comment_ProductID",
                principalTable: "Comment_Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageProduct_Product_ProductID",
                table: "ImageProduct",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Details_Bill_BillID",
                table: "Invoice_Details",
                column: "BillID",
                principalTable: "Bill",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Details_Product_ProductID",
                table: "Invoice_Details",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Account_AccountID",
                table: "Notification",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Account_AccountID",
                table: "Product",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCategory_ProductCatogoryID",
                table: "Product",
                column: "ProductCatogoryID",
                principalTable: "ProductCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_RefeshToken_Account_AccountID",
                table: "RefeshToken",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Type_Product_Product_ProductID",
                table: "Type_Product",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Voucher_Account_AccountID",
                table: "Voucher",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Receive_Account_AccountID",
                table: "Address_Receive");

            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Account_AccountID",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Address_Receive_Address_ReceiveID",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Status_Bill_Status_BillID",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Account_AccountID",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Product_Account_AccountID",
                table: "Comment_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Product_Product_ProductID",
                table: "Comment_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfirmEmail_Account_AccountID",
                table: "ConfirmEmail");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfirmEmail_Address_Receive_Address_ReceiveID",
                table: "ConfirmEmail");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfirmEmail_MailSetting_MailSettingID",
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
                name: "FK_Image_Comment_Comment_Product_Comment_ProductID",
                table: "Image_Comment");

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
                name: "FK_Product_Account_AccountID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductCategory_ProductCatogoryID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_RefeshToken_Account_AccountID",
                table: "RefeshToken");

            migrationBuilder.DropForeignKey(
                name: "FK_Type_Product_Product_ProductID",
                table: "Type_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Voucher_Account_AccountID",
                table: "Voucher");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Invoice_Details");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Invoice_Details");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Bill");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "Invoice_Details",
                newName: "Cash");

            migrationBuilder.RenameColumn(
                name: "Opinion",
                table: "Comment_Product",
                newName: "Document");

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
                table: "RefeshToken",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ProductCatogoryID",
                table: "Product",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "Price_Sale",
                table: "Product",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "AccountID",
                table: "Product",
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
                name: "Comment_ProductID",
                table: "Image_Comment",
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
                name: "MailSettingID",
                table: "ConfirmEmail",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "Address_ReceiveID",
                table: "ConfirmEmail",
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
                name: "ProductID",
                table: "Comment_Product",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "AccountID",
                table: "Comment_Product",
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
                name: "Address_ReceiveID",
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
                table: "Address_Receive",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Receive_Account_AccountID",
                table: "Address_Receive",
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
                name: "FK_Bill_Address_Receive_Address_ReceiveID",
                table: "Bill",
                column: "Address_ReceiveID",
                principalTable: "Address_Receive",
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
                name: "FK_Comment_Product_Account_AccountID",
                table: "Comment_Product",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Product_Product_ProductID",
                table: "Comment_Product",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfirmEmail_Account_AccountID",
                table: "ConfirmEmail",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfirmEmail_Address_Receive_Address_ReceiveID",
                table: "ConfirmEmail",
                column: "Address_ReceiveID",
                principalTable: "Address_Receive",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfirmEmail_MailSetting_MailSettingID",
                table: "ConfirmEmail",
                column: "MailSettingID",
                principalTable: "MailSetting",
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
                name: "FK_Image_Comment_Comment_Product_Comment_ProductID",
                table: "Image_Comment",
                column: "Comment_ProductID",
                principalTable: "Comment_Product",
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
                name: "FK_Product_Account_AccountID",
                table: "Product",
                column: "AccountID",
                principalTable: "Account",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCategory_ProductCatogoryID",
                table: "Product",
                column: "ProductCatogoryID",
                principalTable: "ProductCategory",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_RefeshToken_Account_AccountID",
                table: "RefeshToken",
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
    }
}
