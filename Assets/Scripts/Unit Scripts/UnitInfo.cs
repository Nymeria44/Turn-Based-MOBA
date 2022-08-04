using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitInfo", menuName = "Data/UnitInfo")]
public class UnitInfo : ScriptableObject
{
    /// <summary>
    /// 1 is player 1; 2 is player 2
    /// </summary>
    public int team;
    /// <summary>
    /// Q position of unit
    /// </summary>
    public int Q;
    /// <summary>
    /// R position of unit
    /// </summary>
    public int R;
    /// <summary>
    /// S position of unit
    /// </summary>
    public int S;
    /// <summary>
    /// Number of tiles a unit can move
    /// </summary>
    public int moveSpeed;
    /// <summary>
    /// Creates a cube coor vector
    /// </summary>
    /// <returns></returns>
    public Vector3Int QRSVec ()
    {
        Vector3Int qrsvect = new();
        qrsvect.x = Q;
        qrsvect.y = R;
        qrsvect.z = S;
        return qrsvect;
    }
    /// <summary>
    /// Unit's total health pool
    /// </summary>
    /// float totalHP;
    /// <summary>
    /// Unit's current health pool
    /// </summary>
    public float currentHP;
    /// <summary>
    /// Unit's total mana pool
    /// </summary>
    public float totalMP;
    /// <summary>
    /// Unit's current mana pool
    /// </summary>
    public float currentMP;
    /// <summary>
    /// Experience points of unit
    /// </summary>
    public int Exp;
    /// <summary>
    /// Current level of unit
    /// </summary>
    public int LVL;
    /// <summary>
    /// Attack speed of the unit
    /// </summary>
    public float attackSpeed;
    /// <summary>
    /// The speed at which spells are cast
    /// </summary>
    public float spellSpeed;
    /// <summary>
    /// Units armour
    /// </summary>
    public float armour;
    /// <summary>
    /// Units magic resist
    /// </summary>
    public float magicResist;
}