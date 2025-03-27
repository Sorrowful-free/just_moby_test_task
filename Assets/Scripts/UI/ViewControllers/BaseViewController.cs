using System.Threading.Tasks;
using R3;
using UnityEngine;

public abstract class BaseViewController : MonoBehaviour
{
    //composite disposable needs to comfortable disposing all using by that view controller resources like subscription, loaded resource( icons or atlases or gameobjects), and some internal initialized components like listview etc...
    protected CompositeDisposable CompositeDisposable { get; private set; }

    public async void Show()
    {
        CompositeDisposable = new CompositeDisposable();

        await OnBeforeShow();
        gameObject.SetActive(true);
    }

    public async void Hide()
    {
        await OnBeforeHide();
        gameObject.SetActive(false);

        CompositeDisposable?.Dispose();
        CompositeDisposable = null;
    }

    //this methods include potential for animated showing and hiding
    protected virtual Task OnBeforeShow()
    {
        return Task.CompletedTask;
    }

    //this methods include potential for animated showing and hiding
    protected virtual Task OnBeforeHide()
    {
        return Task.CompletedTask;
    }
}

public abstract class BaseViewController<TModel> : BaseViewController where TModel : class
{
    protected TModel Model { get; private set; }

    //tham method NON virtual because child classes myght have different signature for "constructor method"
    protected void Constructor(TModel model)
    {
        Model = model;
    }
}