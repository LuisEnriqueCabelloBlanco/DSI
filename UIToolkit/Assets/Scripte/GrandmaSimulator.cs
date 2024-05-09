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
    


    
    private int currentGrandma = 0;
    [SerializeField]
    List<ScriptableGrandmas> grandmas;

    Lab4 teStats;
    Lab4 nietosStats;
    Lab4 edadStats;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        VisualElement nextArrow = root.Q("Next");
        nextArrow.RegisterCallback<ClickEvent>(NextGrandma);
        VisualElement previousArrow = root.Q("Previous");
        previousArrow.RegisterCallback<ClickEvent>(PreviousGrandma);
        grandmaName = root.Q<Label>("Name");
        grandmaPhoto = root.Q("Photo");

        teStats = root.Q<Lab4>("Te");
        teStats.changeImage("Images/te");
        nietosStats = root.Q<Lab4>("Nietos");
        nietosStats.changeImage("Images/nieto");
        edadStats = root.Q<Lab4>("Edad");
        edadStats.changeImage("Images/edad");

        setGrandma();
    }



     void NextGrandma(ClickEvent evt)
     {
        currentGrandma = (currentGrandma + 1) % grandmas.Count;
        ScriptableGrandmas currGrandmaData = grandmas[currentGrandma];

        setGrandma();
    }

    void PreviousGrandma(ClickEvent evt)
    {
        currentGrandma = (grandmas.Count + currentGrandma - 1) % grandmas.Count;
        ScriptableGrandmas currGrandmaData = grandmas[currentGrandma];

        setGrandma();

    }

    void setGrandma()
    {
        ScriptableGrandmas currGrandmaData = grandmas[currentGrandma];

        grandmaName.text = currGrandmaData.grandmaName;
        nietosStats.changeValue(currGrandmaData.nietos);
        teStats.changeValue(currGrandmaData.te);
        edadStats.changeValue(currGrandmaData.edad);
        grandmaPhoto.style.backgroundImage = new StyleBackground(Resources.Load<Texture2D>(currGrandmaData.fotoPath));
    }



}
