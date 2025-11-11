using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{
    [SerializeField] Image powerImageRenderer;
    [SerializeField] TextMeshPro powerTextRenderer;

    private PowerupSO powerInfo;

    public void Setup(PowerupSO power)
    {
        powerInfo = power;
        powerImageRenderer.sprite = power.image;
        powerTextRenderer.text = power.text;
    }

    //currently doesnt work. Look into ways to make the cards interactable. Maybe they need to be buttons?
    private void OnMouseDown()
    {
        Debug.Log("Power card clicked");
        PowerupManager.Instance.SelectPower(powerInfo);
    }
}
