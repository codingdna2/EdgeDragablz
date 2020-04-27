using Dragablz;
using Prism.Commands;
using Prism.Regions;
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

            InterTabClient = new InterTabClient();
        }

        public IInterTabClient InterTabClient { get; }

        public ICommand AddCommand { get; }

        public ICommand RemoveCommand { get; }

        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
            {
                this.regionManager.RequestNavigate(navigatePath);
            }
        }
    }
}