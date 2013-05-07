using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AHPWordAddIn.common.plugin;
using AHPWordAddIn.common.utils;

namespace AHPWordAddIn.common.commands
{
    internal class UpdateDocumentDetails :ICommand
    {
        private readonly WordDocumentProperty property;
        public UpdateDocumentDetails(WordDocumentProperty property)
        {
            this.property = property;
        }

        public void execute()
        {
            AddInManager.instance.getDocumentDetails().set(this.property);
            AddInManager.instance.notifyDocumentDetailsUpdate();
        }
    }
}
