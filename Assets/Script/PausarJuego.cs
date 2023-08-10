using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausarJuego : MonoBehaviour
{
    public void Pause()
    {
        Debug.Log("BUTTON -> Pause");
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Debug.Log("BUTTON -> Resume");
        Time.timeScale = 1f;
    }
}
