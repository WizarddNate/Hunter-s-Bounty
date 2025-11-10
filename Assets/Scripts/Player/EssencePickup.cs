using UnityEngine;
using TMPro;

public class EssencePickup : MonoBehaviour
{
    public TextMeshProUGUI essenceText;
    public int essenceCount; // { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        essenceCount = 0;

        essenceText.text = ("Essence: " + essenceCount.ToString());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Essence"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider other)
    {
        Destroy(other.gameObject);
        essenceCount += 1;

        essenceText.text = ("Essence: " + essenceCount.ToString());
    }
}
