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

    public void RandomRecipe(int n)
    {
        _listOfingredients = new List<Ingredient>(n);
        _listOfingredients.Add(new Ingredient(Ingredient.Type.PAINB));

        for (int i = 0; i < n; i++)
        {
            Ingredient item = new Ingredient();
            _listOfingredients.Add(item);
        }

        _listOfingredients.Add(new Ingredient(Ingredient.Type.PAINH));
    }

    override
    public string ToString()
    {
        string s = "";

        foreach (Ingredient i in _listOfingredients)
        {
            s += i.ToString();
            s += " ";
        }

        return s;
    }

    public Recipe()
    {
        // do nothing
    }
}
