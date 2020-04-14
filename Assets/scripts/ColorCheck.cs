using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorCheck : MonoBehaviour
{
    [SerializeField] private Text foo;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Platform")) {
            foo.text = other.gameObject.name;
        }
    }
}
