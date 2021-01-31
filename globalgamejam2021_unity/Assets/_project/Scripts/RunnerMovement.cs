    using UnityEngine;

public class RunnerMovement : MonoBehaviour{

    private void Update() {
        transform.Translate(new Vector3(0,0, GameManager.instance.velocity) * Time.deltaTime);
    }

}