using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unimote.Server.WPF.Models;
using Wpf.Ui.Controls;

namespace Unimote.Server.WPF.ViewModels.Pages
{
	public partial class LogsViewModel : ObservableObject
	{
		[ObservableProperty]
		private string _logText = "No log to show.";
	}
}
