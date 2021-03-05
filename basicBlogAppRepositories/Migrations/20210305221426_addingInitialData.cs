using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace basicBlogAppRepositories.Migrations
{
    public partial class addingInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "ID", "AddedDate", "ApprovalDate", "Approver", "Author", "Content", "ModifiedDate", "PublishDate", "Title", "WorkflowStates" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 3, 5, 17, 14, 25, 712, DateTimeKind.Local).AddTicks(9250), null, null, "Nicolas Garcia", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna ", new DateTime(2021, 3, 5, 17, 14, 25, 713, DateTimeKind.Local).AddTicks(7061), new DateTime(2021, 3, 5, 17, 14, 25, 713, DateTimeKind.Local).AddTicks(9835), "Post 1", 0 },
                    { 2, new DateTime(2021, 3, 5, 17, 14, 25, 714, DateTimeKind.Local).AddTicks(593), null, null, "Carolina Garcia", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna ", new DateTime(2021, 3, 5, 17, 14, 25, 714, DateTimeKind.Local).AddTicks(605), new DateTime(2021, 3, 5, 17, 14, 25, 714, DateTimeKind.Local).AddTicks(641), "Post 2", 0 },
                    { 3, new DateTime(2021, 3, 5, 17, 14, 25, 714, DateTimeKind.Local).AddTicks(652), null, null, "Alejandra Garcia", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna ", new DateTime(2021, 3, 5, 17, 14, 25, 714, DateTimeKind.Local).AddTicks(652), new DateTime(2021, 3, 5, 17, 14, 25, 714, DateTimeKind.Local).AddTicks(656), "Post 3", 0 },
                    { 4, new DateTime(2021, 3, 5, 17, 14, 25, 714, DateTimeKind.Local).AddTicks(656), null, null, "Trufa Garcia", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna ", new DateTime(2021, 3, 5, 17, 14, 25, 714, DateTimeKind.Local).AddTicks(656), new DateTime(2021, 3, 5, 17, 14, 25, 714, DateTimeKind.Local).AddTicks(656), "Post 4", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "ID",
                keyValue: 4);
        }
    }
}
