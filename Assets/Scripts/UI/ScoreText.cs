using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    public TMP_Text[] Texts;

    private void Start()
    {
        WorldEvents.Instance.OnChangeScore += ChangeScore;
    }

    private void ChangeScore(int n)
    {
        foreach (var txt in Texts)
        {
            txt.text = $"{n}";
        }
    }
}
