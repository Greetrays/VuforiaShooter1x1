using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void Start()
    {
        _slider.maxValue = _player.MaxHealth;
        _slider.value = _player.MaxHealth;
    }

    private void OnHealthChanged()
    {
        _slider.value = _player.CurrentHealth;
    }
}
