﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace electroinc_blood_bank.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Bloods", columns: new[] { "BloodRhEn", "BloodRhAr" }, values: new object[] { "1", "1" });
            migrationBuilder.InsertData("Bloods", columns: new[] { "BloodRhEn", "BloodRhAr" }, values: new object[] { "2", "2" });
            migrationBuilder.InsertData("Bloods", columns: new[] { "BloodRhEn", "BloodRhAr" }, values: new object[] { "3", "3" });
            migrationBuilder.InsertData("Bloods", columns: new[] { "BloodRhEn", "BloodRhAr" }, values: new object[] { "4", "4" });
            migrationBuilder.InsertData("Bloods", columns: new[] { "BloodRhEn", "BloodRhAr" }, values: new object[] { "5", "5" });
            migrationBuilder.InsertData("Bloods", columns: new[] { "BloodRhEn", "BloodRhAr" }, values: new object[] { "6", "6" });
            migrationBuilder.InsertData("Bloods", columns: new[] { "BloodRhEn", "BloodRhAr" }, values: new object[] { "7", "7" });
            migrationBuilder.InsertData("Bloods", columns: new[] { "BloodRhEn", "BloodRhAr" }, values: new object[] { "8", "8" });

            migrationBuilder.InsertData("BloodBanks", columns: new[] { "NameEn", "NameAr", "Address" }, values: new object[] { "Central Blood Bank", "بنك الدم الرئيسي", "شارع المستشفي , خلف جامع المطافي" });



        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
