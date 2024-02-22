using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLBH.Models.Migrations
{
    /// <inheritdoc />
    public partial class Update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bill_Addess_Receive_Addess_ReceiveID",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfirmEmail_Addess_Receive_Addess_ReceiveID",
                table: "ConfirmEmail");

            migrationBuilder.DropTable(
                name: "Addess_Receive");

            migrationBuilder.RenameColumn(
                name: "Addess_ReceiveID",
                table: "ConfirmEmail",
                newName: "Address_ReceiveID");

            migrationBuilder.RenameIndex(
                name: "IX_ConfirmEmail_Addess_ReceiveID",
                table: "ConfirmEmail",
                newName: "IX_ConfirmEmail_Address_ReceiveID");

            migrationBuilder.RenameColumn(
                name: "Addess_ReceiveID",
                table: "Bill",
                newName: "Address_ReceiveID");

            migrationBuilder.RenameIndex(
                name: "IX_Bill_Addess_ReceiveID",
                table: "Bill",
                newName: "IX_Bill_Address_ReceiveID");

            migrationBuilder.CreateTable(
                name: "Address_Receive",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Full_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Describe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Confirm = table.Column<bool>(type: "bit", nullable: false),
                    AccountID = table.Column<long>(type: "bigint", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address_Receive", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Address_Receive_Account_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Account",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_Receive_AccountID",
                table: "Address_Receive",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Address_Receive_Address_ReceiveID",
                table: "Bill",
                column: "Address_ReceiveID",
                principalTable: "Address_Receive",
                principalColumn: "ID");

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
                name: "FK_Bill_Address_Receive_Address_ReceiveID",
                table: "Bill");

            migrationBuilder.DropForeignKey(
                name: "FK_ConfirmEmail_Address_Receive_Address_ReceiveID",
                table: "ConfirmEmail");

            migrationBuilder.DropTable(
                name: "Address_Receive");

            migrationBuilder.RenameColumn(
                name: "Address_ReceiveID",
                table: "ConfirmEmail",
                newName: "Addess_ReceiveID");

            migrationBuilder.RenameIndex(
                name: "IX_ConfirmEmail_Address_ReceiveID",
                table: "ConfirmEmail",
                newName: "IX_ConfirmEmail_Addess_ReceiveID");

            migrationBuilder.RenameColumn(
                name: "Address_ReceiveID",
                table: "Bill",
                newName: "Addess_ReceiveID");

            migrationBuilder.RenameIndex(
                name: "IX_Bill_Address_ReceiveID",
                table: "Bill",
                newName: "IX_Bill_Addess_ReceiveID");

            migrationBuilder.CreateTable(
                name: "Addess_Receive",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountID = table.Column<long>(type: "bigint", nullable: true),
                    Addess = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Confirm = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Describe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Full_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addess_Receive", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Addess_Receive_Account_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Account",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addess_Receive_AccountID",
                table: "Addess_Receive",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bill_Addess_Receive_Addess_ReceiveID",
                table: "Bill",
                column: "Addess_ReceiveID",
                principalTable: "Addess_Receive",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfirmEmail_Addess_Receive_Addess_ReceiveID",
                table: "ConfirmEmail",
                column: "Addess_ReceiveID",
                principalTable: "Addess_Receive",
                principalColumn: "ID");
        }
    }
}
