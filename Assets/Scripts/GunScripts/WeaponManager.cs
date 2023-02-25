using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject[] weapons;
    private int index;
    public float switchDelay = 1f;
    private bool isSwitching;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Q)  && !isSwitching)
        {
            index++;
            if(index >= weapons.Length)
            {
                index = 0;
            }

            StartCoroutine(switchWeaponDelay(index));
        } 
        else if(Input.GetKey(KeyCode.E) && !isSwitching)
        {
            index--;
            if(index < 0)
            {
                index = weapons.Length -1;
            }

            StartCoroutine(switchWeaponDelay(index));
        }
    }

    IEnumerator switchWeaponDelay(int newIndex)
    {
        isSwitching = true;
        yield return new WaitForSeconds(switchDelay);
        isSwitching = false;
        SwitchWeapons(newIndex);
    }

    void intializeWeapons()
    {
        for(int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }

        weapons[0].SetActive(true);
    }

    void SwitchWeapons(int newIndex)
    {
        for(int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }

        weapons[newIndex].SetActive(true);
    }
}
