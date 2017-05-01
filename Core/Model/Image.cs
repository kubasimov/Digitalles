using Core.Interface;

namespace Core.Model
{
    public class Image : IImage
    {
        private string _filename;
        private int _height;
        private int _width;

        public int GetHeight()
        {
            return _height;
        }

        public void SetHeight(int value)
        {
            _height = value;
        }

        public int GetWidth()
        {
            return _width;
        }

        public void SetWidth(int value)
        {
            _width = value;
        }

        public string GetName()
        {
            return _filename;
        }

        public void SetName(string value)
        {
            _filename = value;
        }
    }
}