using System;

public class PlayerModel
{
    private int _health = 100;

    public event Action<int> OnHealthChanged;

    public void TakeDamage(int damage)
    {
        _health -= damage;
        OnHealthChanged?.Invoke(_health);
    }
}