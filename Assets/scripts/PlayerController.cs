using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    public GameObject m_Bullet;
    public Transform m_BulletSpawn;
    public MeshRenderer m_BodyMeshRenderer;

	// Use this for initialization
	void Start () {
        if (isLocalPlayer) return;

        
    }
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }

        //var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        //var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        //transform.Rotate(0, x, 0);
        //transform.Translate(0, 0, z);
    }

    [Command]
    private void CmdFire()
    {
        // Create the Bullet from the Bullet Prefab
        GameObject bullet = (GameObject)Instantiate(
            m_Bullet,
            m_BulletSpawn.position,
            m_BulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

        NetworkServer.Spawn(bullet);

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }

    public override void OnStartLocalPlayer()
    {
        m_BodyMeshRenderer.material.color = Color.blue;
    }
}
