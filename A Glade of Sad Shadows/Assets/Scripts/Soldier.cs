using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Enemy
{
    //�������� ����
    [SerializeField] float speed;
    //������ � ������� ��� ����� ��� ������������
    [SerializeField] float detectionDistance;
    [SerializeField] Transform bulletPos;
    [SerializeField] ShootComponent shoot;
    RaycastHit hit;

    public override void Move()
    {
        //���� ���������� ����� ������ � ������� ������, ��� ������ �����������
        // � ���������� ����� ������ � ������� ������, ��� ������ �����, ��...
        if (distance < detectionDistance && distance > attackDistance)
        {
            //������������� ����� � ������� ������
            transform.LookAt(player.transform);
            //������� ���� ������       
            rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
        }

    }
    public override void Attack()
    {
        transform.LookAt(player.transform);

        //���� ���������� ����� ������ � ������� ������, ��� ���������� ��� ����� � ������ ������ ��������(����� ����� �������) ��...
        if (distance < attackDistance && timer > cooldown)
        {
            //�������� ������
            timer = 0;
            shoot.Shoot(player.transform, bulletPos, damage);
        }
    }
    protected override void Run()
    {
        if (!dead)
        {
            Attack();
        }
    }
}