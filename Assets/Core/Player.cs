using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] private UnityEvent<float> _onHealthChanged;
    [SerializeField] private UnityEvent<string> _onMoneyChanged;
    [SerializeField] private int _maxHealth;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;

    private Weapon _currentWeapon;
    private int _currentHealth;
    private MyPlayerInput _input;

    public int Money { get; private set; }

    public void Shoot(PointerEventData eventData) => _currentWeapon.Shoot(_shootPoint);

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        _onHealthChanged?.Invoke((float) _currentHealth / _maxHealth);

        if (_currentHealth <= 0)
            Destroy(gameObject);
    }

    public void AddMoney(int money)
    {
        Money += money;
        _onMoneyChanged?.Invoke(Money.ToString());
    }

    public void DropMoney(int money)
    {
        Money -= money;
        _onMoneyChanged?.Invoke(Money.ToString());
    }

    private void Awake() => _input = new MyPlayerInput();

    private void OnEnable() => _input.Enable();

    private void OnDisable() => _input.Disable();

    private void Start()
    {
        _currentWeapon = _weapons[0];
        _currentHealth = _maxHealth;
    }
}