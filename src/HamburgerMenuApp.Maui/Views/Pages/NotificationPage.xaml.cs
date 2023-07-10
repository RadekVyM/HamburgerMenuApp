using HamburgerMenuApp.Core.Interfaces.Services;

namespace HamburgerMenuApp.Maui.Views.Pages;

public partial class NotificationPage : BaseRootContentPage
{
	public NotificationPage(INavigationService navigationService) : base(navigationService)
    {
		InitializeComponent();
	}
}
