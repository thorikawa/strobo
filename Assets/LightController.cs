using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light light;
    public GameObject plate;
    private float rotationSpeedPerFrame = 3f * 2.0f * Mathf.PI / 60.0f;
    private float flashInterval = 0.10f;

    private int lightingFrame = 2;
    private float lastFlash;
    private int lightFrameCount = 0;

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
            light.intensity = 2.0f;
            if (lightFrameCount++ >= lightingFrame)
            {
                lastFlash = Time.time;
            }
        }
        else
        {
            light.intensity = 0.0f;
            lightFrameCount = 0;
        }

        plate.transform.RotateAroundLocal(plate.transform.up, rotationSpeedPerFrame);
    }

    void OnGUI()
    {
        var tmpFlashInterval = GUI.HorizontalSlider(new Rect(20, 20, 300, 20), flashInterval, 0.0f, 0.3f);
        if (Mathf.Abs(tmpFlashInterval - flashInterval) > float.Epsilon)
        {
            flashInterval = tmpFlashInterval;
        }
    }
}
