using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AHPWordAddIn.common.plugin;
using AHPWordAddIn.common.utils;
using AcronymsHighlightsPlugin.Common.Dao.Interfaces;

namespace AHPWordAddIn.common.commands
{
    internal class UpdateDocumentDetails :ICommand
    {
        private readonly IEnumerable<IDocumentProperty> properties;
        public UpdateDocumentDetails(IEnumerable<IDocumentProperty> properties)
        {
            this.properties = properties;
        }

        public void execute()
        {
            bool updated = false;
            foreach (IDocumentProperty property in this.properties)
            {
                AddInManager.instance.getDocumentDetails().set(property);
                updated = true;
            }

            if (updated)
            {
                AcronymsHighlightFacade.instance.refreshDDSP(properties);
                AddInManager.instance.notifyDocumentDetailsUpdate(this.properties);
            }
        }
    }
}
