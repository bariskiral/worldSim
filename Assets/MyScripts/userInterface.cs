using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userInterface : MonoBehaviour
{
    private WindZone wind;
    public roadCreate rc;
    public GameObject itemMenu;
    public GameObject calculationMenu;
    [SerializeField] private int menuCounter = 0;

    void Update()
    {
        

        if (gameObject != null)
        {
            GameObject gameObject = GameObject.FindWithTag("Ground");
            wind = gameObject.GetComponent<WindZone>();

        }

        if (Input.GetKeyDown(KeyCode.Tab)){
            menuCounter++;
            if(menuCounter % 2 == 1)
            {
                itemMenu.SetActive(true);
                calculationMenu.SetActive(true);
            }
            else
            {
                itemMenu.SetActive(false);
                calculationMenu.SetActive(false);
            }
        }

    }

    public void windSpeedSlider(float newValue)
    {  
        wind.windMain = newValue;
    }

    public void windRotationClockwise()
    {

        GameObject gameObject = GameObject.FindWithTag("Ground");
        gameObject.transform.Rotate(0, 20, 0);

    }

    public void windRotationAntiClockwise()
    {
        GameObject gameObject = GameObject.FindWithTag("Ground");
        gameObject.transform.Rotate(0, -20, 0);
    }

    public void roadButtonToggled(bool roadValue)
    {
        rc.GetComponent<roadCreate>();
        if (roadValue)
        {
            rc.enabled = true;
        }
        if(!roadValue)
        {
            rc.enabled = false;
        }
            
    }
}
