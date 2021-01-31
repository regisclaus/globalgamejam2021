using UnityEngine;
using UnityEngine.InputSystem;
public class EmptyBody : MonoBehaviour {

    [SerializeField] public Line line;

    [SerializeField] private LayerMask groundLayer;

    private void Start() {
        RaycastHit hit;
        if(Physics.Raycast(this.transform.position + Vector3.up, Vector3.down, out hit, 100, groundLayer)) {
            this.transform.SetParent(hit.transform);
        }
    }

}
    
