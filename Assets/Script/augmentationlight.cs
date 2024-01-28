using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class augmentationlight : MonoBehaviour
{
    [SerializeField] Light2D light;

    public int finalValueLight;
    public bool topLight = false;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(topLight)
        {
            float desiredValue = finalValueLight;
            float smoothLight = Mathf.Lerp(light.pointLightOuterRadius, finalValueLight, speed);
            light.pointLightOuterRadius = smoothLight;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        topLight = true;
    }
}
