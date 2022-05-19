using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healing : MonoBehaviour
{
    [SerializeField]
    float healAmount = 10;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player.instance.GetComponent<Sante>().heal(healAmount);
            Destroy(gameObject);
        }
    }
}
