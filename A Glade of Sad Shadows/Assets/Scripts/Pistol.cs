using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    RaycastHit hit;
    void Start()
    {
        //�������� ����� ���������� ���
        cooldown = 0;
        //�������� �� ��������������. ����� ������ ��� �������� �� ������ ���� ��� ��������
        auto = false;
        ammoCurrent = 15;
        ammoMax = 15;
        ammoBackPack = 60;
    }

    protected override void OnShoot()
    {
        Vector3 rayStartPosition = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        Ray ray = cam.GetComponent<Camera>().ScreenPointToRay(rayStartPosition);
        RaycastHit hit;
        //���������� ������ ����� ������ RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            ammoCurrent = ammoCurrent - 1;
            GameObject gameBullet = Instantiate(particle, hit.point, hit.transform.rotation);
            if (hit.collider.CompareTag("enemy"))
            {
                //����� 10 ������ �������� �� ���. ��� ����, ������� ������� ���� ����
                hit.collider.gameObject.GetComponent<Enemy>().ChangeHealth(20);
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
        ammoText.text = ammoCurrent + " / " + ammoBackPack;
    }
}
