﻿using Microsoft.EntityFrameworkCore.Migrations;
using VideoRentShop.Common;


#nullable disable

namespace VideoRentShop.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            //Создаю базового пользователя с Логином: admin, пароль: admin
            migrationBuilder.Sql(
               $@"
                    BEGIN
                       IF NOT EXISTS (SELECT * FROM Users 
                                       WHERE Login = 'admin')
                       BEGIN
                           insert into Users(Id, Login,Name, Password)
                            values(NEWID(), 'admin','admin', '{PasswordHelper.HashPassword("admin")}')
                       END
                    END
                    "
                ); ;
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
