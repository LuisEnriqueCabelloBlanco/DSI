using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Lab3 : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        VisualElement izda = root.Q("Izda");
        VisualElement dcha = root.Q("Dcha");

        List<VisualElement> lveizda = izda.Children().ToList();
        List<VisualElement> lvedcha = dcha.Children().ToList();

        lveizda.ForEach(elem => elem.AddManipulator(new Lab3Manipulator()));
        lvedcha.ForEach(elem => elem.AddManipulator(new Lab3Manipulator()));

        izda.RegisterCallback<ClickEvent>(
            ev =>
            {
                Debug.Log("Democracia");
            }, TrickleDown.TrickleDown);
        dcha.RegisterCallback<ClickEvent>(
            ev =>
            {
                Debug.Log("Libertad");
            }, TrickleDown.TrickleDown);
    }
}

