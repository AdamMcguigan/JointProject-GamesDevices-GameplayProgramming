using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateTowardsPlayer : MonoBehaviour
{
    public GameObject target;
    float rotationSpeed = 10.0f;

    // Update is called once per frame
    void Update()
    {
        RotateTowardsTarget();
    }

    private void RotateTowardsTarget()
    {
        //float offset = -90f;
        Vector2 direction = target.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
