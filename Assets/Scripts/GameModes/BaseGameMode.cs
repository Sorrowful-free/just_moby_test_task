using UnityEngine;

// that class just as entry point and "manager" of game state, and game dependencies
// ussually i prefer use it for game rules like CaptureFlagGameMode
// that consist of rules, timer management,spawn logic and other stuff about concreete GameMode
// to be honet it was inspired by UE and their game logic
public abstract class BaseGameMode : MonoBehaviour
{
    private void Start()
    {
        OnBeginPlay();
    }

    private void Oestroy()
    {
        OnEndPlay();
    }

    protected virtual void OnBeginPlay()
    {

    }
    protected virtual void OnEndPlay()
    {

    }
}