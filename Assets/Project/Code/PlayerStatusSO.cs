using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatus", menuName = "ScriptableObjects/PlayerStatusSO", order = 1)]
public class PlayerStatusSO : ScriptableObject
{
    [SerializeField] int hp;
    [SerializeField] int attackPower;
    [SerializeField] int defensePower;
    [SerializeField] int speed;

    public int HP { get => hp; }
    public int AttackPower { get => attackPower; }
    public int DefensePower { get => defensePower; }
    public int Speed { get => speed; }
}
