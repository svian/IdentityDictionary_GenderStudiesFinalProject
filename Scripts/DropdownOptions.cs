using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownOptions : MonoBehaviour
{
    [SerializeField] Identities gender, sexuality, romantic;
    //string type = null;
    //[SerializeField] Dropdown m_dropdown;
    Dropdown.OptionData m_NewData;

    public void NewDropdown(string type, Dropdown m_dropdown)
    {
        m_dropdown.options.Clear();
        if (type == "gender")
        {
            m_dropdown = GetComponent<Dropdown>();
            foreach (string label in gender.labelList)
            {
                //Create a new option for the Dropdown menu which reads "Option 1" and add to messages List
                m_NewData = new Dropdown.OptionData();
                m_NewData.text = label;
                m_dropdown.options.Add(m_NewData);
            }
        }
        else if (type == "sexual")
        {
            m_dropdown = GetComponent<Dropdown>();
            foreach (string label in sexuality.labelList)
            {
                //Create a new option for the Dropdown menu which reads "Option 1" and add to messages List
                m_NewData = new Dropdown.OptionData();
                m_NewData.text = label;
                m_dropdown.options.Add(m_NewData);
            }
        }
        else if (type == "romantic")
        {
            m_dropdown = GetComponent<Dropdown>();
            foreach (string label in romantic.labelList)
            {
                //Create a new option for the Dropdown menu which reads "Option 1" and add to messages List
                m_NewData = new Dropdown.OptionData();
                m_NewData.text = label;
                m_dropdown.options.Add(m_NewData);
            }
        }
    }
}

