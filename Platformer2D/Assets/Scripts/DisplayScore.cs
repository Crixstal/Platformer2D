using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    [SerializeField]
    Player player;
    TMPro.TMP_Text text;

    void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
    }

    void Update()
    {
        text.text = player.score.ToString();
    }
}