namespace Core.Interface
{
    public interface IMyImage
    {
        int GetHeight();
        void SetHeight(int value);

        int GetWidth();
        void SetWidth(int value);

        string  GetName();
        void SetName(string value);
    }
}