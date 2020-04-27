using CommonServiceLocator;
using Dragablz;
using System.Windows;

namespace EdgeDragablz
{
    public class InterTabClient : IInterTabClient
    {
        public INewTabHost<Window> GetNewHost(IInterTabClient interTabClient, object partition, TabablzControl source)
        {
            var view = ServiceLocator.Current.GetInstance<MainWindow>();

            return new NewTabHost<Window>(view, view.Tabs);
        }

        public TabEmptiedResponse TabEmptiedHandler(TabablzControl tabControl, Window window)
        {
            return TabEmptiedResponse.CloseWindowOrLayoutBranch;
        }
    }
}
