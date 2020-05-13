using Dragablz;
using Prism.Regions;
using System.Collections.Specialized;
using System.Windows;

namespace EdgeDragablz
{
    public class TabRegionAdapter : RegionAdapterBase<TabablzControl>
    {
        public TabRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory) : base(regionBehaviorFactory) { }
        protected override void Adapt(IRegion region, TabablzControl regionTarget)
        {
            regionTarget.ClosingItemCallback += (e) =>
            {
                if (!CanRemoveItem(e.DragablzItem.Content, region))
                {
                    e.Cancel();
                }
                else RemoveItemFromRegion(e.DragablzItem.Content, region);
            };

            region.Views.CollectionChanged += (s, e) =>
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Remove:
                    case NotifyCollectionChangedAction.Replace:
                    case NotifyCollectionChangedAction.Move:
                        break;

                }
            };

            region.ActiveViews.CollectionChanged += (s, e) =>
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        foreach (var item in e.NewItems)
                        {
                            regionTarget.Items.Insert(regionTarget.Items.Count, item);
                            regionTarget.SelectedIndex = regionTarget.Items.Count - 1;
                        }
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        foreach (var item in e.OldItems)
                        {
                            regionTarget.Items.Remove(item);
                            regionTarget.SelectedIndex = regionTarget.Items.Count - 1;
                        }
                        break;
                }
            };
        }

        internal static void RemoveItemFromRegion(object item, IRegion region)
        {
            var context = new NavigationContext(region.NavigationService, null);

            InvokeOnNavigatedFrom(item, context);

            if (item is IRegionMemberLifetime regionMemberLifetime)
            {
                if (regionMemberLifetime.KeepAlive)
                {
                    if (region.ActiveViews.Contains(item))
                        region.Deactivate(item);
                }
                else
                {
                    if (region.ActiveViews.Contains(item))
                        region.Remove(item);
                }
            }
            else
            {
                if (region.ActiveViews.Contains(item))
                    region.Remove(item);
            }
        }

        private static void InvokeOnNavigatedFrom(object item, NavigationContext navigationContext)
        {
            if (item is INavigationAware navigationAwareItem)
            {
                navigationAwareItem.OnNavigatedFrom(navigationContext);
            }

            if (item is FrameworkElement frameworkElement)
            {
                if (frameworkElement.DataContext is INavigationAware navigationAwareDataContext)
                {
                    navigationAwareDataContext.OnNavigatedFrom(navigationContext);
                }
            }
        }

        private bool CanRemoveItem(object item, IRegion region)
        {
            bool canRemove = true;

            var context = new NavigationContext(region.NavigationService, null);

            if (item is IConfirmNavigationRequest confirmRequestItem)
            {
                confirmRequestItem.ConfirmNavigationRequest(context, result =>
                {
                    canRemove = result;
                });
            }

            if (item is FrameworkElement frameworkElement && canRemove)
            {
                if (frameworkElement.DataContext is IConfirmNavigationRequest confirmRequestDataContext)
                {
                    confirmRequestDataContext.ConfirmNavigationRequest(context, result =>
                    {
                        canRemove = result;
                    });
                }
            }

            return canRemove;
        }


        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }
    }
}
