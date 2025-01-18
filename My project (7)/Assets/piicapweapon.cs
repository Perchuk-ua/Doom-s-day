using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    public GameObject camera;
    public float distance = 15f;
    GameObject currentWeapon;
    bool canPickUp;

    void Update()
    {
        // ������ ������� PickUp ��� ��������� ������ E
        if (Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        }

        // ������ ������� Drop ��� ��������� ������ Q
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Drop();
        }
    }

    void PickUp()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, distance))
        {
            if (hit.transform.tag == "weapon")
            {
                // ���� �������, ��������� ������� Drop
                if (canPickUp)
                {
                    Drop();
                }

                // ��������� ������� ����
                currentWeapon = hit.transform.gameObject;
                currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
                currentWeapon.GetComponent<Collider>().isTrigger = true;
                currentWeapon.transform.parent = transform;
                currentWeapon.transform.localPosition = Vector3.zero;
                currentWeapon.transform.localEulerAngles = new Vector3(1f, -90f, -10f);
                canPickUp = true;
            }
        }
    }

    void Drop()
    {
        // �������� ��������� ����
        currentWeapon.transform.parent = null;
        currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
        currentWeapon.GetComponent<Collider>().isTrigger = false;

        canPickUp = false;
        currentWeapon = null;
    }
}