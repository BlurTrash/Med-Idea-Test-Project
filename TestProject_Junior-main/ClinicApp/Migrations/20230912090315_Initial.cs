using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClinicApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientCardDbSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientCardDbSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestDbSet",
                columns: table => new
                {
                    RequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateOfRequest = table.Column<DateTime>(nullable: false),
                    PatientId = table.Column<int>(nullable: false),
                    Purpose = table.Column<string>(nullable: true),
                    RequestType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestDbSet", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_RequestDbSet_PatientCardDbSet_PatientId",
                        column: x => x.PatientId,
                        principalTable: "PatientCardDbSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestDbSet_PatientId",
                table: "RequestDbSet",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestDbSet");

            migrationBuilder.DropTable(
                name: "PatientCardDbSet");
        }
    }
}
