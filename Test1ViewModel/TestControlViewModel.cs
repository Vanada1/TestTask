using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

		/// <summary>
		/// Returns and sets filename
		/// </summary>
		public string FileName
		{
			get => _fileName;
			set
			{
				_fileName = value;
				Validation(_fileName, nameof(FileName));
				RaisePropertyChanged(nameof(FileName));
			}
		}

		/// <summary>
		/// Filename remove command
		/// </summary>
		public RelayCommand RemoveCommand { get; set; }
	}
}
