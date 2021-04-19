using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Test1ViewModel.Services;

namespace Test1ViewModel
{
	/// <summary>
	/// View model for ControlsListView
	/// </summary>
	public class Controls :ViewModelBase
	{
		/// <summary>
		/// File dialog service
		/// </summary>
		private readonly IFileDialogService _fileDialogService;

		/// <summary>
		/// Add control command
		/// </summary>
		private RelayCommand _addControlCommand;

		/// <summary>
		/// Selected <see cref="TestControlViewModel"/>
		/// </summary>
		private TestControlViewModel _selectedControl;

		/// <summary>
		/// Container for <see cref="TestControlViewModel"/>
		/// </summary>
		public ObservableCollection<TestControlViewModel> ControlsViewModel { get; set; } 

		/// <summary>
		/// Returns and sets selected item
		/// </summary>
		public TestControlViewModel SelectedControl
		{
			get => _selectedControl;
			set
			{
				_selectedControl = value;
				RaisePropertyChanged(nameof(SelectedControl));
			}
		}

		/// <summary>
		/// Adds control into <see cref="ControlsViewModel"/>
		/// </summary>
		public RelayCommand AddControlCommand => _addControlCommand ??
												 (_addControlCommand = new RelayCommand(AddControl));

		public Controls(IFileDialogService fileDialogService)
		{
			_fileDialogService = fileDialogService;
			ControlsViewModel = new ObservableCollection<TestControlViewModel>();
		}

		/// <summary>
		/// Add control
		/// </summary>
		private void AddControl()
		{
			_fileDialogService.ShowDialog();
			if (_fileDialogService.DialogResult)
			{
				ControlsViewModel.Add(new TestControlViewModel
				{
					FileName = Path.GetFileName(_fileDialogService.FileName),
					RemoveCommand = new RelayCommand<TestControlViewModel>(RemoveControl)
				});
				RaisePropertyChanged(nameof(ControlsViewModel));
			}
		}

		/// <summary>
		/// Remove control
		/// </summary>
		private void RemoveControl(TestControlViewModel sender)
		{
			ControlsViewModel.Remove(sender);
		}
	}
}
