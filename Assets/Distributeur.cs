using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distributeur : MonoBehaviour
{
    private Transform _myTF;
    public GameObject _fromage;
    public GameObject _tomate;
    public GameObject _salade;
    public GameObject _steak;
    public GameObject _painBas;
    public GameObject _painHaut;
    private Transform _ApparitionPoint;

    public void Generate(GameObject obj)
    {
        Instantiate(obj, _ApparitionPoint);
    }

    // Start is called before the first frame update
    void Start()
    {
        _myTF = GetComponent<Transform>();
        print(_myTF.childCount);
        _ApparitionPoint = _myTF.GetChild(0);
        Generate(_fromage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
