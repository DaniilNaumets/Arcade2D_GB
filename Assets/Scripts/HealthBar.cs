using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private Text _text;

    private void Awake()
    {
        _healthBar = GetComponent<Image>();
        UnityEvents.UpdateUIHealthBar.AddListener(UpdateHealthBar);
    }

    public void UpdateHealthBar(float curHP, float maxHP)
    {
        _healthBar.fillAmount = curHP / maxHP;
        _text.text = $"{curHP} / {maxHP}";
    }
}
