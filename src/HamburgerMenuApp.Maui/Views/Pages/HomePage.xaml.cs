using HamburgerMenuApp.Core.Interfaces.Services;
using HamburgerMenuApp.Core.Interfaces.ViewModels;

namespace HamburgerMenuApp.Maui.Views.Pages;

public partial class HomePage : BaseRootContentPage
{
	public HomePage(IHomePageViewModel viewModel, INavigationService navigationService) : base(navigationService)
	{
		BindingContext = viewModel;

		InitializeComponent();
	}
}
