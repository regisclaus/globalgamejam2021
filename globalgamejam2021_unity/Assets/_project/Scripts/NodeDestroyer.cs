using UnityEngine;

public class NodeDestroyer : MonoBehaviour{
    [SerializeField] private Transform playerTransform;

    private float zOffset;

    private void Start() {
        zOffset = this.transform.position.z - playerTransform.transform.position.z;
    }

    private void Update() {
        transform.position = new Vector3(0,0, playerTransform.position.z + zOffset);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "LimitBegin") {
            Destroy(other.transform.parent.gameObject);
        }
    }

}