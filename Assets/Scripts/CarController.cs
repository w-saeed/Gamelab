using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float maxSpeed;

    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    public float HorizontalInput;
    public float VerticalInput;
    private float currentSteerAngle;
    private float Currentbreakforce { get; set; } = 1000;

    [SerializeField] private bool isBreaking;
    [SerializeField] public readonly float motorForce = 1000;
    [SerializeField] private float breakForce;
    [SerializeField] private readonly float maxSteeringAngle = 30;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    // Start is called before the first frame update
    void Start()
    {
        //moving down the center of mass in order to prevent car flip
        gameObject.GetComponent<Rigidbody>().centerOfMass += new Vector3(0, -0.5f, 0);

    }

    void FixedUpdate()
    {

        GetInput();
        HanleMotor();
        HandleSteering();
        UpdateWheels();


        //calcuating speed 
        totalDistance += Vector3.Distance(lastPosition, transform.position);
        // speedPerSec = Vector3.Distance(lastPosition, transform.position)
        // / Time.deltaTime;
        speed = Vector3.Distance(lastPosition, transform.position);
        lastPosition = transform.position;

    }


    private void HanleMotor()
    {

        frontLeftWheelCollider.motorTorque = VerticalInput * motorForce;
        frontRightWheelCollider.motorTorque = VerticalInput * motorForce;
        breakForce = isBreaking ? breakForce : 0f;

        if (isBreaking)
        {
            //frontLeftWheelCollider.motorTorque = -0.5f * motorForce;

            ApplyBreaking();
        }
        else
        {
            frontRightWheelCollider.brakeTorque = 0;
            frontLeftWheelCollider.brakeTorque = 0;
            rearLeftWheelCollider.brakeTorque = 0;
            rearRightWheelCollider.brakeTorque = 0;
        }
    }

    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = Currentbreakforce;
        frontLeftWheelCollider.brakeTorque = Currentbreakforce;
        rearLeftWheelCollider.brakeTorque = Currentbreakforce;
        rearRightWheelCollider.brakeTorque = Currentbreakforce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteeringAngle * HorizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    Boolean keyboardInput = false;
    private void GetInput()
    {
        if (!keyboardInput)
        {
            
            UDPReceive udp_recieve = GameObject.Find("Client").GetComponent<UDPReceive>();
            HorizontalInput = udp_recieve.angle * -1;
            //VerticalInput = Math.Abs(1f - (speed * 5));

            isBreaking = udp_recieve.distance < 150;
            if(udp_recieve.handsopen != 1.0f)
            {
                VerticalInput = (udp_recieve.distance - 200f) / 100f;
                VerticalInput = VerticalInput > 1 ? 1 : VerticalInput;
                VerticalInput = VerticalInput < 0 ? 0 : VerticalInput;
            }
            else
            {
                VerticalInput = -1;
            }
            
        }
        else
        {
            HorizontalInput = Input.GetAxis(HORIZONTAL);
            VerticalInput = Input.GetAxis(VERTICAL);
            isBreaking = Input.GetKey(KeyCode.Space);
        }

        //Debug.Log(VerticalInput);
    }
    //var xRotationLimit = 20;
    //var yRotationLimit = 20;
    //var zRotationLimit = 20;


    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider
    , Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;

        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }


    //the total distance the vehicle moved
    private float totalDistance;
    //last position of the vehicle
    private Vector3 lastPosition;
    public float speed;
    public float speedPerSec;


    void Update()
    {


    }
}