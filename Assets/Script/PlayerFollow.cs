using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField]
    Transform player;

    // Update is called once per frame
    void Update()
    {


        if (Player.instance == null)
        {
            return;
        }


        Vector3 posCamera = player.position;
        posCamera.y = transform.position.y;
        posCamera.z = player.position.z;

        transform.position = Vector3.MoveTowards(transform.position, posCamera, 5f * Time.deltaTime);


    }
}
