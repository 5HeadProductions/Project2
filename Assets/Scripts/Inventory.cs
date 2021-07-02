using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//inventory is used in the HUDUI canvas
//this script is in charge of the gameplay UI
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
    private bool isRocket;

   public void Awake(){
        playerInstance = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        playerInstance.player = GameObject.Find("Player");
        weaponHolder = GameObject.Find("WeaponHolder").GetComponent<WeaponHolder>();

        playerInstance.primaryWeapon = weaponHolder.Weapons[playerInstance.primaryIndex];
        var weaponClone = Instantiate(playerInstance.primaryWeapon,playerInstance.primaryWeapon.transform.position, playerInstance.primaryWeapon.transform.rotation);

        weaponClone.transform.parent = playerInstance.player.transform;
       
       weaponClone.transform.position = new Vector3(0.239999995f, 1.98479891f, 0.685321569f);

       weaponClone.GetComponentInChildren<FirePoint>().enabled = true;
        UpdateWeaponOnLoad(playerInstance.primaryIndex, playerInstance.secondaryIndex);
        
    }

    void Start(){
        
        firePoint = GameObject.Find("FirePoint").GetComponent<FirePoint>();
        
        currentCoins = playerInstance.coins;
        currentGems = playerInstance.gems;
        coin_txt.text = currentCoins.ToString();
        gem_txt.text = currentGems.ToString();
        ReloadPrimary();
        ReloadSecondary();
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
        // if the primary weapon is on then we want to use the primary ammo amount else use the pistol
        isPrimary = PrimaryOn();
        if(isPrimary){
            isRocket = RocketOn();
            if(isRocket){
                currentRockets = playerInstance.rocketAmmo;
                rocket_txt.text = currentRockets.ToString();
            }
            else
            {
            primaryAmmo = playerInstance.primaryAmmo;
            bullet_txt.text = primaryAmmo.ToString();   
            }
        }
        else
        {
            secondaryAmmo = playerInstance.secondaryAmmo;
            bullet_txt.text = secondaryAmmo.ToString();
        }
    }

// each gun has a default ammo value this value is used as the "max" value of ammo the player will get when they buy the gun
// once they buy the gun the ammo is then assigned to the player instnace so it can be displayed in HUDUI and in the shop
    public void ReloadPrimary(){
       
        primaryAmmo = firePoint.bulletAmmo; // setting the max value of ammo
        playerInstance.primaryAmmo = primaryAmmo;// setting up how many bullets until the player runs out

    }

//finds the fire point of the new secondary weapon and updates the ammo
    public void ReloadSecondary(){
        
        secondaryAmmo = firePoint.bulletAmmo;
        playerInstance.secondaryAmmo = secondaryAmmo;
    }

    public void ReloadRockets(){
       
        firePoint.rocketAmmo = 40;
        currentRockets = firePoint.rocketAmmo;
        playerInstance.rocketAmmo = currentRockets;
    }

// determines if the primary weapon is currently used or not
    public bool PrimaryOn(){
        if(top_Sprite.image.sprite == weaponHolder.weaponSprites[0] || top_Sprite.image.sprite == weaponHolder.weaponSprites[4] || top_Sprite.image.sprite == weaponHolder.weaponSprites[8]){
            return true; // if the top sprite is a pistol then primary is currently being used.
            }
            else
            {
                return false;
            }
    }
    public bool RocketOn(){
        if(bottom_Sprite.image.sprite == weaponHolder.weaponSprites[3] || bottom_Sprite.image.sprite == weaponHolder.weaponSprites[7] || bottom_Sprite.image.sprite == weaponHolder.weaponSprites[11]){
            return true;
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
    //  returns the sprite image
    
    temp = top_Sprite.image.sprite;
    top_Sprite.image.sprite = bottom_Sprite.image.sprite;
    bottom_Sprite.image.sprite = temp;
    return bottom_Sprite.image.sprite;
    }

    public void UpdateWeaponOnLoad(int primary, int secondary){
        bottom_Sprite.image.sprite = weaponHolder.weaponSprites[primary];
        top_Sprite.image.sprite = weaponHolder.weaponSprites[secondary];

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
