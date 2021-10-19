using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField]
    private int health = 10;
    [SerializeField]
    private int maxHealth = 10;

    public int Health 
    { 
        get => health;
        set
        {
            health = value;
            EventManager.PlayerHealthChanged();
        }
    }
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }

    private void OnEnable()
    {
        EventManager.onPlayerHurt += TakeDamage;
        EventManager.onPlayerHeal += Heal;
        EventManager.onGameReset += EventManager_onGameReset;
    }

    private void EventManager_onGameReset()
    {
        EventManager.PlayerHeal(10);
        //PlayerPrefs.SetInt("PlayerHealth", health);
        Debug.Log("Player Reset Setting Health back to 10.");
    }

    private void OnDisable()
    {
        EventManager.onPlayerHurt -= TakeDamage;
        EventManager.onPlayerHeal -= Heal;
        EventManager.onGameReset -= EventManager_onGameReset;
    }

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        //if (PlayerPrefs.HasKey("PlayerHealth"))
        //{
        //    health = PlayerPrefs.GetInt("PlayerHealth", health);
        //}
        //else
        //{
        //    PlayerPrefs.SetInt("PlayerHealth", health);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        if (health - amount <= 0)
        {
            health = 0;
            EventManager.LevelFail(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            health -= amount;
        }
        //PlayerPrefs.SetInt("PlayerHealth", health);
    }

    public void Heal(int amount)
    {
        if(health + amount >= maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += amount;
        }
        //PlayerPrefs.SetInt("PlayerHealth", health);
    }
}
