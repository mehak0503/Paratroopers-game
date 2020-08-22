using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBomb : MonoBehaviour {
    public GameObject explosion;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Enemy")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
