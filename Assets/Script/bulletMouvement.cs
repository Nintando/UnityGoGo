using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMouvement : MonoBehaviour
{
    [SerializeField]
    float damage = 10f;
    float speed = 20f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Sante>().DoDamage(damage);
        }
        Destroy(gameObject);
    }
}
