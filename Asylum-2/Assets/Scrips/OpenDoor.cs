using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public float rotationSpeed = 90.0f;
    public bool open;

    public GameObject Zombie;

    private void Start()
    {
        open = false;
    }

    private void OnMouseDown()
    {
        if (open = true)
        {
            transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
            open = false;
        }
        else
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            open = true;
        }
        /* if (Zombie != null)
        {
            AnimateButton receiver = Zombie.GetComponent<AnimateButton>();
            if (receiver != null)
            {
                receiver.ReceiveClick();
            }
        }
        */
    }
}
