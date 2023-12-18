using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VerifyBurger : MonoBehaviour
{
    private Recipe recipe;
    [Range(1,15)]
    public int _numberOfIngredients = 6;
    public float _generationSpeed = 0.1f;
    
    public GameObject _recipeDisplayer;
    public Transform _recipeDisplayerTransform;
    public Text _recipeText;

    public GameObject _fromage;
    public GameObject _tomates;
    public GameObject _salade;
    public GameObject _steak;
    public GameObject _painBas;
    public GameObject _painHaut;

    public GameObject _invisibleCollider;
    
    public GameObject _apparitionPoint;
    public GameObject _recipeBurger;
    public Text _textNbIngredient;

    private bool _isCreating;

    void ComputeRandomRecipe()
    {
        recipe.RandomRecipe(_numberOfIngredients);
    }

    public void afficher()
    {
        Debug.Log(recipe);
    }

    private IEnumerator CreateBurger()
    {
	_isCreating = true;
	
	GameObject.Find("Distributeur").GetComponent<Distributeur>().CreateBurgerContainer();
	GameObject burger = _recipeBurger;
	
	Transform burgerTransform = burger.GetComponent<Transform>();

	List<Ingredient> _listOfIngredients = recipe.GetRecipe();

	for (int i=_listOfIngredients.Count-1; i >= 0; i--) {
	    switch(_listOfIngredients[i].getType()) {
	    case Ingredient.Type.PAINB:
		GameObject.Instantiate(_painBas, burgerTransform);
		break;
	    case Ingredient.Type.PAINH:
		GameObject.Instantiate(_painHaut, burgerTransform);
		break;
	    case Ingredient.Type.FROMAGE:
		GameObject.Instantiate(_fromage, burgerTransform);
		break;
	    case Ingredient.Type.STEAK:
		GameObject.Instantiate(_steak, burgerTransform);
		break;
	    case Ingredient.Type.TOMATE:
		GameObject.Instantiate(_tomates, burgerTransform);
		break;
	    case Ingredient.Type.SALADE:
		GameObject.Instantiate(_salade, burgerTransform);
		break;
	    default:
		Debug.Log(_listOfIngredients[i]);
		// do nothing
		break;
	    }

	    yield return new WaitForSeconds (_generationSpeed);
	    
	    GameObject.Instantiate(_invisibleCollider, burgerTransform);

	    if (i != 0)
		yield return new WaitForSeconds (_generationSpeed);

	    Debug.Log(i);

	}

	_isCreating = false;

	Debug.Log("Burger généré");
    }

    public void VerifyRecipe()
    {
        // get all ingredients game objects
        // compare to the recipe
        // treatment
        Ingredient[] listOfIngredient = _apparitionPoint.GetComponentsInChildren<Ingredient>();

        Recipe r = new Recipe(listOfIngredient.Length);

        foreach (Ingredient i in listOfIngredient)
        {
            r.AddIngredient(i);
            Debug.Log(i.ToString());
        }

        Debug.Log(r.ToString());
        Debug.Log(recipe.ToString());
        Debug.Log(recipe.ToString() == r.ToString());

	if (recipe.ToString() == r.ToString())
	{
	    // good recipe
	    StartCoroutine(Win());
	}
	else
	{
	    StartCoroutine(Lose());
	}
    }

    IEnumerator Win()
    {
	Transform burger = GameObject.Find("BurgerContainer").GetComponent<Transform>();

	float dist = 0;
	Vector3 pos = burger.position;
	while (dist<1.7)
	{
	    burger.Translate(Vector3.forward * Time.deltaTime*2);
		dist +=Time.deltaTime*2;
	    yield return new WaitForSeconds (0.01f);
	}

	StartCoroutine(LightVerification(Color.green));
	DestroyBurger(GameObject.Find("ApparitionPoint"));
	RemoveRecipeComponent();
	DestroyBurger(GameObject.Find("RecipeBurger"));
	ComputeRandomRecipe();
	StartCoroutine(CreateBurger());
	Score.Update(_numberOfIngredients);
    }

    IEnumerator Lose()
    {
	Transform burger = GameObject.Find("BurgerContainer").GetComponent<Transform>();
	float dist = 0;
	Vector3 pos = burger.position;
	while (dist<1.7)
	{
	    burger.Translate(Vector3.forward * Time.deltaTime*2);
		dist +=Time.deltaTime*2;
	    yield return new WaitForSeconds (0.01f);
	}
	
	StartCoroutine(LightVerification(Color.red));

	dist = 0;
	while (dist<1.7)
	{
	    burger.Translate(-Vector3.forward * Time.deltaTime*2);
		dist +=Time.deltaTime*2;
	    yield return new WaitForSeconds (0.01f);
	}
	burger.position = pos;
    }

    void DestroyBurger(GameObject parent)
    {
	GameObject originalGameObject = parent;

	for (int i = 0; i < originalGameObject.transform.childCount; i++)
	{
	    GameObject child = originalGameObject.transform.GetChild(i).gameObject;
	    //Do something with child
	    Destroy(child);
	}
    }

    void RemoveRecipeComponent()
    {
	Ingredient[] listOfIngredient = GameObject.Find("Verifier").GetComponentsInChildren<Ingredient>();

	foreach (Ingredient i in listOfIngredient)
	{
	    Destroy(i);
	}
    }

    IEnumerator LightVerification(Color c)
    {
	GameObject light = GameObject.Find("VerifierLight");
	light.GetComponent<Light>().color = c;
	
	yield return new WaitForSeconds (2);

	light.GetComponent<Light>().color = Color.white;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Creation Recette
        recipe = new Recipe();
		_apparitionPoint = GameObject.Find("ApparitionPoint");
		_recipeBurger = GameObject.Find("RecipeBurger");
		_textNbIngredient = GameObject.Find("TextNbIngredient").GetComponent<Text>();
		_textNbIngredient.text = _numberOfIngredients.ToString();

        ComputeRandomRecipe();
		StartCoroutine(CreateBurger());
        afficher();

        // Creation canva
        _recipeDisplayer = GameObject.Find("EcranRecette");
        _recipeDisplayerTransform = _recipeDisplayer.GetComponent<Transform>();
        _recipeText = _recipeDisplayer.GetComponent<Text>();

        _recipeText.text = recipe.ToString();
    }

    public void ResetRecipe(){
	if (_isCreating == false)
	{
	    DestroyBurger(_apparitionPoint);
	    RemoveRecipeComponent();
	    DestroyBurger(_recipeBurger);
	    ComputeRandomRecipe();
	    StartCoroutine(CreateBurger());	    
	}
    }

    public void AddIngredient(){
	if (_numberOfIngredients<15){
	    _numberOfIngredients++;
	    _textNbIngredient.text = _numberOfIngredients.ToString();
	}
    }

    public void RemoveIngredient(){
	if (_numberOfIngredients>1){
	    _numberOfIngredients--;
	    _textNbIngredient.text = _numberOfIngredients.ToString();
	}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
