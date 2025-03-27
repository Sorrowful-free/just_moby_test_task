using R3;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public readonly ReactiveProperty<int> CurrentHealth = new ReactiveProperty<int>();
    public readonly ReactiveProperty<int> MaxHealth = new ReactiveProperty<int>();
    public readonly ReactiveProperty<float> HeathPercentage = new ReactiveProperty<float>();
    public readonly ReactiveCommand IsDead = new ReactiveCommand();

    public void Setup(int initialHealth, int maxHealt)
    {
        CurrentHealth.Value = initialHealth;
        MaxHealth.Value = maxHealt;
    }

    // yeah i know we can heal by negative damage but validation wasnot as a requirement :D
    public void TakeDamage(int damage)
    {
        CurrentHealth.Value -= Mathf.Min(CurrentHealth.Value, damage);
        HeathPercentage.Value = (float)CurrentHealth.Value / (float)MaxHealth.Value;
        if (CurrentHealth.Value <= 0)
        {
            IsDead.Execute(default);
        }
    }

}