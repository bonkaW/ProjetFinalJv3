using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoldManager : MonoBehaviour
{
    
    public TextMeshProUGUI goldText; //Reference a l'element UI txt
    private int currentGold = 0; // montant de gold de base


    void Start(){

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
            UpdateGoldUI();
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
