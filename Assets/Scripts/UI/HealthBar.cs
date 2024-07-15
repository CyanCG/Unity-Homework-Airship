using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image HealthBarImage;

    private void Start()
    {
        WorldEvents.Instance.OnChangeHealth += ChangeHealth;
    }

    private void ChangeHealth(float n)
    {
        HealthBarImage.fillAmount = Mathf.Clamp(n / 100f, 0, 1);
    }
}
