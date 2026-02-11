using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text score;
    [SerializeField] Image Slot1;
    [SerializeField] Image slot2;
    [SerializeField] Image slot3;
    [SerializeField] Image slot4;
    [SerializeField] Image slot5;
    int currentScore;

    private void Start()
    {
        score.text = currentScore.ToString();
        
    }
    private void OnEnable()
    {
        Brick.OnSetScorePoint += SetScore;
        Drops.OnCollect += SetSlots;
    }


    private void OnDisable()
    {
        Brick.OnSetScorePoint -= SetScore;
        Drops.OnCollect -= SetSlots;
    }

    private void SetSlots(int dropNumber)
    {
        switch(dropNumber)
        {
            case 0:
                //Barra dell'energia che aumenta...
                break;
                case 1:
                break;


        }
    }
    public void SetScore(int scoreValue)
    {
        currentScore =+ scoreValue;
        score.text = currentScore.ToString();
    }
}
