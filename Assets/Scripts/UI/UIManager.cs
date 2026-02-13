using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text score;
    [SerializeField] Image energyFillAmounth;
    int currentScore;

    private void Start()
    {
        score.text = currentScore.ToString();
        
    }
    private void OnEnable()
    {
        Brick.OnSetScorePoint += SetScore;
        Drops.OnCollect += SetCollectableUI;
        EnergyBall.OnTakeEnergyBall += FillEnergy;
        Bullet.onBulletHit += FillEnergy;
    }


    private void OnDisable()
    {
        Brick.OnSetScorePoint -= SetScore;
        Drops.OnCollect -= SetCollectableUI;
        EnergyBall.OnTakeEnergyBall -= FillEnergy;
        Bullet.onBulletHit -= FillEnergy;
    }

    private void SetCollectableUI(int dropNumber)
    {
        
    }


    public void SetScore(int scoreValue)
    {
        currentScore =+ scoreValue;
        score.text = currentScore.ToString();
    }

    public void FillEnergy()
    {
        energyFillAmounth.fillAmount = GameManager.instance.currentEnergy / GameManager.instance.maxEnergy;
        if(energyFillAmounth.fillAmount <= 0.8f)
        {
            energyFillAmounth.color = Color.green;
        }
        else
            energyFillAmounth.color = Color.blue;

    }
}
