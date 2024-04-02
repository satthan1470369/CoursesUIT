using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoursesUIT.Migrations
{
    /// <inheritdoc />
    public partial class LMT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "CoursesUIT",
                columns: table => new
                {
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CoursesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesUIT", x => new { x.StudentId, x.CoursesId });
                    table.ForeignKey(
                        name: "FK_CoursesUIT_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursesUIT_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName", "Description" },
                values: new object[,]
                {
                    { new Guid("88738493-3a75-4443-8f6a-313453432192"), "Văn", "Tao văn trên 5 là ok rồi" },
                    { new Guid("9250d994-2557-4573-8465-417248667051"), "Toán", "IT thì nên giỏi toán:))" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Name" },
                values: new object[,]
                {
                    { new Guid("4e79044a-988d-4488-97b7-3e474e4340e2"), "x TheSpectre x" },
                    { new Guid("e2397972-8743-431a-9482-60292f08320f"), "Lê Minh Tài" }
                });

            migrationBuilder.InsertData(
                table: "CoursesUIT",
                columns: new[] { "CoursesId", "StudentId" },
                values: new object[,]
                {
                    { new Guid("9250d994-2557-4573-8465-417248667051"), new Guid("4e79044a-988d-4488-97b7-3e474e4340e2") },
                    { new Guid("88738493-3a75-4443-8f6a-313453432192"), new Guid("e2397972-8743-431a-9482-60292f08320f") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoursesUIT_CoursesId",
                table: "CoursesUIT",
                column: "CoursesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoursesUIT");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
