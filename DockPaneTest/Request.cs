using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace DockPaneTest
{
    public static class Request
    {
        public static void Excute(Autodesk.Revit.UI.UIApplication uiapp,string text)
        {
            Autodesk.Revit.UI.UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.DB.Document doc = uidoc.Document;
            if (uidoc != null && doc != null)
            {
                Reference re = uidoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, "");
                Element e = doc.GetElement(re);
                Transaction trans = new Transaction(doc, text);
                trans.Start();
                doc.Delete(e.Id);
                trans.Commit();
            }
        }

    }
}
