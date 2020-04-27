using Dragablz;
using HandyDragablz.Views;
using Prism.Ioc;
using Prism.Regions;
using System.Windows;

namespace HandyDragablz
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell(Window shell)
        {
            base.InitializeShell(shell);

            var regionManager = this.Container.Resolve<IRegionManager>();

            regionManager.RequestNavigate("Home");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<HomeView>();
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);

            var regionBehaviorFactory = Container.Resolve<IRegionBehaviorFactory>();
            regionAdapterMappings.RegisterMapping(typeof(TabablzControl), new TabRegionAdapter(regionBehaviorFactory));
        }
    }
}