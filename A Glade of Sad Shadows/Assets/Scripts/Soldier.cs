using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Enemy
{
    //Скорость жука
    [SerializeField] float speed;
    //Радиус в котором жук будет нас обнаруживать
    [SerializeField] float detectionDistance;
    [SerializeField] Transform bulletPos;
    [SerializeField] ShootComponent shoot;
    RaycastHit hit;

    public override void Move()
    {
        //Если расстояние между врагом и игроком меньше, чем радиус обнаружения
        // И расстояние между врагом и игроком больше, чем радиус атаки, то...
        if (distance < detectionDistance && distance > attackDistance)
        {
            //Разворачиваем врага в сторону игрока
            transform.LookAt(player.transform);
            //Двигаем жука вперед       
            rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
        }

    }
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