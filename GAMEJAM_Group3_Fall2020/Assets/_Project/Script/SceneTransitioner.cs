using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{
    UI_Menu menuItem;
    bool WasButtonPressed;
    public Animator transition;
    public float transitionTime = 1f;
    public string Scene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(menuItem == null)
        {
            menuItem = GameObject.Find("Canvas").GetComponent<UI_Menu>();            
            if(menuItem == null)
            {
                return;
            }
        }

        WasButtonPressed = menuItem.ButtonPressed;
        if (WasButtonPressed == true)
        {
            StartCoroutine(LoadMyScene());
        }
    }

    IEnumerator LoadMyScene()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(Scene);
    }
}
