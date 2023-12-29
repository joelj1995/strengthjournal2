using api.Services.Database;
using Dapper;
using Microsoft.Data.SqlClient;

namespace api.Services.User
{
    public class UserService
    {
        public UserService(StrengthJournalDatabaseConnection connection)
        {
            this.connection = connection;
        }

        public async Task<UserProfileModel> GetUserProfile(string userId)
        {
            using (var db = connection.Open())
            {
                var user = await db.QuerySingleAsync<UserProfileModel>("SELECT TOP 1 * FROM dbo.Users");
                return user;
            }
        }

        private readonly StrengthJournalDatabaseConnection connection;
    }
}
