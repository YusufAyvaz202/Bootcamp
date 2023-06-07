using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manaBar : MonoBehaviour
{

    public static manaBar instance;

    public Image _manaBar;

    float mana, maxMana = 100f;
    float lerpSpeed;

    
    private float increaseAmount = 5f;
    private float timer = 0f;
    private float interval = 1f;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        mana = maxMana;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) 
        {
            DecraseMana(20f);
        }             
        
        if (mana > maxMana)
            mana = maxMana;

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller();
        ColorChanger();
        AddMana();    
    }

    public void DecraseMana(float spendingMana)
    {
        mana -= spendingMana;

        if (mana < 0)
            mana = 0;

        HealthBarFiller();
        ColorChanger();
    }

    public void RefreshMana(float collectedMana)
    {
        mana += collectedMana;
        if (mana > 100)
            mana = 100;

        HealthBarFiller();
        ColorChanger();
    }

    public void AddMana()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {
            mana += increaseAmount;
            timer -= interval;
        }
        
        if (mana > 100)
            mana = 100;

        HealthBarFiller();
        ColorChanger();
    }
    public void HealthBarFiller()
    {
        _manaBar.fillAmount = Mathf.Lerp(_manaBar.fillAmount, mana / maxMana, lerpSpeed);
    }

    public void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.white, Color.blue, (mana / maxMana));

        _manaBar.color = healthColor;
    }

}



