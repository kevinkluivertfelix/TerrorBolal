using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Wall _wall;
    [SerializeField] private Text healthText;

    void Start()
    {
        _wall = _wall.GetComponent<Wall>();
    }
    void FixedUpdate()
    {
        healthText.text = _wall.wallHealth.ToString();
    }

}
