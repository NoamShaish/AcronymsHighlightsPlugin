﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;

namespace AHPWordAddIn.common.utils
{
    /// <summary>
    /// Arguments for transle event.
    /// </summary>
    internal class WordTranslatedEventArgs : EventArgs
    {
        internal IAcronym acronym { get; set; }
    }
}
