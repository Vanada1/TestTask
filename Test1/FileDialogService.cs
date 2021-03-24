using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using Test1ViewModel.Services;

namespace Test1
{
	public class FileDialogService:IFileDialogService
	{
		/// <inheritdoc />
		public string FileName { get; set; }
		
		/// <inheritdoc />
		public bool DialogResult { get; set; }

		/// <inheritdoc />
		public void ShowDialog()
        {
            var openFileDialog = new OpenFileDialog {Filter = "All files (*.*)|*.*"};
            if (openFileDialog.ShowDialog() != true) return;
            DialogResult = true;
            FileName = openFileDialog.FileName;
        }
	}
}
