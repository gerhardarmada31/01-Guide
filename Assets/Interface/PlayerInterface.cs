using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICombative
{
    GameObject getAgentObj();
}

public interface IShroudedObj
{
    void shroudedObj(bool shroudEnabled);
}
