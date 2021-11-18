using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSenseController : MonoBehaviour
{
    public Slider mouseSens;
    public GameObject camera;

    // Update is called once per frame
    void Update()
    {
        camera.GetComponent<MouseLook>().mouseSens = mouseSens.value;
    }
}
