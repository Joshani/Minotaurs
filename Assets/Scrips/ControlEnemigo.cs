using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // Importante siempre que utilizamos inteligencia artifial agregar esta parte 

public class ControlEnemigo : MonoBehaviour
{
    // Hagop referencia al Nav del enemigo
    NavMeshAgent agent;
    public Transform[] targets;
    int nextTarget;
    public float stopDistance = 1;

    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, targets[nextTarget].position) < stopDistance)
        {
            nextTarget = (nextTarget + 1) % targets.Length;
        }

        agent.SetDestination(targets[nextTarget].position);
    }
}