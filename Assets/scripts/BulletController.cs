using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public int m_Damage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisionObject = collision.gameObject;
        PlayerHealth playerHealth = collisionObject.GetComponentInParent<PlayerHealth>();
        playerHealth.TakeDamage(m_Damage);
        Destroy(gameObject);
    }


}
