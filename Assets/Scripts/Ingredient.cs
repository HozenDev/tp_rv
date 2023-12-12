using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient
{
    public enum Type
    {
        FROMAGE = 0, PAINB, PAINH, SALADE, STEAK, TOMATE
    };

    private Type type;
    public Type getType()
    {
        return type;
    }

}



