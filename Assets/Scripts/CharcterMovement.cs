using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcterMovement : MonoBehaviour
{
    [SerializeField] float speed;

    

    // Update is called once per frame
    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            Destroy(collision.gameObject);
    }
}
