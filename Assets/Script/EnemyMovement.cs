using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent nma;

    Transform target;

    [SerializeField]
    float attackRange = 3;

    [SerializeField]
    bool canShoot;

    [SerializeField]
    GameObject bullet;

    bool playerDetected = false;

    private void Start()
    {
        target = Player.instance.transform;
        nma.stoppingDistance = attackRange - 1;
    }

    // Update is called once per frame
    void Update()
    {

        if(target == null)
        {
            return;
        }

        RaycastHit hitInfo;
        Vector3 direction = target.position - transform.position;

        if(Physics.Raycast(transform.position, direction, out hitInfo))
        {
            Debug.Log(hitInfo.transform.name);
            if(hitInfo.transform.gameObject.tag == "Player")
            {
                playerDetected = true;
            }
        }

        if (!playerDetected)
        {
            return;
        }

        float dist = Vector3.Distance(target.position, transform.position);

        // Deplacement
        nma.SetDestination(target.position);
        
        if(dist <= attackRange)
        {
            // Melee Attack
            if (!canShoot)
            {
                GetComponent<EnemyAttack>().Attack(target);
            }
            // Distance Attack
            else
            {
                GetComponent<EnemyAttack>().AttackRange(bullet);
            }
        }
        else
        {
            nma.isStopped = false;
            nma.SetDestination(target.position);
        }
    }
}
