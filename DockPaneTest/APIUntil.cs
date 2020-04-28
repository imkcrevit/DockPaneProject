using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DockPaneTest
{
    public partial class APIUntil
    {
        public static Guid m_GUID = new Guid("AF270710-FED3-4B9C-A4A4-7859AD8D352D");
        public  Autodesk.Revit.UI.UIApplication _Application;
        public  void Initialize(Autodesk.Revit.UI.UIApplication uiApp)
        {
            _Application = uiApp;
        }
        public static bool IsIdling { get; set; }
    }
}
