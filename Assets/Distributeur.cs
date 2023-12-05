using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.UI;
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
    public GameObject [] _ingredient;

    private void Generate(GameObject obj)
    {
        Instantiate(obj, _ApparitionPoint);
    }
    public void GenerateFromage()
    {
        Instantiate(_fromage, _ApparitionPoint);
    }
    public void GenerateTomate()
    {
        Instantiate(_tomate, _ApparitionPoint);
    }
    public void GenerateSalade()
    {
        Instantiate(_salade, _ApparitionPoint);
    }
    public void GenerateSteak()
    {
        Instantiate(_steak, _ApparitionPoint);
    }
    public void GeneratePainBas()
    {
        Instantiate(_painBas, _ApparitionPoint);
    }
    public void GeneratePainHaut()
    {
        Instantiate(_painHaut, _ApparitionPoint);
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
