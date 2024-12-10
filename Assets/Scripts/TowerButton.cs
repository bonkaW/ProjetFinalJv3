using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour
{
    [SerializeField] SpawnTower spawnTower;


    public void spawnButton(GameObject tower){ 
    
        spawnTower.towerPrefab = tower; 
    }

}
