using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Test1ViewModel.Services;

namespace Test1ViewModel
{
	/// <summary>
	/// View model MainWindow
	/// </summary>
	public class MainViewModel:ViewModelBase
	{
		/// <summary>
		/// <see cref="ControlsListViewModel"/>
		/// </summary>
		private ControlsListViewModel _controlsListViewModel;

		/// <summary>
		/// Returns and sets <see cref="ControlsListViewModel"/>
		/// </summary>
		public ControlsListViewModel ControlsListViewModel
		{
			get => _controlsListViewModel;
			set
			{
				_controlsListViewModel = value;
				RaisePropertyChanged(nameof(ControlsListViewModel));
			}
		}

		public MainViewModel(IFileDialogService fileDialogService)
		{
			ControlsListViewModel = new ControlsListViewModel(fileDialogService);
		}
	}
}
