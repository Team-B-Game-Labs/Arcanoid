using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text score;
    [SerializeField] Image energyFillAmounth;
    int currentScore;

    [SerializeField] GameObject tutorial1;
    [SerializeField] GameObject tutorial2;
    [SerializeField] GameObject tutorial3;
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


    private void Update()
    {
        Tutorial();
    }

    private void SetCollectableUI(int dropNumber)
    {
        
    }


    public void SetScore(int scoreValue)
    {
        if (score == null) return;

        currentScore =+ scoreValue;
        score.text = currentScore.ToString();
    }

    public void FillEnergy()
    {
        if(energyFillAmounth == null) return;
        
        energyFillAmounth.fillAmount = GameManager.instance.currentEnergy / GameManager.instance.maxEnergy;
        if(energyFillAmounth.fillAmount <= 0.8f)
        {
            energyFillAmounth.color = Color.green;
        }
        else
            energyFillAmounth.color = Color.blue;


    }

    public void Tutorial()
    {
        if (tutorial1 == true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                tutorial2.gameObject.SetActive(true);
                tutorial1.gameObject.SetActive(false);


            }
            return;
        }
        if (tutorial2 == true)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                tutorial3.gameObject.SetActive(true);
                tutorial2.gameObject.SetActive(false);
            }
            return ;
        }
        if (tutorial3 == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                tutorial3.gameObject.SetActive(false);
            }
            return;
        }
    }
}
