using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        //�������� ����� ���������� ����
        cooldown = 0.5f;
        //�������� �� ��������������. ����� ������ ��� �������� �� ������ ���� ��� �����
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
        //���������� ������ ����� ������ RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 3))
        {
            GameObject gameBullet = Instantiate(particle, hit.point, hit.transform.rotation);
            ammoCurrent = ammoCurrent - 1;
            if (hit.collider.CompareTag("enemy"))
            {
                //����� 10 ������ �������� �� ���. ��� ����, ������� ������� ���� ����
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
