using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayButton : MonoBehaviour
{
    public GameObject Modpanel;
    public GameObject Settingpanel;
    public GameObject HowtoPlayBasicpanel;
    public GameObject HowtoPlayCollaborationPanel;
    public GameObject HowtoDefencePanel;
    public GameObject Soundpanel;
    public GameObject BasicPanel;
    public GameObject DefencePanel;
    public GameObject CollaborationPanel;
    public GameObject NameSettingPanel;

    public void ModChoose()
    {
        Modpanel.SetActive(true);
    }
    
    public void NextScene()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Setting()
    {
        Settingpanel.SetActive(true);
    }

    public void NameSetting()
    {
        NameSettingPanel.SetActive(true);
        Settingpanel.SetActive(false);
    }

    public void OK()
    {
        NameSettingPanel.SetActive(false);
        Settingpanel.SetActive(true);
    }

    public void basicExplanation()
    {
        HowtoPlayBasicpanel.SetActive(true);
        BasicPanel.SetActive(false);
    }

    public void CollaborationExplanation()
    {
        HowtoPlayCollaborationPanel.SetActive(true);
        CollaborationPanel.SetActive(false);
    }

    //모드 조작법 설명
    public void HTPBasic() 
    {
        HowtoPlayBasicpanel.SetActive(false);
        BasicPanel.SetActive(true);
    }

    public void HTPCollaboration()
    {
        HowtoPlayCollaborationPanel.SetActive(false);
        CollaborationPanel.SetActive(true);
    }

    public void HTPDefence()
    {
        HowtoDefencePanel.SetActive(false);
        DefencePanel.SetActive(true);
    }

    public void HowtoPlayDefence()
    {
        HowtoDefencePanel.SetActive(true);
    }

    public void HowtoPlayCollaboration()
    {
        HowtoPlayCollaborationPanel.SetActive(true);
    }

    public void Xbutton()
    {
        Modpanel.SetActive(false);
        Settingpanel.SetActive(false);
        Soundpanel.SetActive(false);
        NameSettingPanel.SetActive(false);
    }

    public void SmallXButton()
    {
        BasicPanel.SetActive(false);
        DefencePanel.SetActive(false);
        CollaborationPanel.SetActive(false);
    }

    public void SounSetting()
    {
        Soundpanel.SetActive(true);
        Settingpanel.SetActive(false);
    }

    //모드 설명
    public void BasicpanelExplanation() 
    {
        BasicPanel.SetActive(true);
    }

    public void DefencepanelExplanation()
    {
        DefencePanel.SetActive(true);
    }

    public void CollaborationpanelExplanation()
    {
        CollaborationPanel.SetActive(true);
    }

}
