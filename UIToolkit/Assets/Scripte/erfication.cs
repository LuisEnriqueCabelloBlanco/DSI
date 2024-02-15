using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class erfication : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIDocument doc = GetComponent<UIDocument>();
        VisualElement root = doc.rootVisualElement;

        //Obtenemos los elementos que nos interesan
        //UQueryBuilder<VisualElement> builder = new(root);

        UQueryBuilder<VisualElement> cabesa = new (root.Q("Header"));
        UQueryBuilder<VisualElement> pie = new (root.Q("Foot"));
        
        List<VisualElement> labels = cabesa.ToList().SelectMany(elem => elem.Children()).Where(elem => elem.GetType() == typeof(Label)).ToList();
        List<VisualElement> pie_labels = pie.ToList().SelectMany(elem => elem.Children()).Where(elem => elem.GetType() == typeof(Label)).ToList();

        
        List<VisualElement> cabesa_pie = new() { root.Q("Header"), root.Q("Foot") } ;
        
        //List<VisualElement> list = builder.ToList();
        


        //foreach para alterar cada elelmento de la lista que hemos generado
        //list.ForEach(elem => Debug.Log(elem.name));
        cabesa_pie.ForEach(elem => elem.AddToClassList("erificationLvl1"));
        labels.ForEach(elem => elem.style.color = Color.green);
        pie_labels.ForEach(elem => elem.style.color = Color.green);
        
        /*
         * Eri: me voyus a coger la cabeza y lo vamos a seignar a erificacion1
         * me goco a los pequeños y los enchufamos a la erificacion 2
         * los botones pues ya sabes
         */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
