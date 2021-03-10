using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManagement : MonoBehaviour
{
    [SerializeField]
    private GameObject HUD;
    [SerializeField]
    private GameObject GameOver;
    private bool playerIsAlive;
    [SerializeField]
    Player player;

    void Awake()
    {
        HUD.SetActive(true);
        GameOver.SetActive(false);
    }

    void Update()
    {
        playerIsAlive = player.isAlive();

        if (playerIsAlive == false)
        {
            HUD.SetActive(false);
            GameOver.SetActive(true);
            player.enabled = false;
        }
    }
}
