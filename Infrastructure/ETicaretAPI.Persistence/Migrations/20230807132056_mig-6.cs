using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicaretAPI.Persistence.Migrations
{
    public partial class mig6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TUserTUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TUserTUser",
                columns: table => new
                {
                    followersId = table.Column<Guid>(type: "uuid", nullable: false),
                    followingId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TUserTUser", x => new { x.followersId, x.followingId });
                    table.ForeignKey(
                        name: "FK_TUserTUser_Users_followersId",
                        column: x => x.followersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TUserTUser_Users_followingId",
                        column: x => x.followingId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TUserTUser_followingId",
                table: "TUserTUser",
                column: "followingId");
        }
    }
}
