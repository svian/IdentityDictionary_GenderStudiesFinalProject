using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsSave : MonoBehaviour
{
    public DB_Entry user;

    void Awake()
    {
        if (PlayerPrefs.HasKey("UserName"))  // check if we already save It before
        {
            user.name = PlayerPrefs.GetString("UserName");
        }
        else
        {
            user.name = null;
        }

        if (PlayerPrefs.HasKey("CustomPronouns"))  // check if we already save It before
        {
            user.customPronouns = PlayerPrefs.GetString("CustomPronouns");
        }
        else
        {
            user.customPronouns = null;
        }

        for (int i = 0; i < 3; i++)
        {
            if (PlayerPrefs.HasKey("PronounValues" + i))
            {
                user.pronounValues[i] = PlayerPrefs.GetInt("PronounValues" + i);
            }
            else
            {
                user.pronounValues[i] = 0;
            }
        }

        for (int i = 0; i < 2; i++)
        {
            if (PlayerPrefs.HasKey("SexualValues" + i))
            {
                user.sexualValues[i] = PlayerPrefs.GetInt("SexualValues" + i);
            }
            else
            {
                user.sexualValues[i] = 0;
            }
        }

        for (int i = 0; i < 2; i++)
        {
            if (PlayerPrefs.HasKey("GenderValues" + i))
            {
                user.genderValues[i] = PlayerPrefs.GetInt("GenderValues" + i);
            }
            else
            {
                user.genderValues[i] = 0;
            }
        }

        for (int i = 0; i < 2; i++)
        {
            if (PlayerPrefs.HasKey("RomanticValues" + i))
            {
                user.romanticValues[i] = PlayerPrefs.GetInt("RomanticValues" + i);
            }
            else
            {
                user.romanticValues[i] = 0;
            }
        }
    }

    public DB_Entry GetUserData()
    {
        return user;
    }

    public void SetUserName(string name)
    {
        PlayerPrefs.SetString("UserName", name);
        user.name = name;
    }

    public void SetCustomPronouns(string pronouns)
    {
        PlayerPrefs.SetString("CustomPronouns", pronouns);
       // user.customPronouns = pronouns;
    }

    public void SetRomanticValues(int index, int value)
    {
        PlayerPrefs.SetInt("RomanticValues" + index, value);
      //  user.romanticValues[index] = value;
    }

    public void SetGenderValues(int index, int value)
    {
        PlayerPrefs.SetInt("GenderValues" + index, value);
      //  user.genderValues[index] = value;
    }

    public void SetSexualValues(int index, int value)
    {
        PlayerPrefs.SetInt("SexualValues" + index, value);
      //  user.sexualValues[index] = value;

        Debug.Log(PlayerPrefs.GetInt("SexualValue" +index));
    }

    public void SetPronounValues(int index, int value)
    {
        PlayerPrefs.SetInt("PronounValues" + index, value);
      //  user.pronounValues[index] = value;
    }

}
