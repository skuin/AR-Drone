using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    Light redLight;
    public float blinkingTime;
    // Start is called before the first frame update
    void Start()
    {
        redLight = GetComponent<Light>();
        StartCoroutine(Flashing());
    }

    IEnumerator Flashing()
    {   
        while(true){
            yield return new WaitForSeconds(blinkingTime);
            redLight.enabled = !redLight.enabled;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
