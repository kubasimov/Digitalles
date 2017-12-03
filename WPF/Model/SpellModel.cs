using System.ComponentModel.DataAnnotations;

namespace WPF.Model
{
    public class SpellModel
    {
        [Display(Name="Słowo do sprawdzenia")]
        public string Word { get; set; }
        [Display(Name="Lista poprawnych słów")]
        public string ListSpell { get; set; }
    }
}