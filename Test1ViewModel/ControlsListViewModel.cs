using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Test1ViewModel
{
    /// <summary>
    /// View model for ControlsListView
    /// </summary>
    class ControlsListViewModel :ViewModelBase
    {
        /// <summary>
        /// Container for <see cref="TestControlViewModel"/>
        /// </summary>
        public ObservableCollection<TestControlViewModel> ControlsViewModel { get; } =
            new ObservableCollection<TestControlViewModel>();

        /// <summary>
        /// Adds control into <see cref="ControlsViewModel"/>
        /// </summary>
        public RelayCommand AddControl { get; set; }
    }
}
