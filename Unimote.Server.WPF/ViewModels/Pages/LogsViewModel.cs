namespace Unimote.Server.WPF.ViewModels.Pages
{
	public partial class LogsViewModel : ObservableObject
	{
		[ObservableProperty]
		private string _logText = "No log to show.";
	}
}
