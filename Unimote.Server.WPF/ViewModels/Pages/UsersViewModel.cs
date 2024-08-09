using Unimote.Server.API.Helpers;
using Unimote.Server.API.Models.Users;
using Unimote.Server.WPF.Helpers;
using Wpf.Ui.Controls;

namespace Unimote.Server.WPF.ViewModels.Pages
{
	public partial class UsersViewModel : BaseLoadingPage, INavigationAware
	{
		public void OnNavigatedTo() => InitializeViewModel();

		public void OnNavigatedFrom() { }

		internal void InitializeViewModel()
		{
			if (App.Server == null)
			{
				Users = new List<UserModel>();
				return;
			}

			Users = App.Server.Database.Users.Clone();
		}

		[ObservableProperty]
		private List<UserModel> _users;

		[RelayCommand]
		private async Task OnAddUser()
		{
			await LoadingStart();
			if (App.Server == null)
				return;

			var tmp = Users.ToList();
			var newUser = new UserModel(
				Guid.NewGuid(),
				"New User",
				"password",
				new List<AllowedSection>(App.Server.Database.Sections));
			foreach (var section in newUser.AllowedSections)
				section.IsAllowed = false;
			tmp.Add(newUser);
			Users = tmp;
			LoadingStop();
		}

		[RelayCommand]
		private async Task OnSaveUsers()
		{
			await LoadingStart();
			App.Server.Database.Users = new List<UserModel>(Users);
			ServerHelper.RestartServer();
			LoadingStop();
		}

		[RelayCommand]
		private async Task OnDeleteUser(Guid userID)
		{
			await LoadingStart();
			var toRemove = Users.SingleOrDefault(x => x.ID == userID);
			if (toRemove != null)
			{
				var tmp = Users.ToList();
				tmp.Remove(toRemove);
				Users = tmp;
			}
			LoadingStop();
		}
	}
}
