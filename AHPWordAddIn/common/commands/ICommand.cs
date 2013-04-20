using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AHPWordAddIn.common.commands
{
    /// <summary>
    /// Command pattern.
    /// </summary>
    internal interface ICommand
    {
        void execute();
    }
}
