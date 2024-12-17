using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GestionAccueil : MonoBehaviour
{

    public void ChangerSceneNiveau01(){
        SceneManager.LoadScene("Niveau01");
    }
}
