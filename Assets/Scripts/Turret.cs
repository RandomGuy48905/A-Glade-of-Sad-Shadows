using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Enemy
{
    [SerializeField] Transform bulletPos;
    [SerializeField] ShootComponent shoot;

    private Vector3 rotation = new Vector3(-90f,0f,0f);
    RaycastHit hit;
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
