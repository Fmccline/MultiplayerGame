using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerHealth : NetworkBehaviour {

    public RectTransform m_HealthBar;
    public int m_MaxHealth;
    [SyncVar(hook = "OnChangeHealth")]
    int currentHealth;
    NetworkStartPosition[] spawnPoints;

    // Use this for initialization
    void Start () {
        currentHealth = m_MaxHealth;
        spawnPoints = FindObjectsOfType<NetworkStartPosition>();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void OnChangeHealth(int health)
    {
        float healthPercentage = health / (float)m_MaxHealth;
        m_HealthBar.sizeDelta = new Vector2(healthPercentage * 100, m_HealthBar.sizeDelta.y);
    }

    public void TakeDamage(int damage)
    {
        if (!isServer) return;

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Debug.Log("Dead");
            Death();
        }
    }

    protected virtual void Death()
    {
        RpcRespawn();
    }

    [ClientRpc]
    public void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            // move back to zero location
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform;
            transform.position = spawnPoint.position;
            currentHealth = m_MaxHealth;
        }
    }
}

