using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1ViewModel.Services
{
	/// <summary>
	/// Interface for show file dialog
	/// </summary>
	public interface IFileDialogService
	{
		/// <summary>
		/// Path to file
		/// </summary>
		string FileName { get; }

		/// <summary>
		/// Dialog result
		/// </summary>
		bool DialogResult { get; }

		/// <summary>
		/// Show Dialog
		/// </summary>
		void ShowDialog();
	}
}
