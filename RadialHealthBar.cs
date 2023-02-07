using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// TODO make this more general not just for health
public class RadialHealthBar : MonoBehaviour
{
    [SerializeField]
    private Image _image;

    [SerializeField]
    private Gradient _barColor;

    void Start()
    {

    }

    public void UpdateUI(int currentHealth, int maxHealth)
    {
        float fillLevel = ((float)currentHealth / (float)maxHealth);
        _image.fillAmount = fillLevel;
        /*
        Debug.Log("Image fill amount: " + _image.fillAmount);
        Debug.Log("currentHealth: " + currentHealth);
        Debug.Log("maxHealth: " + maxHealth);
        */

        _image.color = _barColor.Evaluate(fillLevel);
    }
}
