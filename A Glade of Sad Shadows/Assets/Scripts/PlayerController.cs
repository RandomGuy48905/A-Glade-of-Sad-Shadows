using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float shiftSpeed = 10f;
    [SerializeField] float jumpForce = 7f;
    [SerializeField] GameObject pistol, rifle, knife;
    [SerializeField] Image pistolUI, rifleUI, knifeUI, cusror;
    bool isGrounded = true;
    bool isPistol, isRifle, isKnife;
    float currentSpeed;
    float stamina = 10f;
    Rigidbody rb;
    Vector3 direction;
    private float health = 100;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = movementSpeed;
    }

    public void ChooseWeapon(Weapons weapons)
    {
        pistol.SetActive(weapons == Weapons.Pistol);
        rifle.SetActive(weapons == Weapons.Rifle);
        knife.SetActive(weapons == Weapons.Knife);
        if (weapons != Weapons.None)
        {
            cusror.enabled = true;
        }
        else
        {
            cusror.enabled = false;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && isPistol)
        {
            ChooseWeapon(Weapons.Pistol);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && isRifle)
        {
            ChooseWeapon(Weapons.Rifle);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && isKnife)
        {
            ChooseWeapon(Weapons.Knife);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChooseWeapon(Weapons.None);
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        direction = new Vector3(moveHorizontal, 0.0f, moveVertical);
        direction = transform.TransformDirection(direction);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (stamina > 0)
            {
                stamina -= Time.deltaTime;
                currentSpeed = shiftSpeed;
            }
            else
            {
                currentSpeed = movementSpeed;
            }
        }

        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            stamina += Time.deltaTime * 2;
            currentSpeed = movementSpeed;
        }

        if (stamina > 10f)
        {
            stamina = 10f;
        }
        else if (stamina < 0)
        {
            stamina = 0;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * currentSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    public void ChangeHealth(float count)
    {
        Debug.Log(health);
        //вычитаем здоровье
        health -= count;
        //если здоровье меньше либо равно нулю, то...
        if (health <= 0)
        {
            this.enabled = false;
            health = 0;
        }
    }
    public enum Weapons
    {
        None,
        Pistol,
        Rifle,
        Knife
    }
    Weapons weapons = Weapons.None;
    
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "pistol":
                if (!isPistol)
                {
                    isPistol = true;
                    pistolUI.color = Color.white;
                    ChooseWeapon(Weapons.Pistol);
                }
                break;
            case "rifle":
                if (!isRifle)
                {
                    isRifle = true;
                    rifleUI.color = Color.white;
                    ChooseWeapon(Weapons.Rifle);
                }
                break;
            case "knife":
                if (!isKnife)
                {
                    isKnife = true;
                    knifeUI.color = Color.white;
                    ChooseWeapon(Weapons.Knife);
                }
                break;
            default:
                break;
        }
        Destroy(other.gameObject);
    }
}
