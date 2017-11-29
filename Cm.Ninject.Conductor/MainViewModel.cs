using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cm.Ninject.Conductor
{
    public sealed class MainViewModel : Conductor<IScreen>.Collection.OneActive
    {
        private readonly IWindowManager windowManager;
        private readonly IEventAggregator eventAggregator;

        public MainViewModel(IWindowManager windowManager, IEventAggregator eventAggregator)
        {
            this.windowManager = windowManager ?? throw new ArgumentNullException(nameof(windowManager));
            this.eventAggregator = eventAggregator ?? throw new ArgumentNullException(nameof(eventAggregator));

            ActivateItem(new TabViewModel
            {
                DisplayName = " Main Tab "
            });
        }

        public void OpenMainTab()
        {
            if (CheckConductorCollection.AlreadyOpened(this, " Main Tab "))
            {
                ActivateItem(GetChildren().FirstOrDefault(x => x.DisplayName == " Main Tab "));
                return;
            }

            ActivateItem(new MyViewModel
            {
                DisplayName = " Main Tab "
            });
        }

        public void OpenTab()
        {
            if (CheckConductorCollection.AlreadyOpened(this, " New Tab "))
            {
                ActivateItem(GetChildren().FirstOrDefault(x => x.DisplayName == " New Tab "));
                return;
            }

            ActivateItem(new TabViewModel
            {
                DisplayName = " New Tab "
            });
        }

        public void CloseItem(object dataContext)
        {
            ScreenExtensions.CloseItem(this, dataContext);
        }
    }
}
