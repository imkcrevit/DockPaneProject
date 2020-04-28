using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockPaneTest
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    class ShowPage : Autodesk.Revit.UI.IExternalCommand, IExternalCommandAvailability
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Autodesk.Revit.UI.UIApplication app = commandData.Application;


            ThisApplication.thisApp.SetWindowAvibilable(app);

           

            
            


            return Result.Succeeded;
        }

        public bool IsCommandAvailable(UIApplication applicationData, CategorySet selectedCategories)
        {
            if (applicationData.ActiveUIDocument != null)
                return true;
            else
                return false;
        }
    }
}
