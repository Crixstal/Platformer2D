using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManagement : MonoBehaviour
{
    private bool playerIsAlive;
    private bool bossIsAlive;
    [SerializeField]
    private GameObject HUD = null;
    [SerializeField]
    private GameObject GameOver = null;
    [SerializeField]
    private Player player = null;
    [SerializeField]
    private Boss boss = null;

    void Awake()
    {
        HUD.SetActive(true);
        GameOver.SetActive(false);
    }

    void Update()
    {
        playerIsAlive = player.IsAlive();
        bossIsAlive = boss.IsAlive();

        if (!playerIsAlive || !bossIsAlive)
        {
            HUD.SetActive(false);
            GameOver.SetActive(true);
            player.enabled = false;
        }
    }
}
