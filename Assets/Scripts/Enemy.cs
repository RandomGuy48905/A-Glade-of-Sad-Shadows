using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected float attackDistance;
    [SerializeField] protected int damage;
    [SerializeField] protected float cooldown;
    protected GameObject player;
    protected Animator anim;
    protected Rigidbody rb;
    protected float distance;
    protected float timer;
    protected bool dead = false;
    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        distance = Vector3.Distance(transform.position, player.transform.position);
        Run();
    }

    protected virtual void Run()
    {
    }

    private void FixedUpdate()
    {
        if (!dead)
        {
            Move();
        }
    }

    // Update is called once per frame
    public virtual void Move()
    {
    }
    public virtual void Attack()
    {
    }

    public void ChangeHealth(int count)
    {
        //�������� ��������
        health -= count;
        //���� �������� ������, ���� ����� ����, ��..
        if (health <= 0)
        {
            //������ �������� ������� ����������(��������� �������� ������ Attack � Move
            dead = true;
            //��������� ��������� �����
            GetComponent<Collider>().enabled = false;
        }
    }
}
