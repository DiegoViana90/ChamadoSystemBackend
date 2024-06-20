using Microsoft.EntityFrameworkCore.Migrations;

namespace ChamadoSystemBackend.Migrations
{
    public partial class GetUsersByName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE OR REPLACE FUNCTION GetUsersByName(search_term VARCHAR)
                RETURNS TABLE (
                    id INT,
                    email VARCHAR,
                    role VARCHAR,
                    name VARCHAR
                ) AS $$
                BEGIN
                    RETURN QUERY
                    SELECT id, email, role, name
                    FROM users
                    WHERE name ILIKE '%' || search_term || '%';
                END;
                $$ LANGUAGE plpgsql;
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS search_users_by_name");
        }
    }
}
