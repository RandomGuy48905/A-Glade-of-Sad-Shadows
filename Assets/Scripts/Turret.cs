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

        //Если расстояние между врагом и игроком меньше, чем расстояние для атаки и таймер больше кулдауна(время между ударами) то...
        if (distance < attackDistance && timer > cooldown)
        {
            //обнуляем таймер
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
