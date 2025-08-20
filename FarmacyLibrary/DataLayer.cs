using System.Text;
using FarmacyLibrary.Mapiranja;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace FarmacyLibrary
{
    class DataLayer
    {
        private static ISessionFactory _factory = null;
        private static object objLock = new object();

        public static ISession GetSession()
        {
            //ukoliko session factory nije kreiran
            if (_factory == null)
            {
                lock (objLock)
                {
                    if (_factory == null)
                        _factory = CreateSessionFactory();
                }
            }

            return _factory.OpenSession();
        }

        private static ISessionFactory CreateSessionFactory()
        {
            try
            {
                var cfg = OracleManagedDataClientConfiguration.Oracle10
                    .Driver<NHibernate.Driver.OracleManagedDataClientDriver>()
                    .ShowSql()
                    .ConnectionString(c =>
                        c.Is("Data Source=//gislab-oracle.elfak.ni.ac.rs:1521/SBP_PDB;User Id=S19286;Password=S19286;Min Pool Size=1;Max Pool Size=1;")
                    );


                return Fluently.Configure()
                .Database(cfg)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ApotekaMapiranja>())
                .ExposeConfiguration(cfg =>
                {
                    // Helpful diagnostics in Output window / console:
                    Console.WriteLine("NH dialect: " + (cfg.Properties.TryGetValue("dialect", out var d) ? d : "<none>"));
                    Console.WriteLine("NH driver: " + (cfg.Properties.TryGetValue("connection.driver_class", out var dr) ? dr : "<none>"));
                    Console.WriteLine("Mappings: " + cfg.ClassMappings.Count);
                    foreach (var cm in cfg.ClassMappings)
                        Console.WriteLine(" - " + cm.EntityName + " -> " + cm.Table.Name);
                })
                .BuildSessionFactory();
            }
            catch (FluentNHibernate.Cfg.FluentConfigurationException fex)
            {
                var sb = new StringBuilder();
                sb.AppendLine("FluentConfigurationException:");
                sb.AppendLine("PotentialReasons:");
                foreach (var r in fex.PotentialReasons) sb.AppendLine(" - " + r);

                Exception ie = fex;
                int depth = 0;
                while (ie != null)
                {
                    sb.AppendLine($"[{depth}] {ie.GetType().Name}: {ie.Message}");
                    ie = ie.InnerException;
                    depth++;
                }

                
                Console.WriteLine($"NH init error (details): {sb.ToString()}");
                throw; // rethrow so you can see stacktrace in Output window too
            }
            catch (Exception ex)
            {
                Console.WriteLine($"NH init error (raw): {ex.ToString()}");
                throw;
            }
        }

    }
}
