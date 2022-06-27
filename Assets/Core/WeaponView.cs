using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _label;
    [SerializeField] private TextMeshProUGUI _price;
    [SerializeField] private Button _buyButton;

    private Action<WeaponView> _onBuyClick;
    private Weapon _weapon;
    private bool _forSale;

    public Weapon Weapon => _weapon;

    public bool ForSale => _forSale;

    public void Initialize(Weapon weapon, Action<WeaponView> onBuyClick)
    {
        _weapon = weapon;
        _image.sprite = weapon.Icon;
        _label.text = weapon.Label;
        _price.text = weapon.Price.ToString();
        _onBuyClick = onBuyClick;
    }

    public void SetSale(bool forSale)
    {
        _forSale = forSale;
        _buyButton.interactable = !_forSale;
        _price.color = _forSale ? Color.gray : Color.white;
    }

    private void CallBuyAction() => _onBuyClick.Invoke(this);

    private void OnEnable() => _buyButton.onClick.AddListener(CallBuyAction);

    private void OnDisable() => _buyButton.onClick.RemoveListener(CallBuyAction);
}