using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GrandmaSimulator : MonoBehaviour
{
    VisualElement grandmaPhoto;
    Label grandmaName;
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
        previousArrow = root.Q("Previous");
        previousArrow.RegisterCallback<ClickEvent>(PreviousGrandma);
        grandmaName = root.Q<Label>("Name");
        grandmaPhoto = root.Q("Photo");
    }



     void NextGrandma(ClickEvent evt)
     {
        currentGrandma = (currentGrandma + 1) % grandmas.Count;
        ScriptableGrandmas currGrandmaData = grandmas[currentGrandma];

        grandmaName.text = currGrandmaData.grandmaName;
        //Label nombreLabel = plantilla.Q<Label>("Nombre");
        //nombreLabel.text = evt.newValue;
        // selecIndividuo.Nombre = evt.newValue;

     }
    void PreviousGrandma(ClickEvent evt)
    {
        //hay q mirar como se hacia esto
        currentGrandma = Math.Abs((currentGrandma - 1) % grandmas.Count);
        ScriptableGrandmas currGrandmaData = grandmas[currentGrandma];

        grandmaName.text = currGrandmaData.grandmaName;
        //Label nombreLabel = plantilla.Q<Label>("Nombre");
        //nombreLabel.text = evt.newValue;
        // selecIndividuo.Nombre = evt.newValue;

    }



}
