namespace OpenHolidaysApi.Settings
{
    public class MongoDbSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string ConnecttionString
        {
            get
            {
                return $"mongodb://{Host}:{Port}";

                //To use user-secrets:
                //dotnet user-secrets init
                //dotnet user-secrets set "MongoDbSettings:Password" "Pass#word1"
                //return $"mongodb://{User}:{Password}@{Host}:{Port}";
            }
        }
    }
}
