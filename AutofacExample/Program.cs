using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace AutofacExample
{
    class Program
    {
        private static IContainer container { get; set; }

        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConsoleOutput>().As<IOutput>();
            builder.RegisterType<TomorrowWriter>().As<IDateWriter>();
            container = builder.Build();

            WriteDate();

            //var c = new ConsoleOutput();
            //var td = new TodayWriter(c);
            //td.WriteDate();

            Console.ReadLine();
        }

        public static void WriteDate()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var writer = scope.Resolve<IDateWriter>();
                writer.WriteDate();
            }
        }
    }
}
