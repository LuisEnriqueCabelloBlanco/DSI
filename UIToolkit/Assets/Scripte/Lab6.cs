using UnityEngine.UIElements;
using UnityEngine;
using System;
using UnityEngine.Assertions.Must;
using System.Collections.Generic;
using System.Linq;
using static UnityEngine.GraphicsBuffer;
//using Lab5b_namespace;

namespace Lab6_namespace
{
    public class Lab6 : MonoBehaviour
    {
        VisualElement botonCrear;
        Toggle toggleModificar;
        VisualElement contenedor_dcha;
        TextField input_nombre;
        TextField input_apellido;
        Individuo individuoSelec;

        List<Individuo> list_individuos = new List<Individuo>();

        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            contenedor_dcha = root.Q<VisualElement>("dcha");
            input_nombre = root.Q<TextField>("InputNombre");
            input_apellido = root.Q<TextField>("InputApellido");
            botonCrear = root.Q<Button>("BotonCrear");
            toggleModificar = root.Q<Toggle>("ToggleModificar");

            contenedor_dcha.RegisterCallback<ClickEvent>(seleccionTarjeta);
            botonCrear.RegisterCallback<ClickEvent>(NuevaTarjeta);
            input_nombre.RegisterCallback<ChangeEvent<String>>(CambioNombre);
            input_apellido.RegisterCallback<ChangeEvent<String>>(CambioApellido);
        }

        void NuevaTarjeta(ClickEvent evt)
        {
            if (!toggleModificar.value)
            {
                VisualTreeAsset plantilla = Resources.Load<VisualTreeAsset>("Templates/Tarjeta");
                VisualElement tarjetaPlantilla = plantilla.Instantiate();

                contenedor_dcha.Add(tarjetaPlantilla);
                tarjetas_borde_negro();
                tarjeta_borde_blanco(tarjetaPlantilla);

                Individuo individuo = new Individuo(input_nombre.value, input_apellido.value);
                Trajeta tarjeta = new Trajeta(tarjetaPlantilla, individuo);
                individuoSelec = individuo;

                list_individuos.Add(individuo);
                //list_individuos.ForEach(elem =>
                //{
                //    Debug.Log(elem.Nombre + " " + elem.Apellido);
                //    string jsonIndividuo = JsonUtility.ToJson(elem);
                //    Debug.Log(jsonIndividuo);
                //}
                //);
                string listaToJson = jsonHelperIndividuo.ToJson(list_individuos, true);
                Debug.Log(listaToJson);

                List<Individuo> jsonToList = jsonHelperIndividuo.FromJson<Individuo>(listaToJson);
                jsonToList.ForEach(elem =>
                {
                    Debug.Log(elem.Nombre + " " + elem.Apellido);
                });
            }

        }

        void CambioNombre(ChangeEvent<String> evt)
        {
            if (toggleModificar.value) 
            {
                individuoSelec.Nombre = evt.newValue;
            }
        }

        void CambioApellido(ChangeEvent<String> evt)
        {
            if (toggleModificar.value)
            {
                individuoSelec.Apellido = evt.newValue;
            }
        }

        void seleccionTarjeta(ClickEvent e)
        {
            VisualElement miTarjeta = e.target as VisualElement;
            individuoSelec = miTarjeta.userData as Individuo;

            tarjetas_borde_negro();
            tarjeta_borde_blanco(miTarjeta);

            input_nombre.SetValueWithoutNotify(individuoSelec.Nombre);
            input_apellido.SetValueWithoutNotify(individuoSelec.Apellido);
            toggleModificar.value = true;

        }

        void tarjetas_borde_negro()
        {
            List<VisualElement> lista_tarjetas = contenedor_dcha.Children().ToList();
            lista_tarjetas.ForEach(elem =>
            {
                VisualElement tarjeta = elem.Q("Tarjeta");

                tarjeta.style.borderBottomColor =  Color.black;
                tarjeta.style.borderRightColor =  Color.black;
                tarjeta.style.borderTopColor = Color.black;
                tarjeta.style.borderLeftColor =  Color.black;
            });

            
        }

        void tarjeta_borde_blanco(VisualElement tar)
        {
            VisualElement tarjeta = tar.Q("Tarjeta");

            tarjeta.style.borderBottomColor = Color.white;
            tarjeta.style.borderRightColor = Color.white;
            tarjeta.style.borderTopColor = Color.white;
            tarjeta.style.borderLeftColor = Color.white;
        }
    }
}

