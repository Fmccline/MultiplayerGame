using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NoRender : NetworkBehaviour
{

	// Use this for initialization
	void Start () {
		if (isLocalPlayer)
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
