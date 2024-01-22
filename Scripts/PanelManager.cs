using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] GameObject mainPanel, genderIdenPanel, genderExpressPanel, assignedSexPanel, sexualAttracPanel, romanticAttracPanel, moreResources;
    [SerializeField] GameObject myIdentitiesPanel, aboutPanel, pronounsPanel, naviDrawerPanel;
    private int activePanel;

    void Awake()
    {
        OnNewPanel(0);
    }


    public void OnNewPanel(int button)
    {
        mainPanel.SetActive(false);
        genderIdenPanel.SetActive(false);
        genderExpressPanel.SetActive(false);
        assignedSexPanel.SetActive(false);
        sexualAttracPanel.SetActive(false);
        romanticAttracPanel.SetActive(false);
        moreResources.SetActive(false);
        pronounsPanel.SetActive(false);
        myIdentitiesPanel.SetActive(false);
        aboutPanel.SetActive(false);

        switch (button)
        {
            case 0:
                mainPanel.SetActive(true);
                break;
            case 1://gender identities
                genderIdenPanel.SetActive(true);
                break;
            case 2://gender expression
                genderExpressPanel.SetActive(true);
                break;
            case 3://assigned sex
                assignedSexPanel.SetActive(true);
                break;
            case 4://sexual attraction
                sexualAttracPanel.SetActive(true);
                break;
            case 5://romantic attraction
                romanticAttracPanel.SetActive(true);
                break;
            case 6://more resources
                moreResources.SetActive(true);
                break;
            case 7://pronouns
                pronounsPanel.SetActive(true);
                break;
            case 8://my identities page
                myIdentitiesPanel.SetActive(true);
                break;
            case 9://about page
                aboutPanel.SetActive(true);
                break;
        }
    }

    public void AnimNaviPanel()
    {
        Animator anim = naviDrawerPanel.GetComponent<Animator>();
        bool isOpen = anim.GetBool("open");
        Debug.Log("open: " + isOpen);
        anim.SetBool("open", !isOpen);
    }

    public void OpenLink(string link)
    {
        Application.OpenURL(link);
    }

    public void QuitApp()
    {
        Application.Quit();
    }


}
