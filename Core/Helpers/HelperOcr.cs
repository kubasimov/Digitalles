using System.Linq;

namespace Core.Helpers
{
    public static class HelperOcr
    {
        public static string GetNumbers(string input)
        {
            return new string(input.Where(c => char.IsDigit(c)).ToArray());
        }
    }
}