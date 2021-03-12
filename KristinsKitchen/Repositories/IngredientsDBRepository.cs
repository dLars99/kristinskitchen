using Microsoft.Extensions.Configuration;
using KristinsKitchen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KristinsKitchen.Repositories
{
    public class IngredientsDBRepository : BaseRespository
    {
        public IngredientsDBRepository(IConfiguration configuration) : base(configuration) { }
        
        public List<IngredientsDB> GetAllIngredients()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "@";
                    var reader = cmd.ExecuteReader();
                    var ingredientList = new List<IngredientsDB>();
                    reader.Close();
                    return ingredientList;
                }
            }
        }
    }
}
