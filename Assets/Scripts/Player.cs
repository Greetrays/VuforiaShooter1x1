using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Weapon))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _secondBetweenShoot;

    private Weapon _weapon;
    private float _lastShootTime;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _weapon = GetComponent<Weapon>();
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
        _health -= damage;

        if (_health <= 0)
        {
            Debug.Log("ТЫ УМЕР!");
        }
    }
}
