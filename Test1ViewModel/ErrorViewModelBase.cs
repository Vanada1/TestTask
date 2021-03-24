using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace Test1ViewModel
{
	/// <summary>
	/// Base view model class with errors
	/// </summary>
	public class ErrorViewModelBase:ViewModelBase, INotifyDataErrorInfo
	{
		/// <summary>
		/// Contains all errors
		/// </summary>
		private static readonly Dictionary<string, List<string>> Errors = new Dictionary<string, List<string>>();

		/// <inheritdoc />
		public bool HasErrors => Errors.Any();
		
		/// <inheritdoc />
		public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

		/// <inheritdoc />
		public IEnumerable GetErrors(string propertyName)
		{
			if (string.IsNullOrEmpty(propertyName)) return null;
			return Errors.ContainsKey(propertyName) ? Errors[propertyName] : null;
		}

		/// <summary>
		/// Check validation
		/// </summary>
		/// <param name="value">Property value</param>
		/// <param name="propertyName"></param>
		protected virtual void Validation(object value, string propertyName)
		{
			ClearErrors(propertyName);
			if (!(value is string valueString)) return;
			var expansion = valueString.Split('.').Last();
			if (expansion != "exe" && expansion != "dll")
			{
				AddError(propertyName, "Not .dll or .exe");
			}
		}

		/// <summary>
		/// Notifies about errors change
		/// </summary>
		/// <param name="propertyName"></param>
		private void OnErrorsChanged(string propertyName)
		{
			ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
		}

		/// <summary>
		/// Add error in the dictionary <see cref="Errors"/>
		/// </summary>
		/// <param name="propertyName"></param>
		/// <param name="error"></param>
		private void AddError(string propertyName, string error)
		{
			if (!Errors.ContainsKey(propertyName))
			{
				Errors[propertyName] = new List<string>();
			}

			if (Errors[propertyName].Contains(error)) return;
			Errors[propertyName].Add(error);
			OnErrorsChanged(propertyName);
		}

		/// <summary>
		/// Clear errors by key
		/// </summary>
		/// <param name="propertyName">key of dictionary</param>
		private void ClearErrors(string propertyName)
		{
			if (!Errors.ContainsKey(propertyName)) return;
			Errors[propertyName].Clear();
			Errors.Remove(propertyName);
			OnErrorsChanged(propertyName);
		}


	}
}
