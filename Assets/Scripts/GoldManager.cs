using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoldManager : MonoBehaviour
{

    [SerializeField] private InfosJoueur _infosJoueur;
    
    public TextMeshProUGUI goldText; //Reference a l'element UI txt
    private int currentGold = 0; // montant de gold de base
    private bool isNewGame = true;


    void Start(){

        if (isNewGame)
        {
            _infosJoueur.nbGold = 0;
            isNewGame = false;
        }

        currentGold = _infosJoueur.nbGold;
        UpdateGoldUI();
        StartCoroutine(AddGoldOverTime());

    }

    private IEnumerator AddGoldOverTime(){

        while(true){

            yield return new WaitForSeconds(1);
            Addgold(1);

        }

    }

    public void Addgold(int amount)
    {

        currentGold += amount;
        _infosJoueur.nbGold = currentGold;
        UpdateGoldUI();

    }

    public int GetCurrentGold()
    {
        return currentGold;
    }

    public bool SpendGold(int amount)
    {
        if (currentGold >= amount)
        {

            currentGold -= amount;
            _infosJoueur.nbGold = currentGold;
            UpdateGoldUI();

            Debug.Log("Gold after spending in ScriptableObject: " + _infosJoueur.nbGold);
            return true;

        }
        else {

            Debug.LogWarning("Not enough gold!");
            return false;

        }
    }

    private void UpdateGoldUI(){

        goldText.text = currentGold.ToString();

    }

}
