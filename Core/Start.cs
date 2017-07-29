using System;
using System.ComponentModel;
using Autofac;
using Core.Interface;
using Core.Model;
using IContainer = System.ComponentModel.IContainer;

namespace Core
{
    public class Start
    {
        private static Autofac.IContainer _container;

        private readonly Ocr _ocr;

        public Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ReadPicture>().As<IReadPicture>();
            
            _container=builder.Build();
            
            _ocr = new Ocr(_container.Resolve<IReadPicture>());
        }

        public bool ReadFile(string image)
        {
            return _ocr.ReadFile(image);
        }

        public string Ocr()
        {
            return _ocr.ReadOcr("pol");
        }
    }
}