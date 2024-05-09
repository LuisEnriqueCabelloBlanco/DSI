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

    Lab4 teStats;
    Lab4 nietosStats;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        nextArrow = root.Q("Next");
        nextArrow.RegisterCallback<ClickEvent>(NextGrandma);
        previousArrow = root.Q("Previous");
        previousArrow.RegisterCallback<ClickEvent>(PreviousGrandma);
        grandmaName = root.Q<Label>("Name");
        grandmaPhoto = root.Q("Photo");

        teStats = root.Q<Lab4>("Te");
        //teStats.changeImage("Images/te");
        nietosStats = root.Q<Lab4>("Nietos");
        //nietosStats.changeImage("Images/nieto");
    }



     void NextGrandma(ClickEvent evt)
     {
        currentGrandma = (currentGrandma + 1) % grandmas.Count;
        ScriptableGrandmas currGrandmaData = grandmas[currentGrandma];

        grandmaName.text = currGrandmaData.grandmaName;
        nietosStats.changeValue(currGrandmaData.nietos);
        teStats.changeValue(currGrandmaData.te);
        grandmaPhoto.style.backgroundImage = new StyleBackground(Resources.Load<Texture2D>(currGrandmaData.fotoPath));
    }

    void PreviousGrandma(ClickEvent evt)
    {
        currentGrandma = (grandmas.Count + currentGrandma - 1) % grandmas.Count;
        ScriptableGrandmas currGrandmaData = grandmas[currentGrandma];

        grandmaName.text = currGrandmaData.grandmaName;
        nietosStats.changeValue(currGrandmaData.nietos);
        teStats.changeValue(currGrandmaData.te);

    }



}
