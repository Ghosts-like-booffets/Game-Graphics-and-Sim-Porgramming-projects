using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class QuestGoal 
{
    public Goaltype goalType;

    public int requiredAmount;
    public int currentAmount;

    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }
}



public enum Goaltype
{
    talk,
    gather, 
    kill,
    escort
}