using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Model
{
    public class NHibernateHelper
    {
        public static NHibernate.ISession OpenSession()
        {
            var sessionFactory = Fluently.Configure()
                .Database(OracleClientConfiguration.Oracle10.ConnectionString(@"Provider=OraOLEDB.Oracle.1;Data Source=ORA11G64;Persist Security Info=True;User ID=VIASUL171221;Password=VIASUL171221;Unicode=True").ShowSql())
                .Mappings(m =>
                {
                    var modelos = Array.FindAll(
                        typeof(Model).Assembly.GetExportedTypes(),
                        f => f.BaseType == typeof(Model));

                    foreach (var modelo in modelos)
                        m.FluentMappings.AddFromAssembly(modelo.Assembly);

                    //m.FluentMappings.AddFromAssemblyOf<VeiculoModel>()
                })
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false))
                .BuildSessionFactory();

            return sessionFactory.OpenSession();
        }        
    }
}
