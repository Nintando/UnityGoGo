using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    float damage = 10f;

    [SerializeField]
    float timeBetweenAttack = 3f;

    [SerializeField]
    Transform firePoint;


    bool canAttack = true;

    public void Attack(Transform targetToAttack)
    {
        if (canAttack)
        {
            targetToAttack.GetComponent<Sante>().DoDamage(damage);
            canAttack = false;
            StartCoroutine(CoolDownAttack());
        }
    }

    public void AttackRange(GameObject bullet)
    {
        if (canAttack)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            canAttack = false;
            StartCoroutine(CoolDownAttack());
        }
    }

    IEnumerator CoolDownAttack()
    {
        yield return new WaitForSeconds(timeBetweenAttack);
        canAttack = true;
    }
}
