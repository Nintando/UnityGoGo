using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItems : MonoBehaviour
{
    [SerializeField]
    GameObject healing;

    [SerializeField]
    [Range(0, 100)]

    float dropRate = 30;

    public void OnDestroy()
    {
        float randomf = Random.Range(0, 100);

        if(randomf <= dropRate)
        {
            Instantiate(healing, transform.position, transform.rotation);
        }
    }
}
