using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity{
    [Header("Info")]
    [SerializeField]private string labelName;
    [Header("Health")]
    [SerializeField]private int maxHealth;
    [SerializeField]private int healthPoints;
    [Header("Mana")]
    [SerializeField]private int maxMana;
    [SerializeField]private int manaPoints;

    public Entity(string name, int maxHealth, int maxMana){
        this.labelName = name;
        this.maxHealth = maxHealth;
        this.healthPoints = maxHealth;
        this.maxMana = maxMana;
        this.manaPoints = maxMana;
        
    }

    public void TakeDamage(int damageAmount){
        if ((healthPoints - damageAmount <= 0))
            healthPoints = 0;
        else
            healthPoints -= damageAmount;
    }

    public string LabelName{get{return labelName;}set{labelName = value.ToString();}}
    public int MaxHealth{get{return maxHealth;} set{maxHealth = value;}}
    public int HealthPoints{get{return healthPoints;} set{healthPoints = value;}}
    public int MaxMana{get{return maxMana;} set{maxMana = value;}}
    public int ManaPoints{get{return manaPoints;} set{manaPoints = value;}}
}
[System.Serializable]
public class Player : Entity{
    [Header("Hunger")]
    [SerializeField]private int maxHunger;
    [SerializeField]private int hungerPoints;

    public Player(string name, int maxHealth, int maxMana, int maxHunger):base(name,maxHealth,maxMana){
        this.maxHunger = maxHunger;
        this.hungerPoints = maxHunger;
    }
    

    public int MaxHunger{get{return maxHunger;} set{maxHunger = value;}}
    public int HungerPoints{get{return hungerPoints;} set{hungerPoints = value;}}
}
public class Enemy : Entity{
    public Enemy(string name, int maxHealth, int maxMana):base(name,maxHealth,maxMana){
        
    }
}

public class EntitiesManager : MonoBehaviour
{
   public static EntitiesManager Instance {get; private set;}
    
    public int value;
    public Player player = new Player("John",20,20,50);
    public Enemy enemie = new Enemy("Enemy",20,20); 
    public GameObject[] enemyPrefabs;

    void Awake(){
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    private void Start() {
        PrintDebugValues();
    }

    [UnityEditor.MenuItem("DebugTools/Player/DebugValues")]
    public static void PrintDebugValues(){
        Debug.Log("Player: "+EntitiesManager.Instance.player.LabelName+
            " | Health: "+EntitiesManager.Instance.player.HealthPoints+"/"+EntitiesManager.Instance.player.MaxHealth+
            " | Mana"+EntitiesManager.Instance.player.ManaPoints+"/"+EntitiesManager.Instance.player.MaxMana+
            " | Hunger"+EntitiesManager.Instance.player.HungerPoints+"/"+EntitiesManager.Instance.player.MaxHunger);    
    }

    [UnityEditor.MenuItem("DebugTools/Player/TakeDamage(6)")]
    public static void TakeDamage(){
        EntitiesManager.Instance.player.TakeDamage(6);
    }
}
