using System.ComponentModel.DataAnnotations;

namespace RecognizePassword.Model
{
    public class DictionaryPasswordElement
    {
        /// <summary>
        /// word - hasło słownika
        /// description - opis hasła
        /// </summary>
        [Display(Name = "Skrót", Description = "Pojedynczy element")]
        public string Word { get; set; }
        [Display(Name = "Opis", Description = "Pojedynczy opis hasła")]
        public string Description { get; set; }

        public override string ToString()
        {
            return Word + " " + Description;
        }
    }
}