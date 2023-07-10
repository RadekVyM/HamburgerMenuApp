using HamburgerMenuApp.Core.Interfaces.Services;

namespace HamburgerMenuApp.Maui.Views.Pages;

public partial class HomePage : BaseRootContentPage
{
	public HomePage(INavigationService navigationService) : base(navigationService)
	{
		InitializeComponent();
	}
}
