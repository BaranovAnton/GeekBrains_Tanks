using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tank : MonoBehaviour {

    public Text healthText, armorText;
    public RectTransform healthBar, armorBar;
    private float health, armor;

    void Start()
    {
        health = 100;
        armor = 0;
    }

    public void AddHealth(float _health)
    {
        ChangeHealth(_health);
    }

    public void AddArmor(float _armor)
    {
        ChangeArmor(_armor);
    }

    public void GetHit(float _damage)
    {
        if (armor > 0)
        {
            ChangeArmor(-_damage);
        } else
        {
            ChangeHealth(-_damage);
        }
    }

    private void ChangeHealth(float _health)
    {
        health += _health;
        health = Mathf.Clamp(health, 0, 100);
        healthText.text = health.ToString();

        healthBar.localScale = new Vector3(Mathf.Clamp(healthBar.localScale.x + (_health / 100), 0, 1), healthBar.localScale.y, healthBar.localScale.z);

        if (health <= 0)
            GameOver();
    }

    private void ChangeArmor(float _armor)
    {
        armor += _armor;
        if (armor < 0)
            ChangeHealth(-armor);
        armor = Mathf.Clamp(armor, 0, 100);
        armorText.text = armor.ToString();

        armorBar.localScale = new Vector3(Mathf.Clamp(armorBar.localScale.x + (_armor / 100), 0, 1), armorBar.localScale.y, armorBar.localScale.z);
    }

    private void GameOver()
    {
        print("You are looser!");
    }
}
