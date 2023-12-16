using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe
{
    private List<Ingredient> _listOfingredients;

    public List<Ingredient> GetRecipe()
    {
        return _listOfingredients;
    }

    public Recipe(int n)
    {
        _listOfingredients = new List<Ingredient>(n);
    }

    public void RandomRecipe(int n)
    {
        Ingredient item = GameObject.Find("Verifier").AddComponent(typeof(Ingredient)) as Ingredient;
        item.setType(Ingredient.Type.PAINB);

        _listOfingredients = new List<Ingredient>(n);
        _listOfingredients.Add(item);

        for (int i = 0; i < n; i++)
        {
            item = GameObject.Find("Verifier").AddComponent(typeof(Ingredient)) as Ingredient;
            item.setType((Ingredient.Type) Random.Range(2, Ingredient._numberOfTypes));
            _listOfingredients.Add(item);
        }

        item = GameObject.Find("Verifier").AddComponent(typeof(Ingredient)) as Ingredient;
        item.setType(Ingredient.Type.PAINH);

        _listOfingredients.Add(item);
    }

    public void AddIngredient(Ingredient i)
    {
        _listOfingredients.Add(i);
    }

    override
    public string ToString()
    {
        string s = "";

        foreach (Ingredient i in _listOfingredients)
        {
            s += i.ToString();
            s += "\n";
        }

        return s;
    }

    public Recipe()
    {
        // do nothing
    }
}
