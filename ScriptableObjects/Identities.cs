using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/IdentityScriptableObject", order = 1)]
public class Identities : ScriptableObject
{
    public List<string> labelList = new List<string>();
    public List<Sprite> flagList = new List<Sprite>();
}
