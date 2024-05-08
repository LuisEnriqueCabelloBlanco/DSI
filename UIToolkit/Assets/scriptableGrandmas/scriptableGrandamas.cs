using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GrandmaScriptableObject", order = 1)]
public class ScriptableGrandmas : ScriptableObject
{
    public string grandmaName;
    public string fotoPath;

    public int te; //out of 5
    public int edad; // out of 5
    public int nietos; //out of 5

    public string consejo;
}