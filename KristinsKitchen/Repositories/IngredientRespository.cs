using Microsoft.Extensions.Configuration;
using KristinsKitchen.Models;
using System.Collections.Generic;
using GearPatch.Utils;

namespace KristinsKitchen.Repositories
{
    /// <summary>
    ///  Set of functions which interact with the user ingredients database, Ingredient
    /// </summary>
    public class IngredientRepository : BaseRespository, IIngredientRepository
    {
        public IngredientRepository(IConfiguration configuration) : base(configuration) { }

        /// <summary>
        /// Method which retrieves the full list of ingredients owned by a given user
        /// </summary>
        public List<Ingredient> GetAllByUser(int userId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT i.Id AS IngredientId, i.IngredientsDBId, i.OwnQuantity,
                               i.OwnQuantityUnit, i.ExpirationDate, i.LocationId, i.UserProfileId,

                               iDB.Description, iDB.CategoryId, iDB.ImageLocation,                       
                               
                               c.CategoryName,

                               l.LocationName

                          FROM Ingredient i
                     LEFT JOIN Location l ON l.Id = i.LocationId
                     LEFT JOIN IngredientsDB iDB on iDB.Id = i.IngredientsDBId
                     LEFT JOIN Category c on c.Id = iDB.CategoryId
                         WHERE i.UserProfileId = @UserProfileId";
                    DbUtils.AddParameter(cmd, "@UserProfileId", userId);

                    var reader = cmd.ExecuteReader();
                    var ingredientList = new List<Ingredient>();
                    while (reader.Read())
                    {
                        ingredientList.Add(new Ingredient()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            IngredientsDBId = DbUtils.GetInt(reader, "IngredientsDBId"),
                            IngredientsDB = new IngredientsDB()
                            {
                                Id = DbUtils.GetInt(reader, "IngredientsDBId"),
                                Description = DbUtils.GetString(reader, "Description"),
                                CategoryId = DbUtils.GetInt(reader, "CategoryId"),
                                Category = new Category()
                                {
                                    Id = DbUtils.GetInt(reader, "CategoryId"),
                                    CategoryName = DbUtils.GetString(reader, "CategoryName")
                                },
                                ImageLocation = DbUtils.GetString(reader, "ImageLocation")
                            },
                            OwnQuantity = DbUtils.GetDec(reader, "OwnQuantity"),
                            OwnQuantityUnit = DbUtils.GetString(reader, "OwnQuantityUnit"),
                            ExpirationDate = DbUtils.GetDateTime(reader, "ExpirationDate"),
                            LocationId = DbUtils.GetInt(reader, "LocationId"),
                            Location = new Location()
                            {
                                Id = DbUtils.GetInt(reader, "LocationId"),
                                LocationName = DbUtils.GetString(reader, "LocationName")
                            },
                            UserProfileId = userId
                        });
                    }
                    reader.Close();
                    return ingredientList;
                }
            }
        }

        /// <summary>
        /// Method which retrieves the full details for a single ingredient
        /// </summary>
        public Ingredient GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT i.Id AS IngredientId, i.IngredientsDBId, i.OwnQuantity, i.OwnQuantityUnit, 
                               i.PurchaseDate, i.ExpirationDate, i.LocationId, i.UserProfileId,

                               iDB.Description, iDB.Brand, iDB.Variety, iDB.CategoryId, iDB.Quantity, iDB.QuantityUnit,
                               iDB.ContainerType, iDB.PantryShelfLife, iDB.FridgeShelfLife, iDB.FreezerShelfLife, iDB.ImageLocation,                       
                               
                               c.CategoryName,

                               l.LocationName

                          FROM Ingredient i
                     LEFT JOIN Location l ON l.Id = i.LocationId
                     LEFT JOIN IngredientsDB iDB on iDB.Id = i.IngredientsDBId
                     LEFT JOIN Category c on c.Id = iDB.CategoryId
                         WHERE i.Id = @Id;";
                    DbUtils.AddParameter(cmd, "@Id", id);

                    var reader = cmd.ExecuteReader();

                    Ingredient ingredient = null;

                    if (reader.Read())
                    {
                        ingredient = new Ingredient()
                        {
                            Id = id,
                            IngredientsDBId = DbUtils.GetInt(reader, "IngredientsDBId"),
                            IngredientsDB = new IngredientsDB()
                            {
                                Id = DbUtils.GetInt(reader, "IngredientsDBId"),
                                Description = DbUtils.GetString(reader, "Description"),
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
                                ContainerType = DbUtils.GetString(reader, "ContainerType"),
                                PantryShelfLife = DbUtils.GetInt(reader, "PantryShelfLife"),
                                FridgeShelfLife = DbUtils.GetInt(reader, "FridgeShelfLife"),
                                FreezerShelfLife = DbUtils.GetInt(reader, "FreezerShelfLife"),
                                ImageLocation = DbUtils.GetString(reader, "ImageLocation")
                            },
                            OwnQuantity = DbUtils.GetDec(reader, "OwnQuantity"),
                            OwnQuantityUnit = DbUtils.GetString(reader, "OwnQuantityUnit"),
                            PurchaseDate = DbUtils.GetDateTime(reader, "PurchaseDate"),
                            ExpirationDate = DbUtils.GetDateTime(reader, "ExpirationDate"),
                            LocationId = DbUtils.GetInt(reader, "LocationId"),
                            Location = new Location()
                            {
                                Id = DbUtils.GetInt(reader, "LocationId"),
                                LocationName = DbUtils.GetString(reader, "LocationName")
                            },
                            UserProfileId = DbUtils.GetInt(reader, "UserProfileId")
                        };
                    }

                    reader.Close();
                    return ingredient;
                }
            }
        }

        /// <summary>
        /// Method to add a new ingredient entry owned by a user to the database
        /// </summary>
        public void Add(Ingredient ingredient)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO Ingredient (IngredientsDBId, OwnQuantity, OwnQuantityUnit, PurchaseDate, ExpirationDate,
                                                   LocationId, UserProfileId)
                 OUTPUT INSERTED.ID
                             VALUES (@IngredientsDBId, @OwnQuantity, @OwnQuantityUnit, @PurchaseDate, @ExpirationDate,
                                     @LocationId, @UserProfileId);";
                    DbUtils.AddParameter(cmd, "@IngredientsDBId", ingredient.IngredientsDBId);
                    DbUtils.AddParameter(cmd, "@OwnQuantity", ingredient.OwnQuantity);
                    DbUtils.AddParameter(cmd, "@OwnQuantityUnit", ingredient.OwnQuantityUnit);
                    DbUtils.AddParameter(cmd, "@PurchaseDate", ingredient.PurchaseDate);
                    DbUtils.AddParameter(cmd, "@ExpirationDate", ingredient.ExpirationDate);
                    DbUtils.AddParameter(cmd, "@LocationId", ingredient.LocationId);
                    DbUtils.AddParameter(cmd, "@UserProfileId", ingredient.UserProfileId);

                    ingredient.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// Method which updates the details for an ingredient owned by a user
        /// </summary>
        public void Update(Ingredient ingredient)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE Ingredient 
                                           SET IngredientsDBId = @IngredientsDBId,
                                               OwnQuantity = @OwnQuantity,
                                               OwnQuantityUnit = @OwnQuantityUnit,
                                               PurchaseDate = @PurchaseDate,
                                               ExpirationDate = @ExpirationDate,
                                               LocationId = @LocationId,
                                               UserProfileId = @UserProfileId,
                                               FridgeShelfLife = @FridgeShelfLife,
                                               FreezerShelfLife = @FreezerShelfLife,
                                               ImageLocation = @ImageLocation
                                         WHERE Id = @Id;";

                    DbUtils.AddParameter(cmd, "@IngredientsDBId", ingredient.IngredientsDBId);
                    DbUtils.AddParameter(cmd, "@OwnQuantity", ingredient.OwnQuantity);
                    DbUtils.AddParameter(cmd, "@OwnQuantityUnit", ingredient.OwnQuantityUnit);
                    DbUtils.AddParameter(cmd, "@PurchaseDate", ingredient.PurchaseDate);
                    DbUtils.AddParameter(cmd, "@ExpirationDate", ingredient.ExpirationDate);
                    DbUtils.AddParameter(cmd, "@LocationId", ingredient.LocationId);
                    DbUtils.AddParameter(cmd, "@UserProfileId", ingredient.UserProfileId);
                    DbUtils.AddParameter(cmd, "@Id", ingredient.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Method which removes a user's ingredient from the database
        /// </summary>
        public void Delete(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Ingredient Id=@Id;";
                    DbUtils.AddParameter(cmd, "@Id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
