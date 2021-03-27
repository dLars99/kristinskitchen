using Microsoft.Extensions.Configuration;
using KristinsKitchen.Models;
using System.Collections.Generic;
using GearPatch.Utils;

namespace KristinsKitchen.Repositories
{
    /// <summary>
    ///  Set of functions which interact with the Location table in the database
    /// </summary>
    public class LocationRepository : BaseRespository, ILocationRepository
    {
        public LocationRepository(IConfiguration configuration) : base(configuration) { }

        /// <summary>
        /// Method which retrieve the full list of categories
        /// </summary>
        public List<Location> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    SELECT Id, LocationName
                        FROM Location;";
                    var reader = cmd.ExecuteReader();
                    var locationList = new List<Location>();
                    while (reader.Read())
                    {
                        locationList.Add(new Location()
                        {
                            Id = DbUtils.GetInt(reader, "Id"),
                            LocationName = DbUtils.GetString(reader, "LocationName"),
                        });
                    }
                    reader.Close();
                    return locationList;
                }
            }
        }

        public Location GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    SELECT Id, LocationName
                        FROM Location
                       WHERE Id = @Id;";
                    DbUtils.AddParameter(cmd, "@Id", id);
                    var reader = cmd.ExecuteReader();
                    Location location = null;
                    if (reader.Read())
                    {
                        location = new Location()
                        {
                            Id = id,
                            LocationName = DbUtils.GetString(reader, "LocationName"),
                        };
                    }
                    reader.Close();
                    return location;
                }
            }
        }
    }
}
