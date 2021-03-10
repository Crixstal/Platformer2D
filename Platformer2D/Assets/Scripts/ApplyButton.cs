using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplyButton : MonoBehaviour
{
    public void quit()
    {
        Application.Quit();
    }

    public void restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
