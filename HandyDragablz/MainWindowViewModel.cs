using Dragablz;
using Prism.Commands;
using Prism.Regions;
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

            RemoveCommand = new DelegateCommand(() => { });

            CloseAllCommand = new DelegateCommand(() => { this.regionManager.CloseAllTabs(); });

            InterTabClient = new InterTabClient();
        }

        public IInterTabClient InterTabClient { get; }

        public ICommand AddCommand { get; }

        public ICommand RemoveCommand { get; }

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