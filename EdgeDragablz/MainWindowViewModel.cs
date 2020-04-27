using CommonServiceLocator;
using Dragablz;
using EdgeDragablz.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace EdgeDragablz
{
    public class MainWindowViewModel : BindableBase
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

        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
            {
                this.regionManager.RequestNavigate(navigatePath);
            }
        }
    }
}