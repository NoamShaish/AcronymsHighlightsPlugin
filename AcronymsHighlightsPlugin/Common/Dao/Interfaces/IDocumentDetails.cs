using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace AcronymsHighlightsPlugin.Common.Dao.Interfaces
{
    public interface IDocumentDetails
    {
        IDocumentProperty get(String propertyName);
        IDocumentProperty set(String propertyName, IDocumentProperty property);
        Collection<IDocumentProperty> getAll();
    }
}
