using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public int wallHealth;
    public void WallHit(int damage)
    {
        wallHealth -= damage;
    }
}
