using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue;
    public float Amount { get; private set; }
    public float MaxValue { get; private set; }
    public event Action<float> AmountChanged;

    private void Start()
    {
        Amount = _maxValue;
        MaxValue = _maxValue;
        AmountChanged?.Invoke(Amount);
    }

    public void TakeDamage(float amount)
    {
        Amount =  Mathf.Clamp(Amount - amount, 0, _maxValue); 
        AmountChanged?.Invoke(Amount);
    }

    public void Heal(float amount)
    {
        Amount = Mathf.Clamp(Amount + amount, 0, _maxValue);
        AmountChanged?.Invoke(Amount);
    }
}