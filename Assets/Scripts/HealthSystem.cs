using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private CharacterStatsHandler _statsHandler;
    [SerializeField] private TextMeshProUGUI currentHealthText;

    public event Action OnDamage;
    public event Action OnHeal;
    public event Action OnDeath;

    public float CurrentHealth {  get; private set; }

    public float MaxHealth => _statsHandler.CurrentStats.maxHealth;

    private void Awake()
    {
        _statsHandler = GetComponent<CharacterStatsHandler>();
    }

    private void Start()
    {
        CurrentHealth = _statsHandler.CurrentStats.maxHealth;
        currentHealthText.text = CurrentHealth.ToString();
    }

    public bool ChangeHealth(float change)
    {
        if (change == 0)
        {
            return false;
        }

        CurrentHealth += change;
        CurrentHealth = CurrentHealth > MaxHealth ? MaxHealth : CurrentHealth;
        CurrentHealth = CurrentHealth < 0 ? 0 : CurrentHealth;

        if (change > 0)
        {
            OnHeal?.Invoke();
            ChangeHealthText();
        }
        else
        {
            OnDamage?.Invoke();
            ChangeHealthText();
        }

        if (CurrentHealth <= 0f)
        {
            CallDeath();
        }

        return true;
    }

    public void ChangeHealthText()
    {
        currentHealthText.text = ((int)CurrentHealth).ToString();
    }

    private void CallDeath()
    {
        OnDeath?.Invoke();
    }
}
