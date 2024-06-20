using Microsoft.EntityFrameworkCore.Migrations;

namespace ChamadoSystemBackend.Migrations
{
    public partial class AddUserProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE OR REPLACE PROCEDURE InsertUser(
                    IN email TEXT,
                    IN password TEXT,
                    IN role TEXT,
                    IN name TEXT
                )
                LANGUAGE plpgsql
                AS $$
                BEGIN
                    INSERT INTO Users (Email, Password, Role, Name)
                    VALUES (email, password, role, name);
                END;
                $$;
            ");

            migrationBuilder.Sql(@"
                CREATE OR REPLACE PROCEDURE UpdateUser(
                    IN userId INT,
                    IN email TEXT,
                    IN password TEXT,
                    IN role TEXT,
                    IN name TEXT
                )
                LANGUAGE plpgsql
                AS $$
                BEGIN
                    UPDATE Users
                    SET Email = email, Password = password, Role = role, Name = name
                    WHERE Id = userId;
                END;
                $$;
            ");

            migrationBuilder.Sql(@"
                CREATE OR REPLACE PROCEDURE DeleteUser(
                    IN userId INT
                )
                LANGUAGE plpgsql
                AS $$
                BEGIN
                    DELETE FROM Users WHERE Id = userId;
                END;
                $$;
            ");

            migrationBuilder.Sql(@"
                CREATE OR REPLACE PROCEDURE GetUserById(
                    IN userId INT
                )
                LANGUAGE plpgsql
                AS $$
                BEGIN
                    SELECT Id, Email, Role, Name
                    FROM Users
                    WHERE Id = userId;
                END;
                $$;
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS InsertUser");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS UpdateUser");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS DeleteUser");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS GetUserById");
        }
    }
}
