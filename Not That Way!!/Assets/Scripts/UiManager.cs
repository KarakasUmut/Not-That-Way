using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public GameObject FinishScreen;
    public GameObject RestartButton;

    public void finishScreen()
    {
        FinishScreen.SetActive(true);
    }
}
