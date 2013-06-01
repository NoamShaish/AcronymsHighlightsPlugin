using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;
using System.Reflection;

namespace MokingDataSource
{
    public class MokingDataSouce : IDataSource
    {
        public MokingDataSouce()
        {
            Random random = new Random(Assembly.GetExecutingAssembly().ManifestModule.ModuleVersionId.GetHashCode());
            this.MokingId = random.Next(1, 11);
        }

        public string Name
        {
            get { return "Moking Data Source " + this.MokingId; }
        }

        public int MokingId { get; set; }

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

            for (int i = 0; i < this.MokingId; i++)
            {
                acronym.Translations.Add("MDS" + this.MokingId + " Translation " + i + " " + acronym.Text);
            }

            return acronym;
        }

        public bool hasTransulationFor(IAcronym acronym)
        {
            return true;
        }
    }
}
