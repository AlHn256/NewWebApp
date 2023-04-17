namespace WebAppMVC.Models
{
    public class ConnectionSting
    {
        public static string Server { get; set; }
        public static string Port { get; set; }
        public static string UserId { get; set; }
        public static string Password { get; set; }
        public static string Database { get; set; }
        public static string DBConnection { get; set; }


        static ConnectionSting()
        {
            IConfigurationRoot MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            Server = MyConfig.GetValue<string>("ConnectionString:Server");
            Port = MyConfig.GetValue<string>("ConnectionString:Port");
            UserId = MyConfig.GetValue<string>("ConnectionString:UserId");
            Password = MyConfig.GetValue<string>("ConnectionString:Password");
            Database = MyConfig.GetValue<string>("ConnectionString:Database");
            DBConnection = String.Format(
                "Server={0};Port={1}; User Id={2};Password={3};Database={4};",
                Server, Port, UserId, Password, Database);
        }
    }
}
