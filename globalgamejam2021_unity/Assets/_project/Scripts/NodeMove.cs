using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMove : MonoBehaviour
{
    [SerializeField] private GameObject[] bodyNodes;

    private void Update() {
        transform.Translate(new Vector3(0,0, GameManager.instance.velocity) * Time.deltaTime);
    }
}
