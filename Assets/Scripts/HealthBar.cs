using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private Text _hpText;

    private void Awake()
    {
        UnityEvents.UpdateUIHealthBar.AddListener(UpdateHealthBar);
    }

    public void UpdateHealthBar(float curHP, float maxHP)
    {
        _healthBar.fillAmount = curHP / maxHP;
        _hpText.text = $"{curHP} / {maxHP}";
    }
}
