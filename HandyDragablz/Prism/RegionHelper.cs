using Prism.Regions;

namespace HandyDragablz
{
    public static class RegionHelper
    {
        public const string RegionName = "ContentRegion";

        public static void RequestNavigate(this IRegionManager regionManager, string navigatePath)
        {
            regionManager.RequestNavigate(RegionName, navigatePath + "View");
        }
    }
}