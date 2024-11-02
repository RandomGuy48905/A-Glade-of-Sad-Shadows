using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulator : Enemy
{
    public override void Attack()
    {
        //���� ���������� ����� ������ � ������� ������, ��� ���������� ��� ����� � ������ ������ ��������(����� ����� �������) ��...
        if (timer > cooldown)
        {
            //�������� ������
            timer = 0;
            //�������� ������ ������ � �������� ����� ��������� ��������
            player.GetComponent<PlayerController>().ChangeHealth(damage);
            //���������� �������� �����            
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Attack();
        }
    }
}
