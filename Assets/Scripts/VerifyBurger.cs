using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VerifyBurger : MonoBehaviour
{
    private Recipe recipe;
    public int _numberOfIngredients = 6;
    
    GameObject _recipeDisplayer;
    Transform _recipeDisplayerTransform;

    void ComputeRandomRecipe()
    {
        recipe.RandomRecipe(_numberOfIngredients);
    }

    void afficher()
    {
        Debug.Log(recipe);
    }

    void VerifyRecipe()
    {
        // get all ingredients game objects
        // compare to the recipe
        // treatment
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
