using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace electroinc_blood_bank.Migrations
{
    /// <inheritdoc />
    public partial class editeorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Hospitals_HospitalID",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "HospitalID",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "orderFor",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "orderForID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Hospitals_HospitalID",
                table: "Orders",
                column: "HospitalID",
                principalTable: "Hospitals",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Hospitals_HospitalID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "orderFor",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "orderForID",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "HospitalID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Hospitals_HospitalID",
                table: "Orders",
                column: "HospitalID",
                principalTable: "Hospitals",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
