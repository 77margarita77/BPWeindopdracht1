using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnWall : MonoBehaviour {

    public Transform respawnPos;
    public Transform playerPos;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerPos.position = respawnPos.position;
        }
    }
}