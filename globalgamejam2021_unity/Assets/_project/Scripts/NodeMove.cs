using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMove : MonoBehaviour
{
    [SerializeField] private GameObject[] bodyNodes;

    private int actualIndex = 0;

    [SerializeField] private float velocity = -5.0f;

    private void Update() {
        transform.Translate(new Vector3(0,0, velocity) * Time.deltaTime);
        if(transform.position.z <= -30) {
            
            // Reposiciona node
            transform.position = new Vector3(0, 0, 30);

            // Desativa corpo atual
            bodyNodes[actualIndex].SetActive(false);

            // Sorteia e ativa novo corpo
            actualIndex = Random.Range(1, bodyNodes.Length);
            bodyNodes[actualIndex].SetActive(true);
            
        }
    }
}
