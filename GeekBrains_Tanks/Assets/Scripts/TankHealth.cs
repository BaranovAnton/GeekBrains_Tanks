using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TankHealth : MonoBehaviour {

    public Text healthText;
    private int health = 100;

    void Start () {

	}

    public void AddHealth(int _health)
    {
        health += _health;
        health = Mathf.Clamp(health, 0, 100);
        SetHealthText();
    }

    public void GetHit(int _damage)
    {
        health -= _damage;
        if (health <= 0)
            print("You are looser!");
        SetHealthText();
    }

    private void SetHealthText()
    {
        healthText.text = health.ToString();
    }
}
