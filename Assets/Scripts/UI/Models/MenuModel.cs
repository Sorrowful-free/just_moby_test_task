using System;
using R3;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class MenuModel : IInitializable, IDisposable
{
    public ReactiveProperty<int> MaxKilledMonsters { get; private set; }
    public ReactiveProperty<float> MaxSurviveTime { get; private set; }

    public ReactiveCommand StartGameCommand { get; private set; }

    public MenuModel()
    {
        MaxKilledMonsters = new ReactiveProperty<int>();
        MaxSurviveTime = new ReactiveProperty<float>();
        StartGameCommand = new ReactiveCommand(StartGame);
    }

    private void StartGame(R3.Unit unit)
    {
        Debug.Log("poehali!");
    }

    public void Initialize()
    {
        MaxKilledMonsters.Value = Random.Range(1, 100);
        MaxSurviveTime.Value = Random.Range(1, 100);
    }

    public void Dispose()
    {
    }
}
