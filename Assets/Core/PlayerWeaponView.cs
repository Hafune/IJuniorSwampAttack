using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeaponView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Button _button;

    private Action _onClick;

    public void Initialize(Weapon weapon, Action onClick)
    {
        _image.sprite = weapon.Icon;
        _onClick = onClick;
    }

    private void OnClick() => _onClick.Invoke();

    private void OnEnable() => _button.onClick.AddListener(OnClick);

    private void OnDisable() => _button.onClick.RemoveListener(OnClick);
}
