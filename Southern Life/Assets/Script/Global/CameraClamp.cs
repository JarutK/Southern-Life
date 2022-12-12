using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClamp : MonoBehaviour
{
    [SerializeField] Transform player;
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(player.position.x, -4f, 5f), Mathf.Clamp(player.position.y, -11f, 4f), transform.position.z);
    }
}
