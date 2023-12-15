using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VerifyBurger : MonoBehaviour
{
    private Recipe recipe;
    public int _numberOfIngredients = 6;
    
    public GameObject _recipeDisplayer;
    public Transform _recipeDisplayerTransform;
    public Text _recipeText;

    void ComputeRandomRecipe()
    {
        recipe.RandomRecipe(_numberOfIngredients);
    }

    void afficher()
    {
        Debug.Log(recipe);
    }

    public void VerifyRecipe()
    {
        // get all ingredients game objects
        // compare to the recipe
        // treatment
        Ingredient[] listOfIngredient = GameObject.Find("ApparitionPoint").GetComponentsInChildren<Ingredient>();

        Recipe r = new Recipe(listOfIngredient.Length);

        foreach (Ingredient i in listOfIngredient)
        {
            r.AddIngredient(i);
            Debug.Log(i.ToString());
        }

        Debug.Log(r.ToString());
        Debug.Log(recipe.ToString());
        Debug.Log(recipe.ToString() == r.ToString());
    }

    // Start is called before the first frame update
    void Start()
    {
        // Creation Recette
        recipe = new Recipe();
        ComputeRandomRecipe();
        afficher();

        // Creation canva
        _recipeDisplayer = GameObject.Find("EcranRecette");
        _recipeDisplayerTransform = _recipeDisplayer.GetComponent<Transform>();
        _recipeText = _recipeDisplayer.GetComponent<Text>();

        _recipeText.text = recipe.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
