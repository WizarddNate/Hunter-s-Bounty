using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class BetterUIManager : MonoBehaviour
{
    [SerializeField] GameObject deathPanel;

    public void ToggleDeathPanel()
    {
        deathPanel.SetActive(!deathPanel.activeSelf);
    }
}
