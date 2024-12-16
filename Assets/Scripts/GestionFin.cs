using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GestionFin : MonoBehaviour
{

    public void ChangerSceneAccueil(){
        SceneManager.LoadScene("Accueil");
    }
}
