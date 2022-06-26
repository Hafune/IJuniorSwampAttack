using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _label;
    [SerializeField] private TextMeshProUGUI _price;
    [SerializeField] private Button _buyButton;
    
    public void Setup(Weapon weapon)
    {
        _image.sprite = weapon.Icon;
        _label.text = weapon.Label;
        _price.text = weapon.Price.ToString();

        if (!weapon.IsBuyed) 
            return;
        
        _buyButton.interactable = false;
        _price.color = Color.gray;
    }
}
