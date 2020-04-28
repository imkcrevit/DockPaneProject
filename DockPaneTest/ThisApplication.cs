using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace DockPaneTest
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class ThisApplication : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
        
        public Result OnStartup(UIControlledApplication application)
        {
            thisApp = this;
            apiUntil = new APIUntil();
            string tabName = "DockPane";

            string PanelName = "DockPane";
            string RegisterName = "Register";
            application.CreateRibbonTab(tabName);
            RibbonPanel architecturePanel = application.CreateRibbonPanel(tabName, PanelName);
            PushButtonData buttonData = new PushButtonData("DockPane", "DockPane", Assembly.GetExecutingAssembly().Location, typeof(ShowPage).FullName);
            PushButton ShowPage = architecturePanel.AddItem(buttonData) as PushButton;
            ShowPage.AvailabilityClassName = typeof(ShowPage).FullName;

            RibbonPanel RegisterPanel = application.CreateRibbonPanel(tabName, RegisterName);
            PushButtonData buttonDataRegisterPage = new PushButtonData("RegisterDockPane", "RegisterDockPane", Assembly.GetExecutingAssembly().Location, typeof(RegisterPage).FullName);
            PushButton RegisterPage = RegisterPanel.AddItem(buttonDataRegisterPage) as PushButton;
            RegisterPage.AvailabilityClassName = typeof(RegisterPage).FullName;
            
            return Result.Succeeded;
        }
        public void RegisterPage(Autodesk.Revit.UI.UIApplication uiapp)
        {
            DockablePaneId dockablePaneId = new DockablePaneId(APIUntil.m_GUID);
            uiapp.RegisterDockablePane(dockablePaneId, "Pane", ThisApplication.thisApp.GetMainWindow() as IDockablePaneProvider);
        }
        private UserControl1 m_MainPage;
        public void CreatWindow()
        {
            m_MainPage = new UserControl1();
        }
        public UserControl1 GetMainWindow()
        {
            return m_MainPage;
        }
        public void SetWindowAvibilable(Autodesk.Revit.UI.UIApplication uiApp)
        {
            DockablePane pane = uiApp.GetDockablePane(new DockablePaneId(APIUntil.m_GUID));
            pane.Show();
           
        }
        internal static ThisApplication thisApp = null;
        private APIUntil apiUntil = null;
        public APIUntil GetAPIUntil()
        {
            return apiUntil;
        }
        
        public Autodesk.Revit.UI.UIApplication m_UIApplication;
        public void SetApplication(Autodesk.Revit.UI.UIApplication uiApp)
        {
            m_UIApplication = uiApp;
        }
        public void AddIdlingEvent(UIApplication uiapp)
        {
            uiapp.Idling += IdlingHandler;
        }
        public static void IdlingHandler(object sender, Autodesk.Revit.UI.Events.IdlingEventArgs args)
        {
            UIApplication uiapp = sender as UIApplication;
            if (uiapp != null)
            {
                Autodesk.Revit.UI.UIDocument uidoc = uiapp.ActiveUIDocument;
                Autodesk.Revit.DB.Document doc = uidoc.Document;
                if (uidoc != null && doc != null)
                {
                    Reference re = uidoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, "");
                    Element e = doc.GetElement(re);

                    System.Windows.Forms.MessageBox.Show(e.Id.ToString() + e.Name);
                    uiapp.Idling -= IdlingHandler;
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Must should Idling!");
            }
        }
    }

}
