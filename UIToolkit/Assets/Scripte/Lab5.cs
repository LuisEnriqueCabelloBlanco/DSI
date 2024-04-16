using lab5b_namespace;
using Lab5b_namespace;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class Lab5 : MonoBehaviour
{

    List<Individuo> individuos;
    Individuo selecIndividuo;

    VisualElement plantilla;
    VisualElement plantilla2;
    VisualElement plantilla3;
    VisualElement plantilla4;
    VisualElement plantillaSelect;

    TextField input_nombre;

    TextField input_apellido;



private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        //plantilla = root.Q("Plantilla");
        //input_nombre = root.Q<TextField>("InputNombre");
        //input_apellido = root.Q<TextField>("InputApellido");

        //individuoPrueba = new Individuo("Perico", "Palotes");

        //Trajeta tarjetaPrueba = new Trajeta(plantilla, individuoPrueba);

        //input_nombre.RegisterCallback<ChangeEvent<string>>(CambioNombre);
        //input_apellido.RegisterCallback<ChangeEvent<string>>(CambioApellido);

        //input_nombre.SetValueWithoutNotify(individuoPrueba.Nombre);
        //input_apellido.SetValueWithoutNotify(individuoPrueba.Apellido);

        plantilla = root.Q("Tarjeta1");
        plantilla2 = root.Q("Tarjeta2");
        plantilla3 = root.Q("Tarjeta3");
        plantilla4 = root.Q("Tarjeta4");


        input_nombre = root.Q<TextField>("InputNombre");
        input_apellido = root.Q<TextField>("InputApellido");
        VisualElement a = root.Q("header");

        a.Children();
        foreach (VisualElement nieto in a.Children())
        {
            nieto.RegisterCallback<ClickEvent>(CambioIcono);
        }


        individuos = BaseDatos.getData();

        VisualElement panelDcha = root.Q("dcha");
        panelDcha.RegisterCallback<ClickEvent>(SeleccionIndividuo);


        input_nombre.RegisterCallback<ChangeEvent<string>>(CambioNombre);
        input_apellido.RegisterCallback<ChangeEvent<string>>(CambioApellido);

        InitializeUI();
    }

    void SeleccionIndividuo(ClickEvent evt)
    {
        plantillaSelect = evt.target as VisualElement;
        selecIndividuo = plantillaSelect.userData as Individuo;

        input_nombre.SetValueWithoutNotify(selecIndividuo.Nombre);
        input_apellido.SetValueWithoutNotify(selecIndividuo.Apellido);

    }

    void CambioNombre(ChangeEvent<string> evt)
    {
        //Label nombreLabel = plantilla.Q<Label>("Nombre");
        //nombreLabel.text = evt.newValue;
        selecIndividuo.Nombre = evt.newValue;
    }

    void CambioApellido(ChangeEvent<string> evt)
    {
        //Label apellidoLabel = plantilla.Q<Label>("Apellido");
        //apellidoLabel.text = evt.newValue;
        selecIndividuo.Apellido = evt.newValue;
    }
    void CambioIcono(ClickEvent evt)
    {
        VisualElement icon = plantillaSelect.Q<VisualElement>("top");

        VisualElement clicked = evt.target as VisualElement;
        icon.style.backgroundImage = clicked.resolvedStyle.backgroundImage;
        Debug.Log(clicked.style);

    }
    void InitializeUI()

    {
        Trajeta tar1 = new Trajeta(plantilla, individuos[0]);
        Trajeta tar2 = new Trajeta(plantilla2, individuos[1]);
        Trajeta tar3 = new Trajeta(plantilla3, individuos[2]);
        Trajeta tar4 = new Trajeta(plantilla4, individuos[3]);
    }
}
