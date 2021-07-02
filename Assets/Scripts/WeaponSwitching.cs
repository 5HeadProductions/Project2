using UnityEngine;

// GameObject in the dungeon used to switch between weapons
public class WeaponSwitching : MonoBehaviour
{
    private Inventory inventory; // used to change the weapon sprite on the button
   [SerializeField] private ButtonManager buttonManager;// used to spawn the gun
    private WeaponHolder weaponHolder; // used to find what gun to equip

    private PlayerManager playerInstance;
    // Start is called before the first frame update
    void Start()
    {
      inventory = GameObject.Find("inventory").GetComponent<Inventory>(); 
      weaponHolder = GameObject.Find("WeaponHolder").GetComponent<WeaponHolder>();
      playerInstance = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){ // player presses the number "1"
            var equippedGunSprite = inventory.ChangeWeapon(); // assigning the equipped weapon to equippedGunSprite
            for(int i = 0; i < weaponHolder.weaponSprites.Length; i++){ // using equippedGunSprite to find the index of which gun needs to be instantiated
                if(weaponHolder.weaponSprites[i] == equippedGunSprite){
                    int temp = playerInstance.primaryIndex;
                    buttonManager.Equip(i); // spawning the gun once it is found
                    playerInstance.secondaryIndex = temp;
                    break;
                }
            }
        }
    }
}
