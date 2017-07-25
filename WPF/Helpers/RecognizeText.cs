using Syncfusion.Windows.Tools.Controls;

namespace WPF.Helpers
{
    public static class RecognizeText
    {
        public static void Recognize(DocumentAdv documentAdv)
        {
            //rozpoznawanie hasła na poszczególne elementy
            
            var text =
                "paczk|a • duża ~a, spora, mała • napoczęta ~a • ~a odzieżowa, żywnościowa " +
                "• ~a herbatników, papierosów i in. • dostawać ~i, • przysyłać ~i, wysyłać " +
                "• kupić ~ę czegoś • otworzyć ~ę,  wyjąć coś z ~";

            var text2 = text.Split(' ');


        }
    }
}