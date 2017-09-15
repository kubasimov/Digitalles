using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Core.Helpers
{
    [SuppressMessage("ReSharper", "ConvertClosureToMethodGroup")]


    internal static class HelperOcr
    {
        internal static string GetNumbers(string input)
        {
            return new string(input.Where(c => char.IsDigit(c)).ToArray());
        }
    }
}


