using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public static int _numberOfTypes = 6;
    public Type type;

    public enum Type
    {
        PAINB = 0, PAINH, SALADE, STEAK, TOMATE, FROMAGE
    };

    override
    public string ToString()
    {
        string s = "";

        switch(type)
        {
            case Type.FROMAGE:
                s = "Fromage";
                break;
            case Type.PAINB:
                s = "Pain (Base)";
                break;
            case Type.PAINH:
                s = "Pain (Haut)";
                break;
            case Type.SALADE:
                s = "Salade";
                break;
            case Type.STEAK:
                s = "Steak";
                break;
            case Type.TOMATE:
                s = "Tomate";
                break;
            default:
                // do nothing
                break;
        }

        return s;
    }

    public Type getType()
    {
        return type;
    }

    public void setType(Type ptype)
    {
        type = ptype;
    }

}



