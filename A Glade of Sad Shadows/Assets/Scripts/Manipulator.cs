using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulator : Enemy
{
    public override void Attack()
    {
        //Если расстояние между врагом и игроком меньше, чем расстояние для атаки и таймер больше кулдауна(время между ударами) то...
        if (timer > cooldown)
        {
            //обнуляем таймер
            timer = 0;
            //Получаем скрипт игрока и вызываем метод изменения здоровья
            player.GetComponent<PlayerController>().ChangeHealth(damage);
            //Активируем анимацию атаки            
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
