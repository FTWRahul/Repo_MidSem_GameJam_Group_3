using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Menu : MonoBehaviour
{
    public bool ButtonPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void StartButton()
    {
        ButtonPressed = true;
    }
}
