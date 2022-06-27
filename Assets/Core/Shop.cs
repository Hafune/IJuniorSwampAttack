using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private WeaponView _template;
    [SerializeField] private GameObject _itemContainer;
    [SerializeField] private Player _player;

    private void Start() => _weapons.ForEach(AddItem);

    private void AddItem(Weapon weapon)
    {
        var view = Instantiate(_template, _itemContainer.transform);
        view.Initialize(weapon, TrySell);
        view.SetSale(_player.HasWeapon(view.Weapon));
    }

    private void TrySell(WeaponView view)
    {
        if (view.Weapon.Price > _player.Money)
            return;

        _player.DropMoney(view.Weapon.Price);
        _player.AddWeapon(Instantiate(view.Weapon));
        view.SetSale(true);
    }
}