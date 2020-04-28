using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DockPaneTest
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl1 : Page,Autodesk.Revit.UI.IDockablePaneProvider
    {
        private ExternalHander _hander;
        private ExternalEvent _Event;
        public UserControl1()
        {
            InitializeComponent();
            mainPage = this;
            _hander = new ExternalHander();
            _event = ExternalEvent.Create(_hander);
        }

        public ExternalEvent excHander = null;
        public Autodesk.Revit.UI.ExternalEvent _event =null;
        public void SetupDockablePane(DockablePaneProviderData data)
        {
            data.FrameworkElement = this as FrameworkElement;
            data.InitialState = new DockablePaneState
            {
                DockPosition = DockPosition.Bottom
            };
            
        }
        public bool IsIdling { get; set; }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            _event.Raise();

        }
        internal static UserControl1 mainPage = null;
        public class ExternalHander : IExternalEventHandler
        {
            public void Execute(UIApplication app)
            {
                
               ThisApplication.thisApp.AddIdlingEvent(app);
                
            }

            public string GetName()
            {
                return "ExternalHander.Excute()";
            }
        }
    }
   
}
