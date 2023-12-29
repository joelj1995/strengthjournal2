using Microsoft.Data.SqlClient;

namespace api.Services.Database
{
    public class StrengthJournalDatabaseConnection
    {
        public StrengthJournalDatabaseConnection(IDatabaseConnectionStringProvider connectionStringProvider)
        {
            this.connectionStringProvider = connectionStringProvider;
        }

        public SqlConnection Open()
        {
            return new SqlConnection(connectionStringProvider.Connection);
        }

        private IDatabaseConnectionStringProvider connectionStringProvider;
    }
}
