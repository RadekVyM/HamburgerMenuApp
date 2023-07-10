using HamburgerMenuApp.Core.Interfaces.ViewModels;
using HamburgerMenuApp.Core.Models;

namespace HamburgerMenuApp.Core.ViewModels;

public class HomePageViewModel : BasePageViewModel, IHomePageViewModel
{
    public List<Card> Cards { get; private set; } = new List<Card>
    {
        new Card
        {
            Title = "Sender",
            Text = "Lorem ipsum is simply dummy text of the typesetting industry.",
            Image = "sender.png"
        },
        new Card
        {
            Title = "Carrier",
            Text = "Lorem ipsum is simply dummy text of the typesetting industry.",
            Image = "carrier.png"
        },
        new Card
        {
            Title = "Receiver",
            Text = "Lorem ipsum is simply dummy text of the typesetting industry.",
            Image = "receiver.png"
        },
    };
}
