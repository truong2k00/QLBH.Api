using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLBH.Models.Migrations
{
    /// <inheritdoc />
    public partial class Update8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfirmEmail_Address_Receive_Address_ReceiveID",
                table: "ConfirmEmail");

            migrationBuilder.AlterColumn<long>(
                name: "Address_ReceiveID",
                table: "ConfirmEmail",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfirmEmail_Address_Receive_Address_ReceiveID",
                table: "ConfirmEmail",
                column: "Address_ReceiveID",
                principalTable: "Address_Receive",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfirmEmail_Address_Receive_Address_ReceiveID",
                table: "ConfirmEmail");

            migrationBuilder.AlterColumn<long>(
                name: "Address_ReceiveID",
                table: "ConfirmEmail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ConfirmEmail_Address_Receive_Address_ReceiveID",
                table: "ConfirmEmail",
                column: "Address_ReceiveID",
                principalTable: "Address_Receive",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
