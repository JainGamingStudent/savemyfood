using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public Vector3 destination;
    public GameManager _manager;
    

    // Update is called once per frame
    void Update()
    {
        if(destination !=null)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, destination, 3 * Time.deltaTime);
            pos.z = 0;
            transform.position = pos;
        }
    }
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="food")
        {
            _manager.gameover();
        }
    }
}
