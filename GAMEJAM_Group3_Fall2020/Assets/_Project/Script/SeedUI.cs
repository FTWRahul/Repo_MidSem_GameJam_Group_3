using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SeedUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    
    public void IncrementScore()
    {
        scoreText.text = SeedCollectable.numOfSeeds.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
