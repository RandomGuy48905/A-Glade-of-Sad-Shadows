using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Pistol
{
    // Start is called before the first frame update
    void Start()
    {
        //�������� ����� ����������(����� ������� �����������)
        cooldown = 0.1f;
        //�������� ��������������, ������ ��� ������� ������� ���� ������ ����� �������� ���������� �������� ��������
        auto = true;
        ammoCurrent = 30;
        ammoMax = 30;
        ammoBackPack = 60;
    }
}
