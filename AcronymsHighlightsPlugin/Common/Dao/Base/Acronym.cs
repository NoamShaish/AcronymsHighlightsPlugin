using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;

namespace AcronymsHighlightsPlugin.Common.Dao.Base
{
    /// <summary>
    /// Basic implemntation of IAcronym.
    /// </summary>
    public class Acronym : IAcronym
    {
        /// <summary>
        /// Acronym translations.
        /// </summary>
        private readonly List<string> transalations = new List<string>();

        #region Factory method pattern
        /// <summary>
        /// Prevent from uncontroled creation.
        /// </summary>
        /// <param name="text">Text of acronym.</param>
        private Acronym(string text)
        {
            this.Text = text;
        }

        /// <summary>
        /// Factory method.
        /// verify that texts given is not null.
        /// </summary>
        /// <param name="text">Actual texts of acronym, must have a value.</param>
        /// <returns>A new instance of Acronym with text as given.</returns>
        public static Acronym newInstance(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException("text");
            }

            return new Acronym(text);
        }
        #endregion

        #region IAcronym
        public string Text { get; private set; }
        
        public ICollection<string> Transulations
        {
            get
            {
                return this.transalations;
            }
        }

        public bool isTrunslated()
        {
            return this.Transulations.Count > 0;
        }

        public void clearTransulations()
        {
            this.transalations.Clear();
        }
        #endregion
    }
}
