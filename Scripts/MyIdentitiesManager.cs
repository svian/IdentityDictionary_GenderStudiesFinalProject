using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class MyIdentitiesManager : MonoBehaviour
{
    [SerializeField] List<Button> mySexualIden = new List<Button>(), myRomanticIden = new List<Button>(), myGenderIden = new List<Button>(), myPronouns = new List<Button>();
    [SerializeField] private GameObject m_dropPrefab, m_dropPrefabVar, saveButton;
    private GameObject idenLabel = null;
    private GameObject clickedButton;
    private Dropdown changedDrop;
    private GameObject flag;
    private int dropValue;
    [SerializeField] private TMP_InputField nameText, customPro;

    public PlayerPrefsSave userData;
    //[SerializeField] private 

    public static MyIdentitiesManager ins;

    public DB_Entry user;

    void Awake()
    {
        ins = this;

        //user = userData.GetUserData();

        saveButton.SetActive(false);



    }

    //public IdentityDatabase identDB;

    void Start()
    {
        user = userData.GetUserData();

        if (user.name != null)
        {
            var temp_textHold = nameText;
            temp_textHold.text = user.name;
            nameText = temp_textHold;
        }

        if (user.customPronouns != null)
        {
            var temp_textHold = customPro;
            temp_textHold.text = user.customPronouns;
            customPro = temp_textHold;
        }
        //Debug.Log("Length: " +  user.pronounValues.Length);

        for (int i = 0; i < 3; i++)
        {
            if (user.pronounValues[i] != 0)
            {
                myPronouns[i].GetComponentInChildren<TextMeshProUGUI>().text = pronouns.labelList[user.pronounValues[i]];
            }
        }

        for (int i = 0; i < 2; i++)
        {
            //gender section
            flag = myGenderIden[i].transform.GetChild(1).gameObject;

            if (user.genderValues[i] != 0)
            {
                myGenderIden[i].GetComponentInChildren<TextMeshProUGUI>().text = gender.labelList[user.genderValues[i]];

                flag.GetComponent<Image>().sprite = gender.flagList[user.genderValues[i]];
                flag.SetActive(true);
            }
            else
            {
                flag.SetActive(false);
            }

            //sexual section
            flag = mySexualIden[i].transform.GetChild(1).gameObject;

            if (user.sexualValues[i] != 0)
            {
                mySexualIden[i].GetComponentInChildren<TextMeshProUGUI>().text = sexuality.labelList[user.sexualValues[i]];

                flag.GetComponent<Image>().sprite = sexuality.flagList[user.sexualValues[i]];
                flag.SetActive(true);
            }
            else
            {
                flag.SetActive(false);
            }

            //romantic section
            flag = myRomanticIden[i].transform.GetChild(1).gameObject;

            if (user.romanticValues[i] != 0)
            {
                myRomanticIden[i].GetComponentInChildren<TextMeshProUGUI>().text = romantic.labelList[user.romanticValues[i]];

                flag.GetComponent<Image>().sprite = romantic.flagList[user.romanticValues[i]];
                flag.SetActive(true);
            }
            else
            {
                flag.SetActive(false);
            }

        }

        // Debug.Log( user.name);
    }

    public void AddNew(string type)
    {

        var temp_button = EventSystem.current.currentSelectedGameObject;

        int doesChildExist = temp_button.transform.childCount;


        if (doesChildExist == 2)
        {
            m_dropPrefab.transform.position = new Vector3(0, 0, 0);
            var newDropdown = Instantiate(m_dropPrefab, m_dropPrefab.transform.position, m_dropPrefab.transform.rotation);
            newDropdown.transform.SetParent(temp_button.transform, false);

            NewDropdown(type, newDropdown.GetComponent<Dropdown>());

            newDropdown.GetComponent<Dropdown>().onValueChanged.AddListener(delegate
            {
                DropdownValueChanged(newDropdown.GetComponent<Dropdown>(), temp_button);
            });
        }
        else
        {
            GameObject existsDropdown = temp_button.GetComponentInChildren<Dropdown>(true).gameObject;
            //temp_button.
            existsDropdown.SetActive(true);

        }


        DataChanged();

    }

    public void AddNewVar(string type)
    {

        var temp_button = EventSystem.current.currentSelectedGameObject;

        m_dropPrefabVar.transform.position = new Vector3(0, 0, 0);
        var newDropdown = Instantiate(m_dropPrefabVar, m_dropPrefabVar.transform.position, m_dropPrefabVar.transform.rotation);
        newDropdown.transform.SetParent(temp_button.transform, false);

        NewDropdown(type, newDropdown.GetComponent<Dropdown>());

        newDropdown.GetComponent<Dropdown>().onValueChanged.AddListener(delegate
        {
            DropdownValueChanged(newDropdown.GetComponent<Dropdown>(), temp_button);
        });

        DataChanged();
    }

    void DropdownValueChanged(Dropdown changed, GameObject clicked)
    {
        changedDrop = changed;
        clickedButton = clicked;

        dropValue = changed.value;

    }

    public void DataChanged()
    {
        saveButton.SetActive(true);
    }

    [SerializeField] Identities gender, sexuality, romantic, pronouns;
    //string type = null;
    //[SerializeField] Dropdown m_dropdown;
    Dropdown.OptionData m_NewData;

    public void NewDropdown(string type, Dropdown m_dropdown)
    {
        m_dropdown.options.Clear();
        if (type == "gender")
        {

            foreach (string label in gender.labelList)
            {
                //Create a new option for the Dropdown menu which reads "Option 1" and add to messages List
                m_NewData = new Dropdown.OptionData();
                m_NewData.text = label;

                int temp_index = gender.labelList.IndexOf(label);
                m_NewData.image = gender.flagList[temp_index];

                m_dropdown.options.Add(m_NewData);
            }
        }
        else if (type == "sexual")
        {

            foreach (string label in sexuality.labelList)
            {
                //Create a new option for the Dropdown menu which reads "Option 1" and add to messages List
                m_NewData = new Dropdown.OptionData();
                m_NewData.text = label;

                int temp_index = sexuality.labelList.IndexOf(label);
                m_NewData.image = sexuality.flagList[temp_index];

                m_dropdown.options.Add(m_NewData);
            }
        }
        else if (type == "romantic")
        {

            foreach (string label in romantic.labelList)
            {
                //Create a new option for the Dropdown menu which reads "Option 1" and add to messages List
                m_NewData = new Dropdown.OptionData();
                m_NewData.text = label;

                int temp_index = romantic.labelList.IndexOf(label);
                m_NewData.image = romantic.flagList[temp_index];

                m_dropdown.options.Add(m_NewData);
            }
        }
        else if (type == "pronouns")
        {

            foreach (string label in pronouns.labelList)
            {
                //Create a new option for the Dropdown menu which reads "Option 1" and add to messages List
                m_NewData = new Dropdown.OptionData();
                m_NewData.text = label;

                int temp_index = pronouns.labelList.IndexOf(label);
                // m_NewData.image = pronouns.flagList[temp_index];

                m_dropdown.options.Add(m_NewData);
            }
        }
    }

    public void SaveIdentities()
    {
        saveButton.SetActive(false);

        GameObject[] temp = GameObject.FindGameObjectsWithTag("Dropdown");

        int temp_dropValue = 0;

        foreach (Button slot in myPronouns)
        {
            int temp_index = myPronouns.IndexOf(slot);
            Dropdown temp_dropChild = slot.GetComponentInChildren<Dropdown>();

            if (temp_dropChild != null)
            {
                temp_dropValue = temp_dropChild.value;

                if (temp_dropChild == null)
                {
                    temp_dropValue = 0;
                    slot.GetComponentInChildren<TextMeshProUGUI>().text = "Add New";

                }
                else
                {
                    if (temp_dropValue == 0)
                    {
                        slot.GetComponentInChildren<TextMeshProUGUI>().text = "Add New";
                    }
                    else
                    {
                        slot.GetComponentInChildren<TextMeshProUGUI>().text = temp_dropChild.GetComponentInChildren<Text>().text;
                    }
                }

                userData.SetPronounValues(temp_index, temp_dropValue);
            }
        }

        foreach (Button slot in myGenderIden)
        {
            int temp_index = myGenderIden.IndexOf(slot);
            Dropdown temp_dropChild = slot.GetComponentInChildren<Dropdown>();

            if (temp_dropChild != null)
            {
                temp_dropValue = GetDropdownValue(temp_dropChild, slot, temp_dropValue);

                userData.SetGenderValues(temp_index, temp_dropValue);
            }
        }

        foreach (Button slot in myRomanticIden)
        {
            int temp_index = myRomanticIden.IndexOf(slot);
            Dropdown temp_dropChild = slot.GetComponentInChildren<Dropdown>();

            if (temp_dropChild != null)
            {
                temp_dropValue = GetDropdownValue(temp_dropChild, slot, temp_dropValue);

                userData.SetRomanticValues(temp_index, temp_dropValue);
            }
        }

        foreach (Button slot in mySexualIden)
        {
            int temp_index = mySexualIden.IndexOf(slot);
            Dropdown temp_dropChild = slot.GetComponentInChildren<Dropdown>();

            if (temp_dropChild != null)
            {
                temp_dropValue = GetDropdownValue(temp_dropChild, slot, temp_dropValue);

                userData.SetSexualValues(temp_index, temp_dropValue);
            }
        }

        if (nameText.text != null)
        {
            userData.SetUserName(nameText.text);
        }

        if (customPro.text != null)
        {
            userData.SetCustomPronouns(customPro.text);
        }


        foreach (GameObject drop in temp)
        {
            drop.SetActive(false);
        }

    }


    public int GetDropdownValue(Dropdown dropChild, Button temp_slot, int dropValue)
    {
        dropValue = dropChild.value;

        if (dropChild == null)
        {
            dropValue = 0;

            GameObject temp_flag = temp_slot.transform.GetChild(1).gameObject;
            temp_flag.SetActive(false);
            temp_slot.GetComponentInChildren<TextMeshProUGUI>().text = "Add New";

        }
        else
        {
            if (dropValue == 0)
            {
                GameObject temp_flag = temp_slot.transform.GetChild(1).gameObject;
                temp_flag.SetActive(false);
                temp_slot.GetComponentInChildren<TextMeshProUGUI>().text = "Add New";
            }
            else
            {

                temp_slot.GetComponentInChildren<TextMeshProUGUI>().text = dropChild.GetComponentInChildren<Text>().text;
                GameObject temp_flag = temp_slot.transform.GetChild(1).gameObject;
                temp_flag.SetActive(true);

                temp_flag.GetComponent<Image>().sprite = dropChild.options[dropValue].image;
            }
        }

        return dropValue;
    }
}

[System.Serializable]
public class DB_Entry
{
    public string name;
    public int[] pronounValues = new int[3];
    public string customPronouns;
    public int[] genderValues = new int[2];
    public int[] sexualValues = new int[2];
    public int[] romanticValues = new int[2];
}

/*[System.Serializable]
public class IdentityDatabase
{
    public DB_Entry user;
}*/
