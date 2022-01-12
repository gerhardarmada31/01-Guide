using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This for the player taking damage
public interface ITakeDamage
{
    void TakeDamage(int takeDamge);
}

//del
public interface IInvuFrames
{
    void InvuFrames(float invuSeconds);
}

public interface ITakePosition
{
    void TakePosition(Vector3 takeposition);
}

public interface ICombatZone
{
    void TargetObject(bool inCombat);
}

public enum DropType { COIN, HEALTH, SPIRIT }

public interface ICollector
{
    void GetCollectDrop(int dropAmount, DropType _dropType);
}

public interface ICoinReward
{
    void GetCoinReward(int coinAmount);
}