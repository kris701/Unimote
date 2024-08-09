using Unimote.Server.WPF.ViewModels.Pages;
using Wpf.Ui.Controls;

namespace Unimote.Server.WPF.Views.Pages
{
	/// <summary>
	/// Interaction logic for ConfigurationsPage.xaml
	/// </summary>
	public partial class ConfigurationsPage : INavigableView<ConfigurationsViewModel>
	{
		public ConfigurationsViewModel ViewModel { get; }

		public ConfigurationsPage(ConfigurationsViewModel viewModel)
		{
			ViewModel = viewModel;
			DataContext = this;

			InitializeComponent();
		}
	}
}
