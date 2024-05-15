using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace electroinc_blood_bank.Migrations
{
    /// <inheritdoc />
    public partial class EditBloodQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonorsHistory_Donors_DonorID",
                table: "DonorsHistory");

            migrationBuilder.AlterColumn<int>(
                name: "type",
                table: "DonorsHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "DonorID",
                table: "DonorsHistory",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "type",
                table: "BloodQuantities",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_DonorsHistory_Donors_DonorID",
                table: "DonorsHistory",
                column: "DonorID",
                principalTable: "Donors",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonorsHistory_Donors_DonorID",
                table: "DonorsHistory");

            migrationBuilder.AlterColumn<string>(
                name: "type",
                table: "DonorsHistory",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DonorID",
                table: "DonorsHistory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "type",
                table: "BloodQuantities",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DonorsHistory_Donors_DonorID",
                table: "DonorsHistory",
                column: "DonorID",
                principalTable: "Donors",
                principalColumn: "ID");
        }
    }
}
