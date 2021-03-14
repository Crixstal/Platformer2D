using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManagement : MonoBehaviour
{
    private bool playerIsAlive;
    [SerializeField]
    private GameObject HUD = null;
    [SerializeField]
    private GameObject GameOver = null;
    [SerializeField]
    private Player player = null;

    void Awake()
    {
        HUD.SetActive(true);
        GameOver.SetActive(false);
    }

    void Update()
    {
        playerIsAlive = player.IsAlive();

        if (playerIsAlive == false)
        {
            HUD.SetActive(false);
            GameOver.SetActive(true);
            player.enabled = false;
        }
    }
}
