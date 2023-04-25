using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodControl : MonoBehaviour
{
    public bool enteringPod = false;
    public bool isInPod = false;
    public Transform pod;
    public Transform player;
    public Transform bold;
    public Transform lookTarget;
    public float speed = 50f;
    public PodRotation rotateMe;
    public NoiseWander noiseWander;
    public Boid boldScript;
    public Collider sphereTrigger;
    public FPSController fpsController;


    IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        coroutine = MatchPod();
    }

    // Update is called once per frame
    void Update()
    {
        if (enteringPod == true)
        {
            StartCoroutine(MatchPod());
            boldScript.enabled = false;
            fpsController.enabled = false;
        }

        if (player.position == pod.position && player.rotation == bold.rotation)
        {
            enteringPod = false;
            sphereTrigger.enabled = false;
            StopCoroutine(coroutine);
            isInPod = true;
        }

        if (isInPod == true)
        {
            var step = speed * Time.deltaTime;
            player.position = Vector3.MoveTowards(player.position, pod.position, step * 100);
            //       fpsController.enabled = true;
            fpsController.enabled = true;
            fpsController.speed = 0;
            boldScript.enabled = true;
        }

        if (isInPod == true && Input.GetKeyDown(KeyCode.Z))
        {
            fpsController.speed = 50;
            isInPod = false;
        }
    }

    IEnumerator MatchPod()
    {
        var step = speed * Time.deltaTime;
        player.position = Vector3.MoveTowards(player.position, pod.position, step);
        player.rotation = Quaternion.RotateTowards(player.rotation, bold.rotation, step * 5);
        StopCoroutine(coroutine);
        yield return null;
    }

    private void OnTriggerEnter(Collider other)
    {
        enteringPod = true;
        Debug.Log("Player has entered pod");
        rotateMe.enabled = false;
    }
}
