using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;
using Microsoft.Office.Interop.Word;

namespace AHPWordAddIn.common.plugin
{
    internal class WordTableDataSource : IDataSource
    {
        private WordTableDataSource() { }
        private IDocumentDetails documentDetails;
        private Dictionary<string, string> Dictonary { get; set; }
        
        public static WordTableDataSource newInstance(Table table) {
            if (table.Columns.Count < 2)
            {
                throw new ArgumentException("Table must contain more then 1 column to be legal data source");
            }

            int transalationsCount = table.Columns.Count / 2;
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            for (int i = 1; i <= table.Rows.Count; ++i)
            {
                for (int j = 1; j <= transalationsCount; j += 2)
                {
                    string acronym = cleanCellText(table.Cell(i, j).Range.Text);
                    string translation = cleanCellText(table.Cell(i, j + 1).Range.Text);
                    dictionary.Add(acronym, translation);
                }
            }

            WordTableDataSource dataSource = new WordTableDataSource() { Dictonary = dictionary, Name = String.Format("Local Data Source at: {0}", table.Range.ToString()) };

            return dataSource;
        }

        public string Name { get; private set; }

        public IDocumentDetails DocumentDetails
        {
            set
            {
                this.documentDetails = value;
            }
        }

        public IAcronym transaulate(IAcronym acronym)
        {
            if (this.Dictonary.Keys.Contains<string>(acronym.Text))
            {
                acronym.Translations.Add(this.Dictonary[acronym.Text]);
            }

            return acronym;
        }

        public bool hasTransulationFor(IAcronym acronym)
        {
            return this.Dictonary.Keys.Contains<string>(acronym.Text);
        }

        private static string cleanCellText(string text)
        {
            return text.Replace("\r\a", "");
        }
    }
}
