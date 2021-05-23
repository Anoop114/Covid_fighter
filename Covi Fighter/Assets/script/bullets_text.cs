using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class bullets_text : MonoBehaviour
{
    public TMP_Text bullet_count;
    public Slider helth;
    private int bullet;

    void Update()
    {
        helth.value = player_movment.p_health;
        bullet = player_bullet.bullet;
        bullet_count.text = "Bullets = " + bullet.ToString();
    }
}
