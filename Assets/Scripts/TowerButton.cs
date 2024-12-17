using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour
{
    [SerializeField] SpawnTower spawnTower;
    [SerializeField] private int towerCost;


    public void spawnButton(GameObject tower){ 
    
        spawnTower.towerPrefab = tower;
        spawnTower.SetTowerCost(towerCost);
    }

}
