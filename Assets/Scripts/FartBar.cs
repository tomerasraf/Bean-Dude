using UnityEngine;
using UnityEngine.UI;

public class FartBar : MonoBehaviour
{
    public Slider slider;
    public void SetMaxFart(float curFart)
    {
        slider.maxValue = curFart;
        slider.value = curFart;
    }

    public void SetFart(float curFart)
    {
        slider.value = curFart;
    }


}
