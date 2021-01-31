using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] possiblesNodes;

    [SerializeField] private Transform playerTransform;

    private bool isCollidable;

    private float zOffset;

    private void Start() {
        Invoke("BeginCollider", 0.5f);
        zOffset = this.transform.position.z - playerTransform.transform.position.z;
    }

    private void Update() {
        transform.position = new Vector3(0,0, playerTransform.position.z + zOffset);
    }

    public void BeginCollider() {
        isCollidable = true;
    }

    private void OnTriggerEnter(Collider other) {
        if(isCollidable) {
            if(other.gameObject.tag == "LimitBegin") {
                Instantiate(possiblesNodes[Random.Range(1,possiblesNodes.Length)], this.transform.position, this.transform.rotation);
                isCollidable = false;
                Invoke("BeginCollider", 0.5f);
            }
        }
    }
}
