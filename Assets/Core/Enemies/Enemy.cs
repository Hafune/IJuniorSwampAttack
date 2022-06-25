﻿using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;

    private Player _target;

    public Player Target => _target;

    public int Reward => _reward;

    public event UnityAction<Enemy> Dying;

    public void Init(Player target) => _target = target;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health > 0)
            return;

        Dying?.Invoke(this);
        Destroy(gameObject);
    }
}