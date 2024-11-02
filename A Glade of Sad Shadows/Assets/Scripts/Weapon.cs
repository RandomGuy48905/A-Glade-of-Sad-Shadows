using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //������ Particle System, ������� ����� ��������� ���� �� ����
    [SerializeField] protected GameObject particle;
    //������(����������� ��� ����������� ������ ������)
    [SerializeField] protected GameObject cam;
    //���������� ��� ����������� ������ �� UI
    [SerializeField] protected TMP_Text ammoText;
    //��� ��������
    protected bool auto = false;
    //����� �������� ����� ���������� � ������, ������� ������� �����
    protected float cooldown = 0;
    protected float timer = 0;
    //������� �������� � ������
    protected float ammoCurrent;
    //������� �������� ���������� � ������
    protected float ammoMax;
    //������� �������� � ������
    protected float ammoBackPack;

    //��� ������ ������������ ������ � �������� ����� ����������
    //��� �� ����� �������� ����� ������ ���������
    private void Start()
    {
        timer = cooldown;
    }
    private void Update()
    {
        Run();
        //��������� ������
        timer += Time.deltaTime;
        //���� ���������� ������� ����, �� �������� ����� Shoot
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }

        //���� ����� ������ ������ R
        if (Input.GetKeyDown(KeyCode.R))
        {
            //���� � ��� ���-�� �������� � ������ �� ������������ �, ���� � ������ �������� ������ ����, ��
            if (ammoCurrent != ammoMax && ammoBackPack != 0)
            {
                //���������� ����� ����������� � ���������
                //����� �������� ����� ���������� ��������������
                Invoke("Reload", 1);
            }
        }
    }
    //����������� ������ ��������. 
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
        //������� ��������� ����������, ������� ����������� ������� �������� ��� ����� ��������
        float ammoNeed = ammoMax - ammoCurrent;
        //���� ���-�� �������� � ������ ������ ��� ����� ���-��, ������� ��� ����� �������� ��,
        if (ammoBackPack >= ammoNeed)
        {
            //�� ���-�� �������� � ������ �������� ���-��, ������� ��������� � ������
            ammoBackPack -= ammoNeed;
            //� ������ ��������� ������ ���������� ��������
            ammoCurrent += ammoNeed;
        }
        //�����(���� � ������ ������ ��������, ��� ��� �����)
        else
        {
            //��������� � ������ ������� ��������, ������� �������� � ������
            ammoCurrent += ammoBackPack;
            //�������� ���-�� �������� � ������
            ammoBackPack = 0;
        }
    }
    //��� ���������� ��� ��������, ��� ������� ������ ������ �������� ����� ��� ��� ����������� ������������� protected virtual
    protected virtual void OnShoot()
    {
    }
    protected virtual void Run()
    {
    }
}
