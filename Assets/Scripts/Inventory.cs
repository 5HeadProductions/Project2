using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coin_txt, gem_txt,rocket_txt, bullet_txt;
    [SerializeField]private int currentCoins, currentGems, primaryAmmo, secondaryAmmo, currentRockets;

    [SerializeField]private Button top_Sprite, bottom_Sprite;
    private Sprite temp;
    private FirePoint firePoint;
    private WeaponHolder weaponHolder;

    private bool rocketEquipped;

    private PlayerManager playerInstance;


    private bool isPrimary;
//    private  Dictionary<Sprite, int> currAmmo = new Dictionary<Sprite, int>();
    void Start(){
        playerInstance = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        firePoint = GameObject.Find("FirePoint").GetComponent<FirePoint>();
         weaponHolder = GameObject.Find("WeaponHolder").GetComponent<WeaponHolder>();
        currentCoins = playerInstance.coins;
        currentGems = playerInstance.gems;
        coin_txt.text = currentCoins.ToString();
        gem_txt.text = currentGems.ToString();
        ReloadPrimary();
        ReloadSecondary();


        currentRockets = firePoint.rocketAmmo;
        if(!rocketEquipped) { // not displaying the rockets until the buy it
            rocket_txt.text = "0";
        }
         else
        {
            rocket_txt.text = currentRockets.ToString();
        }
        bullet_txt.text = primaryAmmo.ToString();

    

    }

    // Update is called once per frame
    // updating the coins and gems to match how many the player actually has
    void Update()
    {
        if(currentCoins != playerInstance.coins){
            currentCoins = playerInstance.coins;
            coin_txt.text = currentCoins.ToString();
        }
        if(currentGems != playerInstance.gems){
            currentGems = playerInstance.gems;
            gem_txt.text = currentGems.ToString();
        }
        if(currentRockets != firePoint.rocketAmmo){
            currentRockets = firePoint.rocketAmmo;
            rocket_txt.text = currentRockets.ToString();
        }
    //    if(primaryAmmo != firePoint.bulletAmmo){
     //       if(firePoint.bulletAmmo >= 0){
     //       primaryAmmo = firePoint.bulletAmmo;
      //      bullet_txt.text = primaryAmmo.ToString();
      //      }
      //  }
        isPrimary = PrimaryOn();
        if(isPrimary){
            primaryAmmo = playerInstance.primaryAmmo;
            bullet_txt.text = primaryAmmo.ToString();
        }
        else
        {
            secondaryAmmo = playerInstance.secondaryAmmo;
            bullet_txt.text = secondaryAmmo.ToString();
        }
    }

    public void ReloadPrimary(){
        primaryAmmo = firePoint.bulletAmmo; // setting the max value of ammo
        playerInstance.primaryAmmo = primaryAmmo;// setting up how many bullets until the player runs out

    }

    public void ReloadSecondary(){
        secondaryAmmo = firePoint.bulletAmmo;
        playerInstance.secondaryAmmo = secondaryAmmo;
    }

    public bool PrimaryOn(){
        if(top_Sprite.image.sprite == weaponHolder.weaponSprites[0] || top_Sprite.image.sprite == weaponHolder.weaponSprites[4] || top_Sprite.image.sprite == weaponHolder.weaponSprites[8]){
            return true; // if the top sprite is a pistol then primary is currently being used.
            }
            else
            {
                return false;
            }
    }


    public Sprite ChangeWeapon(){ // bottom gun is the equipped gun
     // holderG = topGunImage.texture; // the player pressed on the top gun to equip it
     // topGunImage.texture = bottomGunImage.texture; // currently equiped gun goes to the top
    //  bottomGunImage.texture = holderG; // top gun goes to the bottom
    
    temp = top_Sprite.image.sprite;
    top_Sprite.image.sprite = bottom_Sprite.image.sprite;
    bottom_Sprite.image.sprite = temp;
    return bottom_Sprite.image.sprite;
    }

    // if a pistol is found on the top then that means we have a primary equipped so we need to change the sprite and spawn the gun

    public bool SetPrimaryWeaponUI(int index){// used when the player buys or upgrades a gun in the shop
        if(top_Sprite.image.sprite == weaponHolder.weaponSprites[0] || top_Sprite.image.sprite == weaponHolder.weaponSprites[4] || top_Sprite.image.sprite == weaponHolder.weaponSprites[8]){
            bottom_Sprite.image.sprite = weaponHolder.weaponSprites[index]; //equipping the primary weapon
            return true; // spawning the gun
            }
         else
            {  
                top_Sprite.image.sprite = weaponHolder.weaponSprites[index];
                return false;
            }
        
    }


// called when the user selects a pistol from the shop
// since we want the player to always have a pistol and not double pistol we need to determine if the player has the pistol equipped or in their invetory
// if the pistol is in their inventory we just change the sprite, else change the sprite and spawn the gun, hence
// bool bc we need to know if we need to spawn in the gun when the player resumes the game, or just change the sprite
    public bool SetPistolUI(int index){ 
    if(top_Sprite.image.sprite == weaponHolder.weaponSprites[0] || top_Sprite.image.sprite == weaponHolder.weaponSprites[4] || top_Sprite.image.sprite == weaponHolder.weaponSprites[8]){
        top_Sprite.image.sprite = weaponHolder.weaponSprites[index];
        return false;
        }
     else
        {  
            bottom_Sprite.image.sprite = weaponHolder.weaponSprites[index];
            return true;
        }

    }

    public IEnumerator NewFirePoint(){
        yield return new WaitForSeconds(.1f);
        firePoint = GameObject.Find("FirePoint").GetComponent<FirePoint>();
    }

}
