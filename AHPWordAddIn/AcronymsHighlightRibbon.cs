using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;

namespace AHPWordAddIn
{
    public partial class AcronymsHighlightRibbon
    {
        private void AcronymsHighlightRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void buttonAddLocalDataSource_Click(object sender, RibbonControlEventArgs e)
        {
            new AHPWordAddIn.common.commands.AddLocalDataSource().execute();
        }
    }
}
