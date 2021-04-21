using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIManager : MonoBehaviour
{
    [SerializeField] Text score;
    [SerializeField] Text coins;
    [SerializeField] Slider playerHealth;

    GameManager gameManager;
    PlayerController player;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        playerHealth.maxValue = player.Life;
        playerHealth.value = player.Life;

        gameManager = FindObjectOfType<GameManager>();

        score.text = 0.ToString();
        coins.text = 0.ToString();
    }

    void Update()
    {
        playerHealth.value = player.Life;
        score.text = gameManager.Score.ToString();
        coins.text = gameManager.Coins.ToString();
    }


    public void Fire() 
    {
        print("Fire");
    }

    //-------------------------------------------------------------------
    //------------------WEAPONS BUTTONS FUNCIONALITY----------------------
    //-------------------------------------------------------------------

    public void ActivateWeapon_1() 
    {
        print("Activate Weapon 1");
    }
    public void ActivateWeapon_2()
    {
        print("Activate Weapon 2");
    }
    public void ActivateWeapon_3()
    {
        print("Activate Weapon 1");
    }

    //-------------------------------------------------------------------
    //------------------HBILITY BUTTONS FUNCIONALITY----------------------
    //-------------------------------------------------------------------

    public void ActivateHability_1() 
    {
        print("Activate Hability 1");
    }
    public void ActivateHability_2() 
    {
        print("Activate Hability 2");
    }
    public void ActivateHability_3() 
    {
        print("Activate Hability 3");
    }
    public void ActivateHability_4() 
    {
        print("Activate Hability 4");
    }
    public void ActivateHability_5() 
    {
        print("Activate Hability 5");
    }
    //-------------------------------------------------------------------
    //------------------PAUSE BUTTONS FUNCIONALITY----------------------
    //-------------------------------------------------------------------

    public void ActivatePauseMenu() 
    {
        print("Pause");
    }
}
