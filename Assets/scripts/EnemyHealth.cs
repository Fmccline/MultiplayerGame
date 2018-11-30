using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : PlayerHealth {

    protected override void Death()
    {
        Destroy(gameObject);
    }

}
