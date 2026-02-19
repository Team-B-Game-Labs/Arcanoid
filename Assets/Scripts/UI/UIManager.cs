using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] TMP_Text score;
    [SerializeField] Image energyFillAmounth;
    int currentScore;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject tutorial1;
    [SerializeField] GameObject tutorial2;
    [SerializeField] GameObject tutorial3;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }
    private void Start()
    {
        //score.text = currentScore.ToString();
        
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
        if (tutorial1 != null)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                tutorial2.gameObject.SetActive(true);
                Destroy(tutorial1);


            }
            
        }
        if (tutorial2 != null)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                tutorial3.gameObject.SetActive(true);
                Destroy (tutorial2);
            }
            return ;
        }
        if (tutorial3 != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
               Destroy(tutorial3);
            }
            return;
        }

    }
    public void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
        GameManager.instance.status = GameStatus.GamePaused;
    }

    public void ClosePauseMenu()
    {
        if (pauseMenu == true)
            pauseMenu.SetActive(false);
        GameManager.instance.status = GameStatus.GameRunning;
    }
}
