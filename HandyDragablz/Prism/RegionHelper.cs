using Prism.Regions;

namespace EdgeDragablz
{
    public static class RegionHelper
    {
        public const string RegionName = "ContentRegion";

        public static void RequestNavigate(this IRegionManager regionManager, string navigatePath)
        {
            regionManager.RequestNavigate(RegionName, navigatePath + "View");
        }

        public static void CloseAllTabs(this IRegionManager regionManager)
        {
            regionManager.Regions[RegionName].RemoveAll();
        }
    }
}