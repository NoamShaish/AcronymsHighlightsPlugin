using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcronymsHighlightsPlugin.Common.Dao.Interfaces
{
    public interface IDocumentDetails
    {
        IDocumentProperty get(String propertyName);
        bool set(IDocumentProperty property);
        ICollection<IDocumentProperty> getAll();
    }
}
