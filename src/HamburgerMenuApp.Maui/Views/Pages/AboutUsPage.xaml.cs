using HamburgerMenuApp.Core.Interfaces.Services;

namespace HamburgerMenuApp.Maui.Views.Pages;

public partial class AboutUsPage : BaseRootContentPage
{
	public AboutUsPage(INavigationService navigationService) : base(navigationService)
    {
		InitializeComponent();
	}
}
