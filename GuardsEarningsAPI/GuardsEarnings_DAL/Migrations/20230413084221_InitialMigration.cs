using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuardsEarnings_DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guards",
                columns: table => new
                {
                    GuardId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cellphone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direction = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guards", x => x.GuardId);
                });

            migrationBuilder.CreateTable(
                name: "Journeys",
                columns: table => new
                {
                    JourneyId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journeys", x => x.JourneyId);
                });

            migrationBuilder.CreateTable(
                name: "Targets",
                columns: table => new
                {
                    TargetId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Payment = table.Column<float>(type: "real", nullable: false),
                    Direction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Targets", x => x.TargetId);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    WorkId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QtyHours = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.WorkId);
                });

            migrationBuilder.CreateTable(
                name: "GuardWork",
                columns: table => new
                {
                    GuardsGuardId = table.Column<long>(type: "bigint", nullable: false),
                    WorksWorkId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuardWork", x => new { x.GuardsGuardId, x.WorksWorkId });
                    table.ForeignKey(
                        name: "FK_GuardWork_Guards_GuardsGuardId",
                        column: x => x.GuardsGuardId,
                        principalTable: "Guards",
                        principalColumn: "GuardId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuardWork_Works_WorksWorkId",
                        column: x => x.WorksWorkId,
                        principalTable: "Works",
                        principalColumn: "WorkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JourneyWork",
                columns: table => new
                {
                    JourneysJourneyId = table.Column<long>(type: "bigint", nullable: false),
                    WorksWorkId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JourneyWork", x => new { x.JourneysJourneyId, x.WorksWorkId });
                    table.ForeignKey(
                        name: "FK_JourneyWork_Journeys_JourneysJourneyId",
                        column: x => x.JourneysJourneyId,
                        principalTable: "Journeys",
                        principalColumn: "JourneyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JourneyWork_Works_WorksWorkId",
                        column: x => x.WorksWorkId,
                        principalTable: "Works",
                        principalColumn: "WorkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TargetWork",
                columns: table => new
                {
                    TargetsTargetId = table.Column<long>(type: "bigint", nullable: false),
                    WorksWorkId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TargetWork", x => new { x.TargetsTargetId, x.WorksWorkId });
                    table.ForeignKey(
                        name: "FK_TargetWork_Targets_TargetsTargetId",
                        column: x => x.TargetsTargetId,
                        principalTable: "Targets",
                        principalColumn: "TargetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TargetWork_Works_WorksWorkId",
                        column: x => x.WorksWorkId,
                        principalTable: "Works",
                        principalColumn: "WorkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuardWork_WorksWorkId",
                table: "GuardWork",
                column: "WorksWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_JourneyWork_WorksWorkId",
                table: "JourneyWork",
                column: "WorksWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_TargetWork_WorksWorkId",
                table: "TargetWork",
                column: "WorksWorkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuardWork");

            migrationBuilder.DropTable(
                name: "JourneyWork");

            migrationBuilder.DropTable(
                name: "TargetWork");

            migrationBuilder.DropTable(
                name: "Guards");

            migrationBuilder.DropTable(
                name: "Journeys");

            migrationBuilder.DropTable(
                name: "Targets");

            migrationBuilder.DropTable(
                name: "Works");
        }
    }
}
