using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    public CharacterController controller;

    void OnTriggerEnter(Collider other)
    {
        controller.enabled = false; 
        player.transform.position=respawnPoint.transform.position;
        controller.enabled = true; 
    }
}
