using GalaSoft.MvvmLight.Command;

namespace Test1ViewModel
{
	/// <summary>
	/// View model for TestControlView
	/// </summary>
	public class TestControlViewModel :ErrorViewModelBase
	{
		/// <summary>
		/// Filename
		/// </summary>
		private string _fileName;

		private RelayCommand<TestControlViewModel> _removeCommand;

		/// <summary>
		/// Returns and sets filename
		/// </summary>
		public string FileName
		{
			get => _fileName;
			set
			{
				Validation(value, nameof(FileName));
				Set(ref _fileName, value);
				RaisePropertyChanged(nameof(HasErrors));
			}
		}

		/// <summary>
		/// Filename remove command
		/// </summary>
		public RelayCommand<TestControlViewModel> RemoveCommand
		{
			get=>_removeCommand;
			set
			{
				Set(ref _removeCommand, value);
				RaisePropertyChanged(nameof(HasErrors));
			}
		}
	}
}
