using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unimote.Server.API.Helpers;
using Unimote.Server.API.Models.Database;
using Unimote.Server.API.Models.Settings;
using Unimote.Server.API.Models.Users;
using Unimote.Server.WPF.Helpers;
using Unimote.Server.WPF.Models;
using Wpf.Ui.Controls;

namespace Unimote.Server.WPF.ViewModels.Pages
{
	public partial class UsersViewModel : ObservableObject, INavigationAware
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
		private IEnumerable<UserModel> _users;

		[RelayCommand]
		private void OnAddUser()
		{
			if (App.Server == null)
				return;

			var tmp = Users.ToList();
			var newUser = new UserModel(
				"New User",
				"password",
				new List<AllowedSection>(App.Server.Database.Sections));
			foreach (var section in newUser.AllowedSections)
				section.IsAllowed = false;
			tmp.Add(newUser);
			Users = tmp;
		}

		[RelayCommand]
		private void OnSaveUsers()
		{
			App.Server.Database.Users = new List<UserModel>(Users);
			ServerHelper.RestartServer();
		}

		[RelayCommand]
		private void OnDeleteUser(string user)
		{
			var toRemove = Users.SingleOrDefault(x => x.UserName == user);
			if (toRemove != null)
			{
				var tmp = Users.ToList();
				tmp.Remove(toRemove);
				Users = tmp;
			}
		}
	}
}
