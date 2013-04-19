using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;

namespace AcronymsHighlightsPlugin.Common.Dao.Base
{
    public class Acronym : IAcronym
    {
        private readonly List<string> transalations = new List<string>();

        private Acronym(string text)
        {
            this.Text = text;
        }

        public static Acronym newInstance(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException("text");
            }

            return new Acronym(text);
        }

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
    }
}
