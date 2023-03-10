using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GBShotHitbox : MonoBehaviour
{
    bool _update = false;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        if (!_update)
        {
            _update = true;
            return;
        }
        Destroy(gameObject);
    }
}
