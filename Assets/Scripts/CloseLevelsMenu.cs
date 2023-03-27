using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseLevelsMenu : MonoBehaviour
{

    [SerializeField] private GameObject levelsClose;

    public void closeLevels()
    {
        levelsClose.SetActive(false);
    }

}