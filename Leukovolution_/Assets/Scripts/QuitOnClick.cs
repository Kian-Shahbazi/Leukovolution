using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitOnClick : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("Button geklickt - Spiel wird beendet");
        Application.Quit();
    }
}
