namespace Core.Interface
{
    public interface IImage
    {
        int GetHeight();
        void SetHeight(int value);

        int GetWidth();
        void SetWidth(int value);

        string  GetName();
        void SetName(string value);
    }
}