using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOpen : MonoBehaviour{

    [SerializeField] private GameObject levelsOpen;

    public void openLevels()
    {
        levelsOpen.SetActive(true);
    }

}