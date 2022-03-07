using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Weapon))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private float _secondBetweenShoot;

    private Weapon _weapon;
    private float _lastShootTime;
    private Animator _animator;
    private int _currentHealth;

    public event UnityAction HealthChanged;

    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;

    private void OnValidate()
    {
        if (_maxHealth <= 0)
        {
            _maxHealth = 50;
        }
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _weapon = GetComponent<Weapon>();
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        _lastShootTime += Time.deltaTime;

        if (_lastShootTime >= _secondBetweenShoot)
        {
            _animator.Play(PlayerAnimatorController.State.Shoot);
            _weapon.Shoot();
            _lastShootTime = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke();

        if (_currentHealth <= 0)
        {
            Debug.Log("ТЫ УМЕР!");
        }
    }
}
