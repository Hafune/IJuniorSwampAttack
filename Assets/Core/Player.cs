using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Animator _animator;

    private Weapon _currentWeapon;
    private int _currentHealth;
    private MyPlayerInput _input;

    public int Money { get; private set; }

    public void OnEnemyDied(int reward) => Money += reward;

    private void Awake() => _input = new MyPlayerInput();

    private void OnEnable() => _input.Enable();

    private void OnDisable() => _input.Disable();

    private void Start()
    {
        _currentWeapon = _weapons[0];
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        if (_input.Touch.TouchPress.WasPressedThisFrame())
        {
            _currentWeapon.Shoot(_shootPoint);
        }
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
            Destroy(gameObject);
    }

    public void AddMoney(int money) => Money += money;
}