using System;
using Zenject;

public class GameModel : IInitializable, IDisposable
{
    private readonly SignalBus _signalBus;

    protected GameModel(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    public void Initialize()
    {
        _signalBus.Subscribe<PlayerSpawnedSignal>(_signalBus_PlayerSpawnedSignal);
    }
    public void Dispose()
    {
        _signalBus.Unsubscribe<PlayerSpawnedSignal>(_signalBus_PlayerSpawnedSignal);
    }


    private void _signalBus_PlayerSpawnedSignal(PlayerSpawnedSignal signal)
    {

    }
}