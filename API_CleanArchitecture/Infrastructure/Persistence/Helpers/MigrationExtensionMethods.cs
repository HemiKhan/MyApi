namespace Persistence.Helpers;
using System.Linq;
using System.Reflection;

using Microsoft.EntityFrameworkCore.Migrations;

internal static class MigrationExtensionMethods
{
    internal static void AddSqlFile(this MigrationBuilder migrationBuilder)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var sqlFiles = assembly.GetManifestResourceNames().
                    Where(file => file.EndsWith(".sql"));
        foreach (var sqlFile in sqlFiles)
        {
            using var stream = assembly.GetManifestResourceStream(sqlFile);
            using var reader = new StreamReader(stream!);
            var sqlScript = reader.ReadToEnd();
            migrationBuilder.Sql($"EXEC(N'{sqlScript.Replace("'", "''")}')");
        }
    }
}
