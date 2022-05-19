using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTir : MonoBehaviour
{
    [SerializeField]
    float fireRate = .5f;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    Coroutine coroutineTir;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            coroutineTir = StartCoroutine(Tir());
        }

        if (Input.GetMouseButtonDown(0))
        {
            StopCoroutine(coroutineTir);
        }
    }

    IEnumerator Tir()
    {
        while (true)
        {
            GameObject go = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Destroy(go, 5f);
            yield return new WaitForSeconds(fireRate);
        }
    }
}
