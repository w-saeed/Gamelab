using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject car;
    public void restart()
    {
        car = GameObject.Find("Car");
        car.transform.position = new Vector3(239.35f, -69.999f, 254.14f);
        car.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        Rigidbody carRegidbody = car.GetComponent<Rigidbody>();
        carRegidbody.velocity = Vector3.zero;
        carRegidbody.angularVelocity = Vector3.zero;
    }

}
