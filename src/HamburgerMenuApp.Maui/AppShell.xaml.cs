﻿using SimpleToolkit.Core;
using SimpleToolkit.SimpleShell;

namespace HamburgerMenuApp.Maui;

public partial class AppShell : SimpleShell
{
    private const string FlyoutAnimationKey = "FlyoutAnimation";
    private const double FlyoutBackdropOpacity = 0.2;

    private double flyoutWidth => 285 + safeArea.Left;
    private Thickness safeArea;


    public AppShell()
	{
		InitializeComponent();

        Loaded += AppShellLoaded;

        HideFlyout();
    }


    private static void AppShellLoaded(object sender, EventArgs e)
    {
        var shell = sender as AppShell;

        shell.Window.SubscribeToSafeAreaChanges(safeArea =>
        {
            shell.safeArea = safeArea;

            shell.rootPageContainer.Padding = new Thickness(0, safeArea.Top, 0, 0);
            shell.navBar.Padding = new Thickness(safeArea.Left, 0, safeArea.Right, 0);
            shell.flyoutContent.Padding = new Thickness(safeArea.Left, safeArea.Top, 0, safeArea.Bottom);
            shell.UpdateFlyoutWidth();
        });
    }

    private void ShowFlyout(bool animated = false)
    {
        flyoutBackdrop.InputTransparent = false;

        if (!animated)
        {
            flyout.TranslationX = 0;
            flyoutBackdrop.Opacity = FlyoutBackdropOpacity;
            return;
        }

        flyout.AbortAnimation(FlyoutAnimationKey);

        var animation = new Animation(v =>
        {
            flyout.TranslationX = -flyoutWidth * v;
            flyoutBackdrop.Opacity = FlyoutBackdropOpacity * (1 - v);
        }, 1, 0);

        animation.Commit(flyout, FlyoutAnimationKey, easing: Easing.CubicOut, finished: (v, b) =>
        {
            flyout.TranslationX = 0;
            flyoutBackdrop.Opacity = FlyoutBackdropOpacity;
        });
    }

    private void HideFlyout(bool animated = false)
    {
        flyoutBackdrop.InputTransparent = true;

        if (!animated)
        {
            flyout.TranslationX = -flyoutWidth;
            flyoutBackdrop.Opacity = 0;
            return;
        }

        flyout.AbortAnimation(FlyoutAnimationKey);

        var animation = new Animation(v =>
        {
            flyout.TranslationX = -flyoutWidth * v;
            flyoutBackdrop.Opacity = FlyoutBackdropOpacity * (1 - v);
        });

        animation.Commit(flyout, FlyoutAnimationKey, easing: Easing.CubicIn, finished: (v, b) =>
        {
            flyout.TranslationX = -flyoutWidth;
        });
    }

    private void UpdateFlyoutWidth()
    {
        flyout.WidthRequest = flyoutWidth;

        if (flyout.TranslationX < 0)
            HideFlyout();
        else
            ShowFlyout();
    }

    private async void ItemClicked(object sender, EventArgs e)
    {
        var button = sender as ContentButton;
        var shellItem = button.BindingContext as BaseShellItem;

        HideFlyout(true);

        if (!CurrentState.Location.OriginalString.Contains(shellItem.Route))
            await this.GoToAsync($"///{shellItem.Route}", true);
    }

    private void MenuClicked(object sender, EventArgs e)
    {
        ShowFlyout(true);
    }

    private void CloseFlyoutClicked(object sender, EventArgs e)
    {
        HideFlyout(true);
    }

    private void FlyoutBackdropTapped(object sender, TappedEventArgs e)
    {
        HideFlyout(true);
    }
}
