using UnityEngine;

public class GivePlayerControls : MonoBehaviour
{

    GameObject player;
    MovementSM _MSM;
    ActionsSM _ASM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        _MSM = player.GetComponent<MovementSM>();
        _ASM = player.GetComponent<ActionsSM>();


        _MSM.inputActions.FindActionMap("Player").Enable();
        _ASM.inputActions.FindActionMap("Player").Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
