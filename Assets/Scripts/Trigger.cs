using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private Transform _backupTransform; // get source parent transform before trigger
    private Transform _srcTransform;
    private GameObject _srcObject;

    public GameObject _trigger;
    private Transform _triggerTransform;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered");
        _srcTransform.parent = _triggerTransform;
    }

    private void OnTriggerStay(Collider other)
    {
        // to do
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger exited");
        _srcTransform.parent = _backupTransform;
    }

    private void Animation()
    {
        // todo
    }

    // Start is called before the first frame update
    void Start()
    {
        _srcObject = gameObject;
        _srcTransform = GetComponent<Transform>();

        _trigger = GameObject.Find("Sword");
        _triggerTransform = _trigger.GetComponent<Transform>();

        _backupTransform = _srcTransform;

        Debug.Log(_srcObject);
        Debug.Log(_trigger);
    }

    // Update is called once per frame
    void Update()
    {
        Animation();

    }
}
