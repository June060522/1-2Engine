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
    public GameObject Soundpanel;
    public GameObject BasicPanel;
    public GameObject ExPlain;
    public GameObject CollaborationPanel;
    public GameObject NameSettingPanel;
    public GameObject DifficultyPanel;
    public GameObject BirdCollaborationPanel;
    public GameObject BirdBasicPanel;
    public GameObject BasicRulePanel;
    public AudioClip clickClip;

    public void ModChoose()
    {
        EffectAudio.Instance.ListenEff(clickClip);
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
        EffectAudio.Instance.ListenEff(clickClip);
        Settingpanel.SetActive(true);
        Settingpanel.transform.DOScale(new Vector3(0,0,0),0);
        Settingpanel.transform.DOScale(new Vector3(1f,1f,1f),0.5f).SetEase(Ease.OutBack);
    }

    public void NameSetting()
    {
        EffectAudio.Instance.ListenEff(clickClip);
        NameSettingPanel.SetActive(true);
        NameSettingPanel.transform.DOScale(new Vector3(1,1,1),0);
        Settingpanel.SetActive(false);
    }

    public void OK()
    {
        EffectAudio.Instance.ListenEff(clickClip);
        NameSettingPanel.SetActive(false);
        Settingpanel.SetActive(true);
    }

    public void basicExplanation()
    {
        EffectAudio.Instance.ListenEff(clickClip);
        HowtoPlayBasicpanel.SetActive(true);
        BasicPanel.SetActive(false);
    }

    public void CollaborationExplanation()
    {
        EffectAudio.Instance.ListenEff(clickClip);
        HowtoPlayCollaborationPanel.SetActive(true);
        CollaborationPanel.SetActive(false);
    }

    //��� ���۹� ����
    public void HTPBasic() 
    {
        EffectAudio.Instance.ListenEff(clickClip);
        HowtoPlayBasicpanel.SetActive(false);
        BasicPanel.SetActive(true);
    }

    public void HTPCollaboration()
    {
        EffectAudio.Instance.ListenEff(clickClip);
        HowtoPlayCollaborationPanel.SetActive(false);
        CollaborationPanel.SetActive(true);
    }

    public void BirdbasicPanel()
    {
        EffectAudio.Instance.ListenEff(clickClip);
        BirdBasicPanel.SetActive(true);
        BasicPanel.SetActive(false);
        //Modpanel.SetActive(false);
        HowtoPlayBasicpanel.SetActive(false);
    }

    public void BackBirdbasicPanel()
    {
        EffectAudio.Instance.ListenEff(clickClip);
        BirdBasicPanel.SetActive(false);
        BasicPanel.SetActive(false);
        HowtoPlayBasicpanel.SetActive(true);
    }

    public void BirdcollaborationPanel()
    {
        EffectAudio.Instance.ListenEff(clickClip);
        BirdCollaborationPanel.SetActive(true);
        CollaborationPanel.SetActive (false);
        HowtoPlayCollaborationPanel.SetActive(false);
    }

    public void BackBirdcollaborationPanel()
    {
        EffectAudio.Instance.ListenEff(clickClip);
        BirdCollaborationPanel.SetActive(false);
        CollaborationPanel.SetActive(false);
        HowtoPlayCollaborationPanel.SetActive(true);
    }

    public void collaborationMod()
    {
        EffectAudio.Instance.ListenEff(clickClip);
        DifficultyPanel.SetActive(true);
    }

    public void BasicRulepanel()
    {
        EffectAudio.Instance.ListenEff(clickClip);
        BasicRulePanel.SetActive(true);
        BasicPanel.SetActive(false);
    }

    public void BackBasicRulePanel()
    {
        EffectAudio.Instance.ListenEff(clickClip);
        BasicRulePanel.SetActive(false);
        BasicPanel.SetActive(true);
    }
/*    public void HowtoPlayDefence()
    {
        HowtoDefencePanel.transform.DOScale(new Vector3(0,0,0),0);
        HowtoDefencePanel.transform.DOScale(new Vector3(1f,1f,1f),0.5f).SetEase(Ease.OutBack);
        HowtoDefencePanel.SetActive(true);
    }
*/
    public void HowtoPlayCollaboration()
    {
        EffectAudio.Instance.ListenEff(clickClip);
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
        //DefencePanel.SetActive(false);
        CollaborationPanel.SetActive(false);
        DifficultyPanel.SetActive(false);
        BirdBasicPanel.SetActive(false);
        BirdCollaborationPanel.SetActive(false);
        HowtoPlayBasicpanel.SetActive(false);
        HowtoPlayCollaborationPanel.SetActive(false);
        BasicRulePanel.SetActive(false);
    }

    public void SounSetting()
    {
        EffectAudio.Instance.ListenEff(clickClip);
        Soundpanel.SetActive(true);
        Soundpanel.transform.DOScale(new Vector3(1f,1f,1f),0);
        Settingpanel.SetActive(false);
    }

    //��� ����
    public void BasicpanelExplanation() 
    {
        EffectAudio.Instance.ListenEff(clickClip);
        HowtoPlayCollaborationPanel.transform.DOScale(new Vector3(0,0,0),0);
        HowtoPlayCollaborationPanel.transform.DOScale(new Vector3(1f,1f,1f),0.5f).SetEase(Ease.OutBack);
        BasicPanel.SetActive(true);
    }

   /* public void DefencepanelExplanation()
    {
        DefencePanel.SetActive(true);
    }*/

    public void CollaborationpanelExplanation()
    {
        EffectAudio.Instance.ListenEff(clickClip);
        CollaborationPanel.SetActive(true);
        //ExPlain.SetActive(true);
    }

}
