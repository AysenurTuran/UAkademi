using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 cameraOffset = new Vector3(0f, 2f, -5f);
    public float rotationSpeed = 5f;

    private void LateUpdate()
    {
        // Hedef olan aracın pozisyonunu alıyoruz.
        Vector3 targetPosition = player.transform.position + player.transform.TransformDirection(cameraOffset);

        // Kameranın yumuşak bir şekilde hedef pozisyonuna doğru hareket etmesini sağlıyoruz.
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * rotationSpeed);

        // Kameranın araca bakmasını sağlıyoruz.
        transform.LookAt(player.transform);
    }
}
