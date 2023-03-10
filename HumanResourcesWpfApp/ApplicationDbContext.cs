namespace HumanResourcesWpfApp
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using HumanResourcesWpfApp.Models;
    using HumanResourcesWpfApp.Models.Domains;
    using HumanResourcesWpfApp.Properties;
    using HumanResourcesWpfApp.Models.Configurations;

    public class ApplicationDbContext : DbContext
    {

        private static string _server = Settings.Default.Server;
        private static string _serverDbName = Settings.Default.ServerDbName;
        private static string _database = Settings.Default.Database;
        private static string _user = Settings.Default.User;
        private static string _password = Settings.Default.Password;


        private static string _dbConnectionString = string.Format("Server={0};Database={1};User Id={2};Password={3};"
           , _server, _database, _user, _password);


        public ApplicationDbContext()
            : base(_dbConnectionString)
        {


        }

        //DbSet - klasa generyczna , kt?ra na podstawie klas Domains bedzie wiedziala jakie ma utworzyc tabele
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Address { get; set; }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new AddressConfiguration());
        }
        


        public void DbConnection(DbConnect dbConnect)
        {
            Settings.Default.Server = dbConnect.Server;
            Settings.Default.ServerDbName = dbConnect.ServerDbName;
            Settings.Default.Database = dbConnect.Database;
            Settings.Default.User = dbConnect.User;
            Settings.Default.Password = dbConnect.Password;

            Settings.Default.Save();
        }

        public void ChangeConnectionString(DbConnect dbConnect)
        {
            _dbConnectionString = string.Format("Server={0};Database={1};User Id={2};Password={3};"
           , dbConnect.Server, dbConnect.Database, dbConnect.User, dbConnect.Password);
        }


    }

}