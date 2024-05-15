using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace electroinc_blood_bank.Migrations
{
    /// <inheritdoc />
    public partial class Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BloodBanks",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodBanks", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Bloods",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodRhEn = table.Column<int>(type: "int", nullable: false),
                    BloodRhAr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bloods", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    BloodBankID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Managers_BloodBanks_BloodBankID",
                        column: x => x.BloodBankID,
                        principalTable: "BloodBanks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reciptionists",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    Password = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BloodBankId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reciptionists", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reciptionists_BloodBanks_BloodBankId",
                        column: x => x.BloodBankId,
                        principalTable: "BloodBanks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BloodQuantities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    BloodID = table.Column<int>(type: "int", nullable: false),
                    BloodBankID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodQuantities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BloodQuantities_BloodBanks_BloodBankID",
                        column: x => x.BloodBankID,
                        principalTable: "BloodBanks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BloodQuantities_Bloods_BloodID",
                        column: x => x.BloodID,
                        principalTable: "Bloods",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Donors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    BloodID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Donors_Bloods_BloodID",
                        column: x => x.BloodID,
                        principalTable: "Bloods",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    BloodID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Patients_Bloods_BloodID",
                        column: x => x.BloodID,
                        principalTable: "Bloods",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodAmount = table.Column<int>(type: "int", nullable: false),
                    OrderAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BloodID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ReciptionistID = table.Column<int>(type: "int", nullable: false),
                    HospitalID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.id);
                    table.ForeignKey(
                        name: "FK_Orders_Bloods_BloodID",
                        column: x => x.BloodID,
                        principalTable: "Bloods",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Hospitals_HospitalID",
                        column: x => x.HospitalID,
                        principalTable: "Hospitals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Reciptionists_ReciptionistID",
                        column: x => x.ReciptionistID,
                        principalTable: "Reciptionists",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DonorsHistory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfDonation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonationAmout = table.Column<int>(type: "int", nullable: false),
                    BloodBankID = table.Column<int>(type: "int", nullable: false),
                    BloodID = table.Column<int>(type: "int", nullable: false),
                    DonorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonorsHistory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DonorsHistory_BloodBanks_BloodBankID",
                        column: x => x.BloodBankID,
                        principalTable: "BloodBanks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonorsHistory_Bloods_BloodID",
                        column: x => x.BloodID,
                        principalTable: "Bloods",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonorsHistory_Donors_DonorID",
                        column: x => x.DonorID,
                        principalTable: "Donors",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BloodQuantities_BloodBankID",
                table: "BloodQuantities",
                column: "BloodBankID");

            migrationBuilder.CreateIndex(
                name: "IX_BloodQuantities_BloodID",
                table: "BloodQuantities",
                column: "BloodID");

            migrationBuilder.CreateIndex(
                name: "IX_Donors_BloodID",
                table: "Donors",
                column: "BloodID");

            migrationBuilder.CreateIndex(
                name: "IX_DonorsHistory_BloodBankID",
                table: "DonorsHistory",
                column: "BloodBankID");

            migrationBuilder.CreateIndex(
                name: "IX_DonorsHistory_BloodID",
                table: "DonorsHistory",
                column: "BloodID");

            migrationBuilder.CreateIndex(
                name: "IX_DonorsHistory_DonorID",
                table: "DonorsHistory",
                column: "DonorID");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_BloodBankID",
                table: "Managers",
                column: "BloodBankID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BloodID",
                table: "Orders",
                column: "BloodID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_HospitalID",
                table: "Orders",
                column: "HospitalID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ReciptionistID",
                table: "Orders",
                column: "ReciptionistID");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_BloodID",
                table: "Patients",
                column: "BloodID");

            migrationBuilder.CreateIndex(
                name: "IX_Reciptionists_BloodBankId",
                table: "Reciptionists",
                column: "BloodBankId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodQuantities");

            migrationBuilder.DropTable(
                name: "DonorsHistory");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Donors");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropTable(
                name: "Reciptionists");

            migrationBuilder.DropTable(
                name: "Bloods");

            migrationBuilder.DropTable(
                name: "BloodBanks");
        }
    }
}
