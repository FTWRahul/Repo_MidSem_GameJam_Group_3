using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{
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
        WasButtonPressed = GameObject.Find("Canvas").GetComponent<UI_Menu>().ButtonPressed;
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
