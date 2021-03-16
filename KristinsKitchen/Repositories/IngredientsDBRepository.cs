using Microsoft.Extensions.Configuration;
using KristinsKitchen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GearPatch.Utils;

namespace KristinsKitchen.Repositories
{
    /// <summary>
    ///  Set of functions which interact with the global ingredients database, IngredientsDB
    /// </summary>
    public class IngredientsDBRepository : BaseRespository, IIngredientsDBRepository
    {
        public IngredientsDBRepository(IConfiguration configuration) : base(configuration) { }

        /// <summary>
        /// Method which retrieve the full list of global ingredients
        /// </summary>
        public List<IngredientsDB> GetAllIngredients()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT i.Id AS IngredientsId, i.Description AS IngredientsDescription, i.Brand,
                               i.Variety, i.CategoryId, i.Quantity, i.QuantityUnit, i.PantryShelfLife,
                               i.FridgeShelfLife, i.FreezerShelfLife, i.ImageLocation,

                               c.CategoryName

                          FROM IngredientsDB i
                     LEFT JOIN Category c ON c.Id = i.CategoryId";
                    var reader = cmd.ExecuteReader();
                    var ingredientList = new List<IngredientsDB>();
                    while (reader.Read())
                    {
                        ingredientList.Add(new IngredientsDB()
                        {
                            Id = DbUtils.GetInt(reader, "IngredientsId"),
                            Description = DbUtils.GetString(reader, "Description"),
                            Brand = DbUtils.GetString(reader, "Brand"),
                            Variety = DbUtils.GetString(reader, "Variety"),
                            CategoryId = DbUtils.GetInt(reader, "CategoryId"),
                            Category = new Category()
                            {
                                Id = DbUtils.GetInt(reader, "CategoryId"),
                                CategoryName = DbUtils.GetString(reader, "CategoryString")
                            },
                            Quantity = DbUtils.GetDec(reader, "Quantity"),
                            QuantityUnit = DbUtils.GetString(reader, "QuantityUnit"),
                            PantryShelfLife = DbUtils.GetInt(reader, "PantryShelfLife"),
                            FridgeShelfLife = DbUtils.GetInt(reader, "FridgeShelfLife"),
                            FreezerShelfLife = DbUtils.GetInt(reader, "FreezerShelfLife"),
                            ImageLocation = DbUtils.GetString(reader, "ImageLocation")
                        });
                    }
                    reader.Close();
                    return ingredientList;
                }
            }
        }
    }
}
