using UnityEngine;
using TMPro;

public class TextDamagePopup : MonoBehaviour
{
    public TextMeshProUGUI text;
    public void SetupText(string _text)
    {
        text.text = _text;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position - Camera.main.transform.position, Camera.main.transform.up);
    }
}
