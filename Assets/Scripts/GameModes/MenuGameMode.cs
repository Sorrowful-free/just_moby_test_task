using UnityEngine;
using Zenject;

// that class just as entry point and "manager" of game state, and game dependencies
// ussually i prefer use it for game rules like CaptureFlagGameMode
// that consist of rules, timer management,spawn logic and other stuff about concreete GameMode
// to be honet it was inspired by UE and their game logic
public class MenuGameMode : BaseGameMode
{
    private MenuViewController _menuViewController;
    [Inject]
    protected void Constructor(MenuViewController menuViewController)
    {
        _menuViewController = menuViewController;
    }
    protected override void OnBeginPlay()
    {
        base.OnBeginPlay();
        _menuViewController.Show();
    }

    protected override void OnEndPlay()
    {
        base.OnEndPlay();
        _menuViewController.Hide();
    }
}