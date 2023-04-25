using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRotation : MonoBehaviour
{
    bool randomising = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RandomRotation());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RandomRotation()
    {
        while(randomising == true)
        {
            transform.rotation = Random.rotation;
            yield return new WaitForSeconds(5f);
        }
    }
}
