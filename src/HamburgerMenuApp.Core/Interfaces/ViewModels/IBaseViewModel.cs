using System.ComponentModel;

namespace HamburgerMenuApp.Core.Interfaces.ViewModels;

public interface IBaseViewModel : INotifyPropertyChanged
{
    void OnPropertyChanged(string propertyName);
}