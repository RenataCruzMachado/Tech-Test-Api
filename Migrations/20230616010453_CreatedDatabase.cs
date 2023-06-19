using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tech_test_api.Migrations
{
    /// <inheritdoc />
    public partial class CreatedDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeAluno = table.Column<string>(type: "varchar(200)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTurma = table.Column<string>(type: "varchar(200)", nullable: false),
                    AnoLetivo = table.Column<int>(type: "int", nullable: false),
                    QtdMaximaAlunos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matricula",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    TurmaId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matricula", x => new { x.AlunoId, x.TurmaId });
                    table.ForeignKey(
                        name: "FK_Matricula_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matricula_Turma_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_TurmaId",
                table: "Matricula",
                column: "TurmaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matricula");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Turma");
        }
    }
}
