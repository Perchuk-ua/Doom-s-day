using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    Animator animator;
    GameObject currentWeapon; // Оголошення змінної currentWeapon
    bool canPickUp; // Оголошення змінної canPickUp

    void Start()
    {
        animator = GetComponent<Animator>();
        canPickUp = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            animator.SetBool("attack", true);
        else if (Input.GetButtonUp("Fire1"))
            animator.SetBool("attack", false);
    }

    void Drop()
    {
        if (currentWeapon != null)
        {
            currentWeapon.transform.parent = null;
            currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
            currentWeapon.GetComponent<Collider>().isTrigger = false;
            canPickUp = false;
            currentWeapon = null;
        }
    }
}