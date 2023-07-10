using HamburgerMenuApp.Core.Interfaces.Services;

namespace HamburgerMenuApp.Maui.Views.Pages;

public partial class MyPostPage : BaseRootContentPage
{
	public MyPostPage(INavigationService navigationService) : base(navigationService)
    {
		InitializeComponent();
	}
}
