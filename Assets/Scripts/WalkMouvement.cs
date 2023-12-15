using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkMouvement : MonoBehaviour
{
    private Transform _sourceTransform;
    private Transform _eyeTransform;
    private Rigidbody _rb;
    
    private float _speedY = 1000.0f;
    private float _speedX = 2000.0f;
    
    private float _angle;
    private float _mouseXpos;
    private float _mouseYpos;
    private float _xrot;
    private float _yrot;

    private bool _isGrounded;

    public Vector3 jump;
    public float jumpForce = 2.0f;

    private void Jump()
    {
        if (_isGrounded && Input.GetKey("e"))
        {
            _rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            _isGrounded = false;
        }
    }
    void OnCollisionStay()
    {
        _isGrounded = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        _sourceTransform = GetComponent<Transform>();
        _eyeTransform = GameObject.Find("Eyes").GetComponent<Transform>();
        _rb = GetComponent<Rigidbody>();

        _mouseXpos = 0;
        _mouseYpos = 0;

        _xrot = 0;
        _yrot = 0;

        jump = new Vector3(0.0f, 15.0f, 0.0f);
   
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Press the space bar to apply no locking to the Cursor
        if (Input.GetKey(KeyCode.Space))
            Cursor.lockState = CursorLockMode.Locked;

        //Press the space bar to apply no locking to the Cursor
        if (Input.GetKey(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;

        _mouseXpos = Input.GetAxis("Mouse X");
        _xrot += _mouseXpos * _speedX * Time.deltaTime;
        //Debug.Log(_xrot);

        _mouseYpos = Input.GetAxis("Mouse Y");  
        _yrot += _mouseYpos * _speedY * Time.deltaTime;
        _yrot = Mathf.Clamp(_yrot, -90f, 90f);

        _sourceTransform.localRotation = Quaternion.AngleAxis(_xrot, Vector3.up);
        _eyeTransform.localRotation = Quaternion.AngleAxis(_yrot, Vector3.left);

        Jump();
    }
}
