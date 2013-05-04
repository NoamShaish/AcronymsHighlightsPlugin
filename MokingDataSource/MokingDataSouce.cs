using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;

namespace MokingDataSource
{
    public class MokingDataSouce : IDataSource
    {

        public string Name
        {
            get { return "Moking Data Source"; }
        }

        public IDocumentDetails DocumentDetails
        {
            set { }
        }

        public IAcronym transaulate(IAcronym acronym)
        {
            if (acronym == null)
            {
                throw new ArgumentNullException();
            }

            if (acronym.Translations == null)
            {
                throw new ArgumentNullException("acronym.Translation isnt initilaized");
            }

            acronym.Translations.Add("Translation 1");
            acronym.Translations.Add("Translation 2");
            acronym.Translations.Add("Translation 3");
            acronym.Translations.Add("Translation 4");

            return acronym;
        }

        public bool hasTransulationFor(IAcronym acronym)
        {
            return true;
        }
    }
}
