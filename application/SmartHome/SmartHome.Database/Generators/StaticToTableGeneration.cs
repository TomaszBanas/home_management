using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Database.Generators
{
    public static class StaticToTableGeneration
    {
        public static void CreateValuesFromEnum<T>(this MigrationBuilder migrationBuilder, string tableName)
             where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            var values = new List<T>(Enum.GetValues(typeof(T)).Cast<T>()).Select(x => new { Key = Convert.ToInt32(x), Value = x.ToString() }).ToList();
            foreach (var value in values)
            {
                var sql = $"INSERT INTO {tableName}(Id, Key, Name, CreatedOn, CreatedBy, UpdatedOn, UpdatedBy) SELECT '{Guid.NewGuid().ToString()}', {value.Key}, '{value.Value}', DATETIME(), 'migration', DATETIME(), 'migration' WHERE NOT EXISTS(SELECT 1 FROM {tableName} WHERE Key = {value.Key});";
                migrationBuilder.Sql(sql);
            } 
        }
    }
}
