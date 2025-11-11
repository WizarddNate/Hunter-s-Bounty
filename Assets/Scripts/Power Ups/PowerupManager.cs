using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    [SerializeField] GameObject powerupSelectionUI;

    [SerializeField] GameObject powerupPrefab;

    [SerializeField] Transform powerupPositionOne;
    [SerializeField] Transform powerupPositionTwo;
    [SerializeField] Transform powerupPositionThree;

    [SerializeField] List<PowerupSO> powerUps;

    GameObject powerOne, powerTwo, powerThree;

    List<PowerupSO> alreadySelectedPowers = new List<PowerupSO>();

    public static PowerupManager Instance;

    public void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        RandomizeNewPowers();
    }

    void RandomizeNewPowers()
    { 
        if (powerOne !=  null) Destroy(powerOne);
        if (powerTwo != null) Destroy(powerTwo);
        if (powerThree != null) Destroy(powerThree);

        List<PowerupSO> randomizedPowers = new List<PowerupSO>();

        List<PowerupSO> avaliablePowers = new List<PowerupSO>(powerUps);
        avaliablePowers.RemoveAll(power => 
            power.isUnique && alreadySelectedPowers.Contains(power) 
            || power.unlockLevel > GameManager.instance.GetCurrentLevel()
        ); //prevents unqiue powerup from being selected again

        if (avaliablePowers.Count < 3)
        {
            Debug.Log("Not enough powers avaliable");
            return;
        }

        while (randomizedPowers.Count < 3)
        {
            PowerupSO randomPower = avaliablePowers[Random.Range(0, avaliablePowers.Count)];
            if (!randomizedPowers.Contains(randomPower))
            {
                randomizedPowers.Add(randomPower);
            }
        }

        powerOne = InstantiatePower(randomizedPowers[0], powerupPositionOne);
        powerTwo = InstantiatePower(randomizedPowers[1], powerupPositionTwo);
        powerThree = InstantiatePower(randomizedPowers[2], powerupPositionThree);
    }

    GameObject InstantiatePower(PowerupSO powerupSO, Transform position)
    {
        GameObject powerGO = Instantiate(powerupPrefab, position.position, Quaternion.identity, position);
        Power power = powerGO.GetComponent<Power>();
        power.Setup(powerupSO);
        return powerGO;
    }

    public void SelectPower(PowerupSO selectedPower)
    {
        if (!alreadySelectedPowers.Contains(selectedPower))
        {
            alreadySelectedPowers.Add(selectedPower);
        }

        //go to next level
    }
}
