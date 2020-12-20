using Autofac;
using FreeSql;
using System.Diagnostics;

namespace FreePuzzle.Service.Modules
{
    public  class FreeSqlModule : Module
    {
        public FreeSqlModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {

            //Assembly assembly = Assembly.Load("Services");
            #region FreeSql 初始化

    

            IFreeSql fsql = new FreeSqlBuilder()
                .UseConnectionString(FreeSql.DataType.MySql, "Data Source=localhost;Port=3306;User ID=root;Password=root;Initial Catalog=FreePuzzle;Charset=utf8;SslMode=none")       
                .UseMonitorCommand(cmd => Trace.WriteLine($"{cmd.CommandText}\r\n"))
                .UseAutoSyncStructure(true) //是否自动创建、迁移实体表结构
                .UseNoneCommandParameter(true)
                .Build();
            #endregion
            //builder.RegisterAssemblyTypes(typeof(BaseService).Assembly).Where(t => t.Name.EndsWith("Service"))
            // .WithProperty("freeSql", fsql)
            //  .AsSelf();

            builder.Register(t => fsql).As<IFreeSql>().SingleInstance();


        }
    }
}
