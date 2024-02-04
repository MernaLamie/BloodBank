using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace electroinc_blood_bank.Migrations
{
    /// <inheritdoc />
    public partial class createDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BloodBankID",
                table: "DonorsHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DonorsHistory_BloodBankID",
                table: "DonorsHistory",
                column: "BloodBankID");

            migrationBuilder.AddForeignKey(
                name: "FK_DonorsHistory_BloodBank_BloodBankID",
                table: "DonorsHistory",
                column: "BloodBankID",
                principalTable: "BloodBank",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonorsHistory_BloodBank_BloodBankID",
                table: "DonorsHistory");

            migrationBuilder.DropIndex(
                name: "IX_DonorsHistory_BloodBankID",
                table: "DonorsHistory");

            migrationBuilder.DropColumn(
                name: "BloodBankID",
                table: "DonorsHistory");
        }
    }
}
