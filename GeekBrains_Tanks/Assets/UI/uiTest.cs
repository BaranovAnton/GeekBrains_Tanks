using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class uiTest : MonoBehaviour {

    public string[] elements;

    void Start()
    {
        Dropdown dd = GetComponent<Dropdown>();
        dd.options.Clear();

        List<Dropdown.OptionData> items = new List<Dropdown.OptionData>();
        for (int i = 0; i < elements.Length; i++)
        {
            items.Add(new Dropdown.OptionData(elements[i]));
        }

        dd.AddOptions(items);
    }

}
