using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //Объект Particle System, который будет оставлять след от пуль
    [SerializeField] protected GameObject particle;
    //Камера(понадобится для определения центра экрана)
    [SerializeField] protected GameObject cam;
    //Переменная для отображения текста на UI
    [SerializeField] protected TMP_Text ammoText;
    //Тип стрельбы
    protected bool auto = false;
    //Время задержки между выстрелами и таймер, который считает время
    protected float cooldown = 0;
    protected float timer = 0;
    //Сколько патронов в обойме
    protected float ammoCurrent;
    //Сколько патронов помещается в обойму
    protected float ammoMax;
    //Сколько патронов в запасе
    protected float ammoBackPack;

    //При старте приравниваем таймер к задержке между выстрелами
    //Так не будет задержки перед первым выстрелом
    private void Start()
    {
        timer = cooldown;
    }
    private void Update()
    {
        Run();
        //Запускаем таймер
        timer += Time.deltaTime;
        //Если удерживаем клавишу мыши, то вызываем метод Shoot
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }

        //если игрок нажмет кнопку R
        if (Input.GetKeyDown(KeyCode.R))
        {
            //если у нас кол-во патронов в обойме НЕ максимальное И, если в запасе патронов больше нуля, то
            if (ammoCurrent != ammoMax && ammoBackPack != 0)
            {
                //активируем метод перезарядки с задержкой
                //время задержки можно установить самостоятельно
                Invoke("Reload", 1);
            }
        }
    }
    //способность оружия стрелять. 
    public void Shoot()
    {
        if (Input.GetMouseButtonDown(0) || auto)
        {
            if (timer > cooldown)
            {
                if(ammoCurrent > 0)
                {
                    OnShoot();
                    timer = 0;
                }
            }
        }
    }
    private void Reload()
    {
        //создаем временную переменную, которая высчитывает сколько патронов нам нужно добавить
        float ammoNeed = ammoMax - ammoCurrent;
        //если кол-во патронов в запасе больше или равно кол-ву, которое нам нужно добавить то,
        if (ammoBackPack >= ammoNeed)
        {
            //из кол-ва патронов в запасе вычитаем кол-во, которое добавляем в обойму
            ammoBackPack -= ammoNeed;
            //в обойму добавляем нужное количество патронов
            ammoCurrent += ammoNeed;
        }
        //иначе(если в запасе меньше патронов, чем нам нужно)
        else
        {
            //добавляем в обойму столько патронов, сколько осталось в запасе
            ammoCurrent += ammoBackPack;
            //обнуляем кол-во патронов в запасе
            ammoBackPack = 0;
        }
    }
    //Что происходит при выстреле, эту функцию сможет менять дочерний класс так она определенна модификатором protected virtual
    protected virtual void OnShoot()
    {
    }
    protected virtual void Run()
    {
    }
}
