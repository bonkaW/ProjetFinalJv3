using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/InfosJoueur", fileName = "InfosJoueur")]
public class InfosJoueur : ScriptableObject
{
    public int nbGold;
    public int nbVies = 3;
}
