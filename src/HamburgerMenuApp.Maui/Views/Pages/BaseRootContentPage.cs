using HamburgerMenuApp.Core.Interfaces.Services;

namespace HamburgerMenuApp.Maui.Views.Pages;

public class BaseRootContentPage : BaseContentPage
{
	public BaseRootContentPage(INavigationService navigationService) : base(navigationService)
    {
	}

    protected override void OnSafeAreaChanged(Thickness safeArea)
    {
        Padding = new Thickness(safeArea.Left, 0, safeArea.Right, safeArea.Bottom);
    }
}
