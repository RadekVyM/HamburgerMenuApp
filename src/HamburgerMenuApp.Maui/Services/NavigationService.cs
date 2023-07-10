using HamburgerMenuApp.Core.Interfaces.Services;
using HamburgerMenuApp.Core.Interfaces.ViewModels;

namespace HamburgerMenuApp.Maui.Services;

public class NavigationService : INavigationService
{
    private const string ParametersKey = "Parameters";

    private readonly IList<PageType> rootPages = new List<PageType> {
        PageType.HomePage,
        PageType.MyPostPage,
        PageType.ChatPage,
        PageType.InviteFriendsPage,
        PageType.NotificationPage,
        PageType.AboutUsPage,
        PageType.SupportPage,
        PageType.FaqPage,
    };


    public NavigationService()
    {
    }


    public void GoBack()
    {
        Shell.Current.GoToAsync("..");
    }

    public async void GoTo(PageType pageType, IParameters parameters = null)
    {
        await Shell.Current.GoToAsync(GetPageRoute(pageType), true, new Dictionary<string, object>
        {
            [ParametersKey] = parameters
        });
    }

    private string GetPageRoute(PageType pageType)
    {
        if (rootPages.Contains(pageType))
            return $"///{pageType.ToString()}";
        return pageType.ToString();
    }
}