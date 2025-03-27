using System.Threading.Tasks;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MenuViewController : BaseViewController<MenuModel>
{
    [SerializeField]
    private TextMeshProUGUI _maxSurviveTime;
    [SerializeField]
    private TextMeshProUGUI _maxKilledMonsters;
    [SerializeField]
    private Button _startGameButton;

    [Inject]
    protected new void Constructor(MenuModel menuModel)
    {
        base.Constructor(menuModel);
    }

    protected override Task OnBeforeShow()
    {
        Model
            .MaxKilledMonsters
            .Subscribe(v => _maxKilledMonsters.text = FakeMaxKilledMonstersLocalization(v))
            .AddTo(CompositeDisposable);
        Model
            .MaxSurviveTime
            .Subscribe(v => _maxSurviveTime.text = FakeMaxSurvivedTimeLocalization(v))
            .AddTo(CompositeDisposable);

        _startGameButton.onClick.AddListener(StartGame);
        return base.OnBeforeShow();
    }

    private void StartGame()
    {
        Model.StartGameCommand.Execute(Unit.Default);
    }

    protected override Task OnBeforeHide()
    {
        _startGameButton.onClick.RemoveListener(StartGame);
        return base.OnBeforeHide();
    }

    private string FakeMaxKilledMonstersLocalization(int maxAmount)
    {
        return $"мах {maxAmount:D5} кубов убито";
    }

    private string FakeMaxSurvivedTimeLocalization(float maxDuration)
    {
        return $"мах {maxDuration:0.0} сек выживал";
    }
}