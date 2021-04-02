using Microsoft.Extensions.Configuration;
using KristinsKitchen.Models;
using System.Collections.Generic;
using GearPatch.Utils;

namespace KristinsKitchen.Repositories
{
    /// <summary>
    ///  Set of functions which interact with the user profile database, UserProfile
    /// </summary>
    public class UserProfileRepository : BaseRespository, IUserProfileRepository
    {
        public UserProfileRepository(IConfiguration configuration) : base(configuration) { }

        /// <summary>
        /// Method which retrieves the full details for a single user
        /// </summary>
        public UserProfile GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, UserName, Email, ImageLocation, IsActive

                          FROM UserProfile
                         WHERE Id = @Id;";
                    DbUtils.AddParameter(cmd, "@Id", id);

                    var reader = cmd.ExecuteReader();

                    UserProfile userProfile = null;

                    if (reader.Read())
                    {
                        userProfile = new UserProfile()
                        {
                            Id = id,
                            UserName = DbUtils.GetString(reader, "UserName"),
                            Email = DbUtils.GetString(reader, "Email"),
                            ImageLocation = DbUtils.GetString(reader, "ImageLocation"),
                            IsActive = DbUtils.GetBool(reader, "IsActive")
                        };
                    }

                    reader.Close();
                    return userProfile;
                }
            }
        }

        /// <summary>
        /// Method to add a new user to the database
        /// </summary>
        public void Add(UserProfile userProfile)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO UserProfile (UserName, Email, ImageLocation, IsActive
                 OUTPUT INSERTED.ID
                             VALUES (@UserName, @Email, @EmailUnit, @ImageLocation, @IsActive);";
                    DbUtils.AddParameter(cmd, "@UserName", userProfile.UserName);
                    DbUtils.AddParameter(cmd, "@Email", userProfile.Email);
                    DbUtils.AddParameter(cmd, "@ImageLocation", userProfile.ImageLocation);
                    DbUtils.AddParameter(cmd, "@IsActive", userProfile.IsActive);

                    userProfile.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// Method which updates the details for a user
        /// </summary>
        public void Update(UserProfile userProfile)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE UserProfile 
                                           SET UserName = @UserName,
                                               Email = @Email,
                                               ImageLocation = @ImageLocation,
                                               IsActive = IsActive,
                                         WHERE Id = @Id;";

                    DbUtils.AddParameter(cmd, "@UserName", userProfile.UserName);
                    DbUtils.AddParameter(cmd, "@Email", userProfile.Email);
                    DbUtils.AddParameter(cmd, "@ImageLocation", userProfile.ImageLocation);
                    DbUtils.AddParameter(cmd, "@IsActive", userProfile.IsActive);
                    DbUtils.AddParameter(cmd, "@Id", userProfile.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
