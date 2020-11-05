using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMovement : MonoBehaviour
{

    Material material;
    Vector2 offset;

    public float xVelocity;
    public float yVelocity;
    

    // Start is called before the first frame update
    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    void Start()
    {
        offset = new Vector2(xVelocity, yVelocity);
    }
    // Update is called once per frame
    void Update()
    {
        float Rate = xVelocity * GameManager.WorldSimulationSpeed;
        material.mainTextureOffset += offset * Rate* Time.deltaTime;
    }
}
