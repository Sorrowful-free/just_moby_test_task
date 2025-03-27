using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
           .BindInterfacesAndSelfTo<DesktopPlayerInput>()
           .AsSingle()
           .CopyIntoAllSubContainers()
           .NonLazy();

        Container.DeclareSignal<PlayerSpawnedSignal>();
    }
}