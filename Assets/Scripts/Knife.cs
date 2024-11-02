using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        //задержки между выстрелами есть
        cooldown = 0.5f;
        //Стрельба не автоматическая. Нужно каждый раз нажимать на кнопку мыши для атаки
        auto = false;
        ammoCurrent = 100;
        ammoMax = 100;
        ammoBackPack = Mathf.Infinity;
    }
    protected override void OnShoot()
    {
        Vector3 rayStartPosition = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = cam.GetComponent<Camera>().ScreenPointToRay(rayStartPosition);
        RaycastHit hit;
        //Продолжаем писать после строки RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 3))
        {
            GameObject gameBullet = Instantiate(particle, hit.point, hit.transform.rotation);
            ammoCurrent = ammoCurrent - 1;
            if (hit.collider.CompareTag("enemy"))
            {
                //Число 10 можешь поменять на своё. Это урон, который наносит одна пуля
                hit.collider.gameObject.GetComponent<Enemy>().ChangeHealth(15);
            }
            Destroy(gameBullet, 1);
        }
    }
    protected override void Run()
    {
        AmmoTextUpdate();
    }
    protected void AmmoTextUpdate()
    {
        ammoText.text = "";
    }
}
