using Autofac;
using Core.Interface;
using Core.Model;

namespace Core
{
    public class Start
    {
        private static IContainer _container;

        private readonly Ocr _ocr;

        public Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ReadPicture>().As<IReadPicture>();
            
            _container=builder.Build();
            
            _ocr = new Ocr(_container.Resolve<IReadPicture>());
        }

        public bool ReadFile(Image image)
        {
            return _ocr.ReadFile(image);
        }

        public string ReadOcr()
        {
            return _ocr.ReadOcr();
        }
    }
}