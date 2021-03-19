using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemies", menuName = "ScriptableObjects/NewEnemy", order = 1)]
public class Enemies : ScriptableObject
{
    public int life;
    public GameObject enemyObj;
    public int id;
}
