using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StroboController : MonoBehaviour
{

    public Renderer renderer;
    public float flashInterval = 0.10f;

    private float lastFlash;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (Time.time >= lastFlash + flashInterval)
        {
            renderer.material.color = Color.white;
            lastFlash = Time.time;
        }
        else
        {
            renderer.material.color = Color.black;
        }
    }

    void OnGUI()
    {
        flashInterval = GUI.HorizontalSlider(new Rect(20, 20, 300, 20), flashInterval, 0.0f, 0.3f);
    }
}
