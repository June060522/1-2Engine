using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
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
        Modpanel.transform.DOScale(new Vector3(0,0,0),0);
        Modpanel.transform.DOScale(new Vector3(1f,1f,1f),0.5f).SetEase(Ease.OutBack);
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
        Settingpanel.transform.DOScale(new Vector3(0,0,0),0);
        Settingpanel.transform.DOScale(new Vector3(1f,1f,1f),0.5f).SetEase(Ease.OutBack);
    }

    public void NameSetting()
    {
        NameSettingPanel.SetActive(true);
        NameSettingPanel.transform.DOScale(new Vector3(1,1,1),0);
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

    //��� ���۹� ����
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
        HowtoDefencePanel.transform.DOScale(new Vector3(0,0,0),0);
        HowtoDefencePanel.transform.DOScale(new Vector3(1f,1f,1f),0.5f).SetEase(Ease.OutBack);
        HowtoDefencePanel.SetActive(true);
    }

    public void HowtoPlayCollaboration()
    {
        HowtoPlayCollaborationPanel.transform.DOScale(new Vector3(0,0,0),0);
        HowtoPlayCollaborationPanel.transform.DOScale(new Vector3(1f,1f,1f),0.5f).SetEase(Ease.OutBack);
        HowtoPlayCollaborationPanel.SetActive(true);
    }

    public void Xbutton()
    {
        if(Modpanel.activeSelf == true)
        {
            Modpanel.transform.DOScale(new Vector3(0f,0f,0f),0.5f).SetEase(Ease.InBack)
            .OnComplete(() => Modpanel.SetActive(false));
        }
        if(Settingpanel.activeSelf == true)
        {
            Settingpanel.transform.DOScale(new Vector3(0f,0f,0f),0.5f).SetEase(Ease.InBack)
            .OnComplete(() => Settingpanel.SetActive(false));
        }
        if(Soundpanel.activeSelf == true)
        {
            Soundpanel.transform.DOScale(new Vector3(0f,0f,0f),0.5f).SetEase(Ease.InBack)
            .OnComplete(() => Soundpanel.SetActive(false));
        }
        if(NameSettingPanel.activeSelf == true)
        {
            NameSettingPanel.transform.DOScale(new Vector3(0f,0f,0f),0.5f).SetEase(Ease.InBack)
            .OnComplete(() => NameSettingPanel.SetActive(false));
        }
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
        Soundpanel.transform.DOScale(new Vector3(1f,1f,1f),0);
        Settingpanel.SetActive(false);
    }

    //��� ����
    public void BasicpanelExplanation() 
    {
        HowtoPlayCollaborationPanel.transform.DOScale(new Vector3(0,0,0),0);
        HowtoPlayCollaborationPanel.transform.DOScale(new Vector3(1f,1f,1f),0.5f).SetEase(Ease.OutBack);
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
