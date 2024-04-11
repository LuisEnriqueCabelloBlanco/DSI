using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Lab4 : VisualElement
{
    public new class UxmlFactory : UxmlFactory<Lab4,UxmlTraits> { };

    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        UxmlStringAttributeDescription m_String =
            new UxmlStringAttributeDescription { name = "my-string", defaultValue = "default_value" };
        UxmlIntAttributeDescription m_Int =
            new UxmlIntAttributeDescription { name = "my-int", defaultValue = 2 };
        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);
            var ate = ve as Lab4;

            ate.type = m_String.GetValueFromBag(bag, cc);
            ate.valor = m_Int.GetValueFromBag(bag, cc);
            ate.ValueFunction();
            ate.typeFunction();
        }

    }


    List<VisualElement> m_List = new List<VisualElement>();
    VisualElement m_VisualElement1 = new VisualElement();
    VisualElement m_VisualElement2 = new VisualElement();
    VisualElement m_VisualElement3 = new VisualElement();
    VisualElement m_VisualElement4 = new VisualElement();
    VisualElement m_VisualElement5 = new VisualElement();
    
    int valor = 2;
    string type;

    public string Type { 
        get=>type; 
        set {
            type = value;
            typeFunction(); }
    }
    public int Valor
    {
        get=>valor;
        set
        {
            valor = value;
            ValueFunction();
        }
    }

    void ValueFunction()
    {
        Debug.Log("Hola");
        for (int i = 0; i < 5; i++)
        {
            if(i <valor)
                m_List[i].style.unityBackgroundImageTintColor = new Color(1,1,1);
                
                //m_List[i].style.display = DisplayStyle.Flex;
            else
                m_List[i].style.unityBackgroundImageTintColor = new Color(0.5f,0.5f,0.5f);
                //m_List[i].style.display = DisplayStyle.None;
        }
    }

    void typeFunction()
    {
        foreach(VisualElement ve in m_List)
        {
            ve.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>(type));
        }
    }

    public Lab4()
    {
        for(int i = 0; i< 5; i++)
        {
            VisualElement ve = new VisualElement();
            ve.style.width = 100;
            ve.style.height = 100;
            ve.style.backgroundColor = Color.black;
            ve.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>(type));
            m_List.Add(ve);
            hierarchy.Add(ve);
        }
    }
}
