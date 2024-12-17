using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionNiveau : MonoBehaviour
{
    [SerializeField] private InfosJoueur _infosJoueur;

    void Start(){
        _infosJoueur.nbGold = 0;
        _infosJoueur.nbVies = 3;
    }
}
