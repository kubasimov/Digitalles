﻿using System.ComponentModel.DataAnnotations;

namespace RecognizePassword.Model
{
    public class DictionaryPasswordElement
    {
        /// <summary>
        /// word - hasło słownika
        /// description - opis hasła
        /// </summary>
        [Display(Name = "Skrót", Description = "Pojedyńczy element")]
        public string Word { get; set; }
        [Display(Name = "Opis", Description = "Pojedyńczy opis hasła")]
        public string Description { get; set; }

        public override string ToString()
        {
            return Word + " " + Description;
        }
    }
}