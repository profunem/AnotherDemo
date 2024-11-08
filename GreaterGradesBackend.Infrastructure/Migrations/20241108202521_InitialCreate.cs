using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GreaterGradesBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Institutions",
                columns: table => new
                {
                    InstitutionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutions", x => x.InstitutionId);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    InstitutionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK_Classes_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "InstitutionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InstitutionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "InstitutionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    MaxScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_Assignments_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentClass",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClass", x => new { x.ClassId, x.UserId });
                    table.ForeignKey(
                        name: "FK_StudentClass_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentClass_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeacherClass",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherClass", x => new { x.ClassId, x.UserId });
                    table.ForeignKey(
                        name: "FK_TeacherClass_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherClass_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    GradeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AssignmentId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    GradingStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.GradeId);
                    table.ForeignKey(
                        name: "FK_Grades_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grades_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Institutions",
                columns: new[] { "InstitutionId", "Address", "Name" },
                values: new object[,]
                {
                    { 1, "1600 Pennsylvania Avenue NW, Washington, DC 20500", "Institution 1" },
                    { 2, "600 1st St W, Mt Vernon, IA 52314", "Institution 2" }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "InstitutionId", "Subject" },
                values: new object[,]
                {
                    { 1, 1, "math1" },
                    { 2, 2, "math2" },
                    { 3, 1, "english1" },
                    { 4, 2, "english2" },
                    { 5, 1, "science1" },
                    { 6, 2, "science2" },
                    { 7, 1, "history1" },
                    { 8, 2, "history2" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "FirstName", "InstitutionId", "LastName", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "student1", 1, "student1", "AQAAAAIAAYagAAAAEPU7hrbFZbzo34aQQusOgavupPAOe+oAefzaG3a81nETDdUTS97epsIWi8T0IBGeaA==", 0, "student1" },
                    { 2, "student2", 2, "student2", "AQAAAAIAAYagAAAAEGg5s1+mXpS8PJUC7CV4iJQzHZFSGNRenAvb4MwpOznXqqpb89+11i9ybbgaEOU9Yg==", 0, "student2" },
                    { 3, "studentTA1", 1, "studentTA1", "AQAAAAIAAYagAAAAEKcSk6vK6IqYOcGuRfGkPdEofq2gYaddfDj0IQkNV6D4HrD308n02gtK/Omp2qancA==", 0, "studentTA1" },
                    { 4, "studentTA2", 2, "studentTA2", "AQAAAAIAAYagAAAAELLmMM9FvAELa9BVRubpRzu2fkw5X+raMXzAkrNvrTrPOH6a8WzXgTulNvc4QEAXSg==", 0, "studentTA2" },
                    { 5, "teacher1", 1, "teacher1", "AQAAAAIAAYagAAAAEGasFCX1o1EThdy1qnDyMYTri2VLT8JJvx0uTYg/Zp1VymSDVipQVN74CHEGRc4cNQ==", 1, "teacher1" },
                    { 6, "teacher2", 2, "teacher2", "AQAAAAIAAYagAAAAEBItaVgSgOB4pZgevA7wU7RCt7rwhffTKnKs7fqfnz1TmHd9KC8sjf7Pnn2sX71nkw==", 1, "teacher2" },
                    { 7, "teacherST1", 1, "teacherST1", "AQAAAAIAAYagAAAAEOD6tUR4znqn/54vVH3MPDlE8nFoYPwGeB2d5voRfkgW8z7v0IRjWltaSEXQwpAwNw==", 1, "teacherST1" },
                    { 8, "teacherST2", 2, "teacherST2", "AQAAAAIAAYagAAAAEM8i2fkdoWp69nsXoW5xl7OkRGBbf6W4DBDyRlSiuaFRpCwkoeh+Zy7vW91oH/7mjw==", 1, "teacherST2" },
                    { 9, "iadmin1", 1, "iadmin1", "AQAAAAIAAYagAAAAEB47QcvdoPRNT08cE4KMzyAT3/bvfTqQccJxgRxI8lLIUIuJYe53icImJoVBy4XtVg==", 2, "iadmin1" },
                    { 10, "iadmin2", 2, "iadmin2", "AQAAAAIAAYagAAAAEOdku0BefPr7g0c1iOvxbYw252VmxhwPgzzBcX2ByBWiilifWpBjXQA7p/asHSjHVQ==", 2, "iadmin2" },
                    { 11, "admin1", 1, "admin1", "AQAAAAIAAYagAAAAENg5KjzWBr8o38/+y2lLLqW89RD+jClLR/UFOT8EkkaRf1U7Mzz49ZLQAOzkCiAX5A==", 3, "admin1" },
                    { 12, "admin2", 2, "admin2", "AQAAAAIAAYagAAAAECR7iVg4Uymtb+0J74+z929lbTyXq1r5ThOnndcZVdQci6TJt2lJYzX6VukvQw1+0w==", 3, "admin2" }
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "AssignmentId", "ClassId", "MaxScore", "Name" },
                values: new object[,]
                {
                    { 1, 1, 100, "assignment1" },
                    { 2, 2, 100, "assignment2" },
                    { 3, 3, 100, "assignment3" },
                    { 4, 4, 100, "assignment4" },
                    { 5, 5, 100, "assignment5" },
                    { 6, 6, 100, "assignment6" },
                    { 7, 7, 100, "assignment7" },
                    { 8, 8, 100, "assignment8" }
                });

            migrationBuilder.InsertData(
                table: "StudentClass",
                columns: new[] { "ClassId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 7 },
                    { 6, 8 }
                });

            migrationBuilder.InsertData(
                table: "TeacherClass",
                columns: new[] { "ClassId", "UserId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 2, 4 },
                    { 3, 5 },
                    { 4, 6 },
                    { 5, 7 },
                    { 6, 8 }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "GradeId", "AssignmentId", "GradingStatus", "Score", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 2, 20, 1 },
                    { 2, 2, 2, 30, 2 },
                    { 3, 3, 2, 40, 3 },
                    { 4, 4, 2, 50, 4 },
                    { 5, 5, 2, 60, 7 },
                    { 6, 6, 2, 70, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_ClassId",
                table: "Assignments",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_InstitutionId",
                table: "Classes",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_AssignmentId",
                table: "Grades",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_UserId",
                table: "Grades",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClass_UserId",
                table: "StudentClass",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherClass_UserId",
                table: "TeacherClass",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_InstitutionId",
                table: "Users",
                column: "InstitutionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "StudentClass");

            migrationBuilder.DropTable(
                name: "TeacherClass");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Institutions");
        }
    }
}
