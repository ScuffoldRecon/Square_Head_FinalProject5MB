using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        if (Gobal.player == null) return;

        Vector3 target = Gobal.player.transform.position;
        target.z = transform.position.z;

        Vector3 dir = (target - transform.position).normalized;

        transform.position += dir * speed * Time.deltaTime;
    }
}
