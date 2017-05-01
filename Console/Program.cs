using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Core;
using Core.Interface;

namespace Console
{
    class Program
    {
        private static IContainer Container;

        private const string FileName = @"F:/3.jpg";

        public string Filename = Path.Combine(Path.GetDirectoryName(FileName), Path.GetFileName(FileName));



        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ReadPicture>().As<IReadPicture>();
            Container = builder.Build();

            
            

        }
    }
}
