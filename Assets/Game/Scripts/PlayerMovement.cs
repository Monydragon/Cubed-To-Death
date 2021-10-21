using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 movement;
    public Rigidbody rb;
    public VariableJoystick joystick;

    private void OnEnable()
    {
        EventManager.onLevelFail += EventManager_onLevelFail;
    }

    private void OnDisable()
    {
        EventManager.onLevelFail -= EventManager_onLevelFail;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<VariableJoystick>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (joystick != null && joystick.Direction.x != 0 || joystick.Direction.y != 0)
        {
            movement.x = joystick.Horizontal;
            movement.z = joystick.Vertical;
        }
        else
        {
#if UNITY_ANDROID
            movement.x = Input.acceleration.x;
            movement.z = Input.acceleration.y;
#else
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.z = Input.GetAxisRaw("Vertical");
#endif
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EventManager.GamePause();
        }

    }

    private void FixedUpdate()
    {
        rb.AddForce(movement * speed);
    }

    private void EventManager_onLevelFail(int value)
    {
        gameObject.SetActive(false);
    }
}
