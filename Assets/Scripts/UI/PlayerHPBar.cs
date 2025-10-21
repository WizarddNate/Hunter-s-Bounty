using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour
{
    [SerializeField] private Image _healthbarSprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void UpdateHealthbar(float maxhealth, float currentHealth)
    {
        float _health = currentHealth / maxhealth;
        _healthbarSprite.fillAmount = _health;

        //Debug.Log("current health: " + currentHealth + ", max health: " + maxhealth + ", divided: " + (currentHealth / maxhealth));
        //Debug.Log("healthbar: " + _health);
    }
}
