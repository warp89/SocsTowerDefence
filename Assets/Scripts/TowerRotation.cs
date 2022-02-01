using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotation : MonoBehaviour
{

    public void TurnTower(GameObject target)
    {
        if (target != null)
        {
            Vector3 relative = transform.InverseTransformPoint(target.transform.position);
            float angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
            transform.Rotate(0, 0, -angle + 180);
        }
    }
}
