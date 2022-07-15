using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECinema.Web.Data.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    userId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carts", x => x.id);
                    table.ForeignKey(
                        name: "FK_carts_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tickets",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    idMovie = table.Column<int>(nullable: false),
                    priceOfTicket = table.Column<int>(nullable: false),
                    dateValid = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickets", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ticketsInCarts",
                columns: table => new
                {
                    ticketId = table.Column<Guid>(nullable: false),
                    cartId = table.Column<Guid>(nullable: false),
                    numberOfTickets = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticketsInCarts", x => new { x.ticketId, x.cartId });
                    table.ForeignKey(
                        name: "FK_ticketsInCarts_tickets_cartId",
                        column: x => x.cartId,
                        principalTable: "tickets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ticketsInCarts_carts_ticketId",
                        column: x => x.ticketId,
                        principalTable: "carts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_carts_userId",
                table: "carts",
                column: "userId",
                unique: true,
                filter: "[userId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ticketsInCarts_cartId",
                table: "ticketsInCarts",
                column: "cartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ticketsInCarts");

            migrationBuilder.DropTable(
                name: "tickets");

            migrationBuilder.DropTable(
                name: "carts");

            migrationBuilder.DropColumn(
                name: "address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "firstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "lastName",
                table: "AspNetUsers");
        }
    }
}
