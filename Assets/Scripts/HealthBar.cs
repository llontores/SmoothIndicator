using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _duration = 0.5f;
    [SerializeField] private Slider _slider;

    private Coroutine _changeHPJob;

    private void OnEnable()
    {
        _health.AmountChanged += ChangeHPWork;
    }

    private void OnDisable()
    {
        _health.AmountChanged -= ChangeHPWork;
    }

    private IEnumerator ChangeHP(float target)
    {
        float startValue = _slider.value * _health.MaxValue;
        float elapsedTime = 0f;

        while (elapsedTime < _duration)
        {
            elapsedTime += Time.deltaTime;
            float current = Mathf.Lerp(startValue, target, elapsedTime / _duration);
            _slider.value = current / _health.MaxValue;
            yield return null;
        }

        _slider.value = target / _health.MaxValue;
    }

    private void ChangeHPWork(float target)
    {
        if (_changeHPJob != null)
            StopCoroutine(_changeHPJob);

        _changeHPJob = StartCoroutine(ChangeHP(target));
    }
}