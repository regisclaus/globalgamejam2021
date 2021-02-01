using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLose : MonoBehaviour
{
    private void OnCollisionStay(Collision other) {
        if(other.gameObject.tag == "Wall") {
            GameManager.instance.LoseGame();
        }
    }
    
    private void OnTriggerStay(Collider other) {
        if(other.gameObject.tag == "Wall") {
            GameManager.instance.LoseGame();
        }
    }
}
