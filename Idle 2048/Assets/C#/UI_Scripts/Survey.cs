using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.ComponentModel;
using UnityEngine.UI;

public class Survey : MonoBehaviour
{
    public GameObject window;


    [SerializeField] private string SMTPClient;
    [SerializeField] private string SMTPPort;
    [SerializeField] private string UserName;
    [SerializeField] private string UserPass;
    [SerializeField] private string To;
    [SerializeField] private string Subject;
    [SerializeField] private string AttatchFile;
    public InputField body;
    public GameObject prefab;

    public Transform startPoint;
    public Transform endPoint;

    public Transform parent;
    private Vector3 startScale;

    public void sendEmail()
    {
        SimpleEmailSender.emailSettings.SMTPClient = SMTPClient;
        SimpleEmailSender.emailSettings.SMTPPort = Int32.Parse(SMTPPort);
        SimpleEmailSender.emailSettings.UserName = UserName;
        SimpleEmailSender.emailSettings.UserPass = UserPass;

        SimpleEmailSender.Send(To, Subject, body.text, AttatchFile, SendCompleteCallBack);
    }

    private void SendCompleteCallBack(object sender, AsyncCompletedEventArgs e)
    {
        var banner = Instantiate(prefab, startPoint.position, Quaternion.identity,parent);
        var script = banner.GetComponent<PopUp>();

        script.startPoint = startPoint;
        script.endPoint = endPoint;

        if (e.Cancelled || e.Error != null)
        {
            Debug.Log("Email Not Sent: " + e.Error.ToString());
            script.Init("Failed", false);
        }
        else
        {
            Debug.Log("Email Sent");
            script.Init("Success", true);
        }
    }


    public void openBugReport()
    {
        window.SetActive(true);
        LeanTween.scale(window, startScale, 0.2f);
    }

    public void deactivate()
    {

        window.SetActive(false);
    }

    public void closeBugReport()
    {
        LeanTween.scale(window, Vector2.zero, 0.2f).setOnComplete(deactivate);
    }

    void Start()
    {
        startScale = new Vector3(1f, 1f, 1f);
        window.GetComponent<Transform>().localScale = Vector3.zero;
    }
}


