using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_DamageReceiver : MonoBehaviour, IEntity
{
    //This script will keep track of player HP
    public float playerHP = 100;
    public SC_FPSController playerController;
    public SC_WeaponManager weaponManager;
    public GameObject SplatterSprite;
    public GameObject DeadSprite;
    public GameObject CrosshairToggle;
    public float timeRemaining = 3;
    void Start()
    {
       SplatterSprite.SetActive(false); 
       DeadSprite.SetActive(false); 
    }
    public void ApplyDamage(float points)
    {
        playerHP -= points;
        SplatterSprite.SetActive(true);
        if(playerHP <= 0)
        {
            //Player is dead
            playerController.canMove = false;
            playerHP = 0;
            LoadNextScene();
            //DeadSprite.SetActive(true);
            CrosshairToggle.SetActive(false);
        }
        timeRemaining = 2;
    }
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        if (timeRemaining < 1) {
           SplatterSprite.SetActive(false); 
        }
    }
    public void LoadNextScene()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Arch");
    }

}