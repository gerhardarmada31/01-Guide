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

public interface ITargetInfo
{
    void GetTargetInfo(out string _targetName, out string act01, out string act02, out int spReq01, out int spReq02);
}

