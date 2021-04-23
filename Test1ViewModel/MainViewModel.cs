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
		/// <see cref="Controls"/>
		/// </summary>
		private Controls _controls;

		/// <summary>
		/// Returns and sets <see cref="Controls"/>
		/// </summary>
		public Controls Controls
		{
			get => _controls;
			set => Set(ref _controls, value);
		}

		public MainViewModel(IFileDialogService fileDialogService)
		{
			Controls = new Controls(fileDialogService);
		}
	}
}
