using HamburgerMenuApp.Core.Models;

namespace HamburgerMenuApp.Core.Interfaces.ViewModels;

public interface IHomePageViewModel : IBasePageViewModel
{
    public List<Card> Cards { get; }
}
