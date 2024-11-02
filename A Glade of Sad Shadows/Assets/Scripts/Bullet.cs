using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]private Rigidbody rb;
    float speed = 7;
    private Vector3 _direction;
    private float _damage;
    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + _direction * speed * Time.deltaTime);
    }
    public void SetDirection(Transform target, Transform bullet)
    {
        var targetPos = target.position;
        var bulletPos = bullet.position;
        _direction = targetPos - bulletPos;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().ChangeHealth(_damage);
        }
    }
    public void SetDamage(float damage)
    {
        _damage = damage; 
    }
}
