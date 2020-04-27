using Prism.Mvvm;
using Prism.Regions;
using System;

namespace EdgeDragablz.ViewModels
{
    public abstract class DocumentViewModel : BindableBase, IConfirmNavigationRequest
    {
        #region Constructors

        protected DocumentViewModel()
        {
        }

        #endregion

        #region Properties

        public abstract string Header { get; }

        #endregion

        #region Methods

        public virtual void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            continuationCallback(true);
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        #endregion
    }
}
