using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkEnemy : Enemy
{
    //�������� ����
    [SerializeField] float speed;
    //������ � ������� ��� ����� ��� ������������
    [SerializeField] float detectionDistance;

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
        //���� ���������� ����� ������ � ������� ������, ��� ���������� ��� ����� � ������ ������ ��������(����� ����� �������) ��...
        if (distance < attackDistance && timer > cooldown)
        {
            //�������� ������
            timer = 0;
            //�������� ������ ������ � �������� ����� ��������� ��������
            player.GetComponent<PlayerController>().ChangeHealth(damage);
            //���������� �������� �����            
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
