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
        public List<IngredientsDB> GetAll()
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
                            Description = DbUtils.GetString(reader, "IngredientsDescription"),
                            Brand = DbUtils.GetString(reader, "Brand"),
                            Variety = DbUtils.GetString(reader, "Variety"),
                            CategoryId = DbUtils.GetInt(reader, "CategoryId"),
                            Category = new Category()
                            {
                                Id = DbUtils.GetInt(reader, "CategoryId"),
                                CategoryName = DbUtils.GetString(reader, "CategoryName")
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

        public IngredientsDB GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT i.Id AS IngredientsId, i.Description AS IngredientsDescription, i.Brand,
                               i.Variety, i.CategoryId, i.Quantity, i.QuantityUnit, i.ContainerType, i.PantryShelfLife,
                               i.FridgeShelfLife, i.FreezerShelfLife, i.ImageLocation,

                               c.CategoryName

                          FROM IngredientsDB i
                     LEFT JOIN Category c ON c.Id = i.CategoryId
                         WHERE i.Id = @Id";
                    DbUtils.AddParameter(cmd, "@Id", id);

                    var reader = cmd.ExecuteReader();

                    IngredientsDB ingredient = null;

                    if (reader.Read())
                    {
                        ingredient = new IngredientsDB()
                        {
                            Id = DbUtils.GetInt(reader, "IngredientsId"),
                            Description = DbUtils.GetString(reader, "IngredientsDescription"),
                            Brand = DbUtils.GetString(reader, "Brand"),
                            Variety = DbUtils.GetString(reader, "Variety"),
                            CategoryId = DbUtils.GetInt(reader, "CategoryId"),
                            Category = new Category()
                            {
                                Id = DbUtils.GetInt(reader, "CategoryId"),
                                CategoryName = DbUtils.GetString(reader, "CategoryName")
                            },
                            Quantity = DbUtils.GetDec(reader, "Quantity"),
                            QuantityUnit = DbUtils.GetString(reader, "QuantityUnit"),
                            PantryShelfLife = DbUtils.GetInt(reader, "PantryShelfLife"),
                            FridgeShelfLife = DbUtils.GetInt(reader, "FridgeShelfLife"),
                            FreezerShelfLife = DbUtils.GetInt(reader, "FreezerShelfLife"),
                            ImageLocation = DbUtils.GetString(reader, "ImageLocation")
                        };
                    }

                    reader.Close();
                    return ingredient;
                }
            }
        }

        public void Add(IngredientsDB ingredient)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO IngredientsDB (Description, Brand, Variety, CategoryId, Quantity, QuantityUnit,
                                                   ContainerType, PantryShelfLife, FridgeShelfLife, FreezerShelfLife,
                                                   ImageLocation)
                 OUTPUT INSERTED.ID
                             VALUES (@Description, @Brand, @Variety, @CategoryId, @Quantity, @QuantityUnit,
                                     @ContainerType, @PantryShelfLife, @FridgeShelfLife, @FreezerShelfLife,
                                     @ImageLocation);";
                    DbUtils.AddParameter(cmd, "@Description", ingredient.Description);
                    DbUtils.AddParameter(cmd, "@Brand", ingredient.Brand);
                    DbUtils.AddParameter(cmd, "@Variety", ingredient.Variety);
                    DbUtils.AddParameter(cmd, "@CategoryId", ingredient.CategoryId);
                    DbUtils.AddParameter(cmd, "@Quantity", ingredient.Quantity);
                    DbUtils.AddParameter(cmd, "@QuantityUnit", ingredient.QuantityUnit);
                    DbUtils.AddParameter(cmd, "@ContainerType", ingredient.ContainerType);
                    DbUtils.AddParameter(cmd, "@PantryShelfLife", ingredient.PantryShelfLife);
                    DbUtils.AddParameter(cmd, "@FridgeShelfLife", ingredient.FridgeShelfLife);
                    DbUtils.AddParameter(cmd, "@FreezerShelfLife", ingredient.FreezerShelfLife);
                    DbUtils.AddParameter(cmd, "@ImageLocation", ingredient.ImageLocation);

                    ingredient.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(IngredientsDB ingredient)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE IngredientsDB 
                                           SET Description = @Description,
                                               Brand = @Brand,
                                               Variety = @Variety,
                                               CategoryId = @CategoryId,
                                               Quantity = @Quantity,
                                               QuantityUnit = @QuantityUnit,
                                               ContainerTye = @ContainerTye,
                                               PantryShelfLife = @PantryShelfLife,
                                               FridgeShelfLife = @FridgeShelfLife,
                                               FreezerShelfLife = @FreezerShelfLife,
                                               ImageLocation = @ImageLocation
                                         WHERE Id = @Id;";

                    DbUtils.AddParameter(cmd, "@Description", ingredient.Description);
                    DbUtils.AddParameter(cmd, "@Brand", ingredient.Brand);
                    DbUtils.AddParameter(cmd, "@Variety", ingredient.Variety);
                    DbUtils.AddParameter(cmd, "@CategoryId", ingredient.CategoryId);
                    DbUtils.AddParameter(cmd, "@Quantity", ingredient.Quantity);
                    DbUtils.AddParameter(cmd, "@QuantityUnit", ingredient.QuantityUnit);
                    DbUtils.AddParameter(cmd, "@ContainerTye", ingredient.ContainerTye);
                    DbUtils.AddParameter(cmd, "@PantryShelfLife", ingredient.PantryShelfLife);
                    DbUtils.AddParameter(cmd, "@FridgeShelfLife", ingredient.FridgeShelfLife);
                    DbUtils.AddParameter(cmd, "@FreezerShelfLife", ingredient.FreezerShelfLife);
                    DbUtils.AddParameter(cmd, "@ImageLocation", ingredient.ImageLocation);
                    DbUtils.AddParameter(cmd, "@Id", ingredient.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
