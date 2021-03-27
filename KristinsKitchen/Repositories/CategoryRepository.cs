using Microsoft.Extensions.Configuration;
using KristinsKitchen.Models;
using System.Collections.Generic;
using GearPatch.Utils;

namespace KristinsKitchen.Repositories
{
    /// <summary>
    ///  Set of functions which interact with the Category table in the database
    /// </summary>
    public class CategoryRepository : BaseRespository, ICategoryRepository
    {
        public CategoryRepository(IConfiguration configuration) : base(configuration) { }

        /// <summary>
        /// Method which retrieve the full list of categories
        /// </summary>
        public List<Category> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    SELECT Id, CategoryName
                        FROM Category;";
                    var reader = cmd.ExecuteReader();
                    var categoryList = new List<Category>();
                    while (reader.Read())
                    {
                        categoryList.Add(new Category()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            CategoryName = DbUtils.GetString(reader, "CategoryName"),
                        });
                    }
                    reader.Close();
                    return categoryList;
                }
            }
        }

        public Category GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    SELECT Id, CategoryName
                        FROM Category
                       WHERE Id = @Id;";
                    DbUtils.AddParameter(cmd, "@Id", id);
                    var reader = cmd.ExecuteReader();
                    Category location = null;
                    if (reader.Read())
                    {
                        location = new Category()
                        {
                            Id = id,
                            CategoryName = DbUtils.GetString(reader, "CategoryName"),
                        };
                    }
                    reader.Close();
                    return location;
                }
            }
        }

    }
}
