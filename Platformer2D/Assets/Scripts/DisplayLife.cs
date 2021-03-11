using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayLife : MonoBehaviour
{
    [SerializeField]
    private Player player = null;
    private TMPro.TMP_Text text;

    void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
    }

    void Update()
    {
        text.text = player.life.ToString();
    }
}
