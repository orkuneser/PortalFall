using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject", order = 1)]
public class CharacterDataObject : ScriptableObject
{
    public string characterName;
    public int characterID;
    public int characterPrice;
    public bool isPurchase;
}
