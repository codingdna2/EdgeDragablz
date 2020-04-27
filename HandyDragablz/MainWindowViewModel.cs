using CommonServiceLocator;
using Dragablz;
using HandyDragablz.Views;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Linq;
using System.Windows.Input;

namespace HandyDragablz
{
    public class MainWindowViewModel
    {
        private readonly IRegionManager regionManager;

        public MainWindowViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;

            AddCommand = new DelegateCommand(() => { Navigate("Home"); });

            CloseAllCommand = new DelegateCommand(() => { this.regionManager.CloseAllTabs(); });

            InterTabClient = new InterTabClient();
        }

        public IInterTabClient InterTabClient { get; }

        public ICommand AddCommand { get; }

        public ICommand CloseAllCommand { get; }

        public static Func<HomeView> Factory => () => ServiceLocator.Current.GetInstance<HomeView>();

        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
            {
                this.regionManager.RequestNavigate(navigatePath);
            }
        }
    }
}