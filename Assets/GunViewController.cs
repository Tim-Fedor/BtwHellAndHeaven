using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunViewController : MonoBehaviour {
    public SpriteRenderer gun;

    void FixedUpdate()
    {
        if (transform.localEulerAngles.z > 0) {
            gun.flipY = true;
        }
        else {
            gun.flipY = false;
        }
    }
}
