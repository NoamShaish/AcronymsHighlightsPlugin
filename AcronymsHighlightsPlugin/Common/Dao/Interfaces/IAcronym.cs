using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace AcronymsHighlightsPlugin.Common.Dao.Interfaces
{
    public interface IAcronym
    {
        String Text { get; set; }
        ICollection<String> Transulation { get; set; }
        Boolean isTrunslated();
        void clearTransulations();



    }
}
