using UnityEngine;
using UnityEngine.UI;

public class DashBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;

    public Image fill;

    public void SetMaxDash(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetDash(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
