using System;
using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Cat _cat;
    [SerializeField] private TMP_Text _healthDisplay;

    private void OnEnable()
    {
        _cat.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _cat.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        _healthDisplay.text = health.ToString();
    }
}
