using UnityEngine;

namespace Assets.Scripts.Decorator.Test3.Bad
{
    public class AddFixedDamageInteractable : Interactable
    {
        [SerializeField] private float _addDamage = 10f;

        protected override void Interact(PlayerDamageController playerDamageController)
        {
            playerDamageController.AddFixedDamage(_addDamage);
        }
    }
}