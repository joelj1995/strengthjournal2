namespace api.Services.Database
{
    public class EnvVarDatabaseConnectionStringProvider : IDatabaseConnectionStringProvider
    {
        public string Connection => Environment.GetEnvironmentVariable("SJ_DB_CONNECTION") 
            ?? "Server=localhost;Database=StrengthJournalDev;Trusted_Connection=True;TrustServerCertificate=True";
    }
}
