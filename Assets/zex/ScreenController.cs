using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScreenController : MonoBehaviour
{
    public Canvas canvas;
    [Header("Player_Info")]
    public TMP_Text labelName_Text;
    [Header("Health")]
    public Slider healthPoints_Slider;
    public TMP_Text healthPoints_Text;
    [Header("Mana")]
    public Slider manaPoints_Slider;
    public TMP_Text manaPoints_Text;
    [Header("Armor/Hunger")]
    public Slider armorPercent_Slider;
    public TMP_Text ArmorPercent_Text;

    public Slider hungerPoints_Slider;
     public TMP_Text hungerPoints_Text;

    private void Start() {
        //UpdateScreen();
    }

    public void BtnCounter(){
        EntitiesManager.Instance.value++;
        EntitiesManager.Instance.player.LabelName = "Joes";
        UpdateScreen();
       
    }

    public void UpdateScreen(){
        labelName_Text.text = EntitiesManager.Instance.player.LabelName;

        healthPoints_Text.text = EntitiesManager.Instance.player.HealthPoints+"/"+EntitiesManager.Instance.player.MaxHealth;
        healthPoints_Slider.maxValue = EntitiesManager.Instance.player.MaxHealth;
        healthPoints_Slider.value = EntitiesManager.Instance.player.HealthPoints;
        healthPoints_Slider.minValue = 0;

        manaPoints_Text.text = EntitiesManager.Instance.player.ManaPoints+"/"+EntitiesManager.Instance.player.MaxMana;
        manaPoints_Slider.maxValue = EntitiesManager.Instance.player.MaxMana;
        manaPoints_Slider.value = EntitiesManager.Instance.player.ManaPoints;
        manaPoints_Slider.minValue = 0;

        hungerPoints_Text.text = EntitiesManager.Instance.player.HungerPoints+"/"+EntitiesManager.Instance.player.MaxHunger;
        hungerPoints_Slider.maxValue = EntitiesManager.Instance.player.MaxHunger;
        hungerPoints_Slider.value = EntitiesManager.Instance.player.HungerPoints;
        hungerPoints_Slider.minValue = 0;

        /* mn.maxValue = EntitiesManager.Instance.player.MaxMana;
        mn.value = EntitiesManager.Instance.player.ManaPoints;
        mn.minValue = 0; */
    }

}
