using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Expressions
{
    public string expressionName;
    public Sprite expressionArt;
}
[CreateAssetMenu(menuName = "Character", fileName = "An acting one", order = 0)]
public class Character : ScriptableObject
{
    public string characterName;
    //Not sure I need this here, probably can stay in a special Ink node? Boh.
    public string bio;
    public List<Expressions> expressionsList;

}
