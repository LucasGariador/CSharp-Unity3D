using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStarter : MonoBehaviour
{
    [SerializeField]
    Transform [] battleStations;
    int stations = 0;
    [SerializeField]
    Transform [] enemiesBattleStations;

    GameObject [] battlers;
    // Start is called before the first frame update
    void Start()
    {
        battlers = GameObject.FindGameObjectsWithTag("Battler");
    }

    private void Awake()
    {
        stations = 0;
    }

    #region Characters SetUp
    //Gets the characters that will participate on the combat
    public void SetStarters(int ident)
    {
        for(int i = 0; i < battlers.Length; i++)
        {
            if(battlers[i].GetComponent<BattlerController>().id == ident)
            {
                AssignStation(i);
            }
        }
    }
    //Assign the station to the characters
    void AssignStation(int ind)
    {
        if (stations <= 3)
        {
            battlers[ind].transform.position = battleStations[stations].position;
            stations++;
        }
    }
    #endregion

    #region Enemies SetUp

    #endregion

}
