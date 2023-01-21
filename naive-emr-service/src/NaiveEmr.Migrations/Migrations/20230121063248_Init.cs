using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NaiveEmr.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmrDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "无意义主键"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "文档标题"),
                    JsonContent = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "文档内容（JSON）"),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "创建时间"),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmrDocuments", x => x.Id);
                },
                comment: "EMR文档");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmrDocuments");
        }
    }
}
