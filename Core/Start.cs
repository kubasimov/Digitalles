using Autofac;
using Core.Implement;
using Core.Interface;

namespace Core
{
    public class Start
    {
        private readonly Ocr _ocr;

        public Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ReadPicture>().As<IReadPicture>();
            
            var container = builder.Build();
            
            _ocr = new Ocr(container.Resolve<IReadPicture>());
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