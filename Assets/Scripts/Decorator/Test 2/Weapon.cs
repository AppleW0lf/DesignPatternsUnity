using UnityEngine;

public class Weapon : MonoBehaviour
{
    public virtual void Attack()
    {
        Debug.Log("Basic attack");
    }
}

public class Sword : Weapon
{
    public override void Attack()
    {
        Debug.Log("Swing sword");
    }
}

public class FireSword : Sword
{
    public override void Attack()
    {
        base.Attack();
        Debug.Log("Add fire effect");
    }
}

public class PoisonSword : Sword
{
    public override void Attack()
    {
        base.Attack();
        Debug.Log("Add poison effect");
    }
}