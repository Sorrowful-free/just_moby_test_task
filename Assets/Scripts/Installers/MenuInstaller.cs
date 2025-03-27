using UnityEngine;
using Zenject;

public class MenuInstaller : MonoInstaller
{
    [SerializeField]
    private MenuViewController _menuViewController;
    [SerializeField]
    private MenuGameMode _menuGameMode;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<MenuModel>()
        .AsSingle()
        .Lazy();

        Container.BindInstance(_menuViewController)
        .AsSingle()
        .NonLazy();

        Container.Inject(_menuGameMode);
    }
}