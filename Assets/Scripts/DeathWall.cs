using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWall : Enemy
{
    public override void Attack()
    {
        //���� ���������� ����� ������ � ������� ������, ��� ���������� ��� ����� � ������ ������ ��������(����� ����� �������) ��...
        player.GetComponent<PlayerController>().ChangeHealth(damage);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Attack();
        }
    }
}
