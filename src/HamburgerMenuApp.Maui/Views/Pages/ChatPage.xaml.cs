using HamburgerMenuApp.Core.Interfaces.Services;

namespace HamburgerMenuApp.Maui.Views.Pages;

public partial class ChatPage : BaseRootContentPage
{
	public ChatPage(INavigationService navigationService) : base(navigationService)
    {
		InitializeComponent();
	}
}
