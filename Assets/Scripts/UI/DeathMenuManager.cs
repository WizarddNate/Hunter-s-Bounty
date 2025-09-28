using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class DeathMenuManager : MonoBehaviour
{
    public static DeathMenuManager instance;

    private void Awake()
    {
        if (DeathMenuManager.instance == null) instance = this;
        else Destroy (gameObject);
    }

    public void GameOver()
    {
        BetterUIManager _ui = GetComponent<BetterUIManager>();
        if (_ui != null)
        {
            _ui.ToggleDeathPanel();
            
        }
    }
}
