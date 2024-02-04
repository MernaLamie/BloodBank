using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace electroinc_blood_bank.Migrations
{
    /// <inheritdoc />
    public partial class CreateNewDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodQuantities_BloodBank_BloodBankID",
                table: "BloodQuantities");

            migrationBuilder.DropForeignKey(
                name: "FK_DonorsHistory_BloodBank_BloodBankID",
                table: "DonorsHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Managers_BloodBank_BloodBankID",
                table: "Managers");

            migrationBuilder.DropForeignKey(
                name: "FK_Reciptionists_BloodBank_BloodBankId",
                table: "Reciptionists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BloodBank",
                table: "BloodBank");

            migrationBuilder.DropColumn(
                name: "bloodrh",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "BloodBank",
                newName: "BloodBanks");

            migrationBuilder.AddColumn<int>(
                name: "BloodID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DonationAmout",
                table: "DonorsHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BloodBanks",
                table: "BloodBanks",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BloodID",
                table: "Orders",
                column: "BloodID");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodQuantities_BloodBanks_BloodBankID",
                table: "BloodQuantities",
                column: "BloodBankID",
                principalTable: "BloodBanks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DonorsHistory_BloodBanks_BloodBankID",
                table: "DonorsHistory",
                column: "BloodBankID",
                principalTable: "BloodBanks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_BloodBanks_BloodBankID",
                table: "Managers",
                column: "BloodBankID",
                principalTable: "BloodBanks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Bloods_BloodID",
                table: "Orders",
                column: "BloodID",
                principalTable: "Bloods",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reciptionists_BloodBanks_BloodBankId",
                table: "Reciptionists",
                column: "BloodBankId",
                principalTable: "BloodBanks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BloodQuantities_BloodBanks_BloodBankID",
                table: "BloodQuantities");

            migrationBuilder.DropForeignKey(
                name: "FK_DonorsHistory_BloodBanks_BloodBankID",
                table: "DonorsHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Managers_BloodBanks_BloodBankID",
                table: "Managers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Bloods_BloodID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Reciptionists_BloodBanks_BloodBankId",
                table: "Reciptionists");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BloodID",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BloodBanks",
                table: "BloodBanks");

            migrationBuilder.DropColumn(
                name: "BloodID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DonationAmout",
                table: "DonorsHistory");

            migrationBuilder.RenameTable(
                name: "BloodBanks",
                newName: "BloodBank");

            migrationBuilder.AddColumn<string>(
                name: "bloodrh",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BloodBank",
                table: "BloodBank",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BloodQuantities_BloodBank_BloodBankID",
                table: "BloodQuantities",
                column: "BloodBankID",
                principalTable: "BloodBank",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DonorsHistory_BloodBank_BloodBankID",
                table: "DonorsHistory",
                column: "BloodBankID",
                principalTable: "BloodBank",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_BloodBank_BloodBankID",
                table: "Managers",
                column: "BloodBankID",
                principalTable: "BloodBank",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reciptionists_BloodBank_BloodBankId",
                table: "Reciptionists",
                column: "BloodBankId",
                principalTable: "BloodBank",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
