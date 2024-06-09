using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecAttackBar : MonoBehaviour
{
    [SerializeField] private Image _specialAttackReloadImage;
    [SerializeField] private GameObject _charE;

    private void Awake()
    {
        UnityEvents.UpdateSpecAttackReloadBar.AddListener(SpecAttackReload);
    }

    public void SpecAttackReload(float reload)
    {
        StartCoroutine(UpdateRelaodBar(reload));
    }

    public IEnumerator UpdateRelaodBar(float reload)
    {
        _specialAttackReloadImage.fillAmount = 0;
        _charE.SetActive(false);
        float curTime = 0f;

        while (curTime < reload)
        {
            curTime += Time.deltaTime;
            _specialAttackReloadImage.fillAmount = curTime / reload;
            yield return null;
        }

        _specialAttackReloadImage.fillAmount = 1;
        _charE.SetActive(true);
    }
}
