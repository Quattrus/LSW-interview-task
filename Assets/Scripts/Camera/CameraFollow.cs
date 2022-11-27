using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    private Vector3 cameraOffset = new Vector3(0, 0, -15f);


    private void Update()
    {
        FollowPlayer();
    }


    private void FollowPlayer()
    {
        transform.position = player.transform.position + cameraOffset;
    }
}
