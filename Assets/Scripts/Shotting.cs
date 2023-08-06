using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotting : MonoBehaviour
{
    public float launchSpeed = 75.0f;
    public GameObject objectPrefab;
    public float killRadius = 50f;

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        Vector3 spawnPosition = transform.position;
        Quaternion spawnRotation = Quaternion.identity;
        Vector3 localXDirection = transform.TransformDirection(Vector3.forward);
        Vector3 velocity = localXDirection * launchSpeed;

        GameObject newObject = Instantiate(objectPrefab, spawnPosition, spawnRotation);

        Rigidbody rb = newObject.GetComponent<Rigidbody>();
        rb.velocity = velocity;
    }

    private void OnTriggerEnter(Collider other)
        {
            // Çarpışma gerçekleşen objenin etiketini kontrol ediyoruz.
            if (other.CompareTag("target"))
            {
                // Çarpışma gerçekleşen objenin vurma yarıçapı içinde olup olmadığını kontrol ediyoruz.
                float distance = Vector3.Distance(transform.position, other.transform.position);
                if (distance <= killRadius)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
