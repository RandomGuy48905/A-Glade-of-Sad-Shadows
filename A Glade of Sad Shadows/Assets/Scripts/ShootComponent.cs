using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootComponent : MonoBehaviour
{
    RaycastHit hit;
    Vector3 rotation = new Vector3(-90, 0, 0);
    [SerializeField] Bullet bullet;

    public void Shoot(Transform player, Transform bulletPos, float damage)
    {
        if (Physics.Raycast(bulletPos.position, transform.forward, out hit))
        {
            if (hit.collider.CompareTag("Player"))
            {
                var bulletPrefab = Instantiate(bullet, transform.position, Quaternion.Euler(rotation));
                bulletPrefab.SetDirection(player.transform, bulletPrefab.transform);
                bulletPrefab.SetDamage(damage);
            }
        }
    }
}
