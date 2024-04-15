using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class Lab5 : MonoBehaviour
{

    VisualElement plantilla;

    TextField input_nombre;

    TextField input_apellido;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        plantilla = root.Q("Plantilla");
        input_nombre = root.Q<TextField>("InputNombre");
        input_apellido = root.Q<TextField>("InputApellido");

        VisualElement a = root.Q("header");
        a.Children();
        foreach(VisualElement nieto in a.Children())
        {
            nieto.RegisterCallback<ClickEvent>(CambioIcono);
        }
        plantilla.RegisterCallback<ClickEvent>(SeleccionIndividuo);
        input_nombre.RegisterCallback<ChangeEvent<string>>(CambioNombre);
        input_apellido.RegisterCallback<ChangeEvent<string>>(CambioApellido);
    }

    void SeleccionIndividuo(ClickEvent evt)
    {
        string nombre = plantilla.Q<Label>("Nombre").text;
        string apellido = plantilla.Q<Label>("Apellido").text;

        Debug.Log(nombre);

        input_nombre.SetValueWithoutNotify(nombre);
        input_apellido.SetValueWithoutNotify(apellido);

    }

    void CambioNombre(ChangeEvent<string> evt)
    {
        Label nombreLabel = plantilla.Q<Label>("Nombre");
        nombreLabel.text = evt.newValue;
    }

    void CambioApellido(ChangeEvent<string> evt)
    {
        Label apellidoLabel = plantilla.Q<Label>("Apellido");
        apellidoLabel.text = evt.newValue;
    }
    void CambioIcono(ClickEvent evt)
    {
        VisualElement icon = plantilla.Q<VisualElement>("top");
        VisualElement clicked = evt.target as VisualElement;
        icon.style.backgroundImage = clicked.style.backgroundImage.value;
        Debug.Log(clicked.style);
        
    }
}
