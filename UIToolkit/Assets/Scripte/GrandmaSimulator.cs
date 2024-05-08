using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GrandmaSimulator : MonoBehaviour
{
    VisualElement grandmaPhoto;
    VisualElment grandmaName;
    VisualElement nextArrow;


    VisualElement previousArrow;
    private int currentGrandma = 0;
    [SerializeField]
    List<ScriptableGrandmas> grandmas;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        nextArrow = root.Q("Next");
        nextArrow.RegisterCallback<ClickEvent>(NextGrandma);

    }



     void NextGrandma(ClickEvent evt)
     {
        currentGrandma = (currentGrandma + 1) % grandmas.size();
        ScriptableGrandmas currGrandmaData = grandmas.get(currentGrandma);

        //grandmaName = currGrandmaData.grandmaName;
        //Label nombreLabel = plantilla.Q<Label>("Nombre");
        //nombreLabel.text = evt.newValue;
        // selecIndividuo.Nombre = evt.newValue;

    }



}
