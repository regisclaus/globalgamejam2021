using UnityEngine;
using UnityEngine.InputSystem;
public class EmptyBody : MonoBehaviour {

    [SerializeField] private LayerMask emptyBodyLayer;

    private void OnFire() {
           
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());


        Debug.Log(Mouse.current.delta.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, emptyBodyLayer)){
            // the object identified by hit.transform was clicked
            // do whatever you want
            Debug.Log("Cliquei");
        }
    }


}
    
