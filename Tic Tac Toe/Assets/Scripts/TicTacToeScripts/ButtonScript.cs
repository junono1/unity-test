using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Sprite nothing_image;
    public Image image;

    public void SendInfo()
    {
        image = gameObject.GetComponent<Image>();
        if (image.sprite == nothing_image)
        {
            MainLogicScript.button = this.gameObject.name;
            MainLogicScript.Instance.ButtonClick();
        }
    }
}
