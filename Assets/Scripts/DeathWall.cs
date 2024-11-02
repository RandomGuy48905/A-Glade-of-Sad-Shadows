using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWall : Enemy
{
    public override void Attack()
    {
        //≈сли рассто€ние между врагом и игроком меньше, чем рассто€ние дл€ атаки и таймер больше кулдауна(врем€ между ударами) то...
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
