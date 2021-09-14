using UnityEngine;
using UnityEngine.UI;

public class FartBar : MonoBehaviour
{
    public Image fillGasImage;
    public void SetMaxFart(float curFart)
    {
        fillGasImage.fillAmount = curFart;
    }

    public void SetFart(float curFart)
    {
        fillGasImage.fillAmount = curFart;
    }


}
