using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(PlayerInputs))]
[RequireComponent(typeof(CharacterController2D))]
[RequireComponent(typeof(Weapon))]
public class PlayerBehavior : MonoBehaviour
{
    private CharacterController2D _CC2D;
    private PlayerInputs _PI;
    private Weapon _Weapon;
    private bool _IsFacingRight = true;
    public string AudioOnDie;

    public bool onPause = false;

    public void OnDamage(Damager D, Damageable DA)
    {
        //ParticleSystem PS = GetComponentInChildren<ParticleSystem>();
        //PS.Play();
    }

    public void KnockBack( float KnockBackPower, Vector2 KnockBackDirection )
    {
        var _RB = GetComponent<Rigidbody2D>();
        _RB.velocity = KnockBackDirection * KnockBackPower;
    }

    // Awake is called as Init
    private void Awake()
    {
        _PI = GetComponent<PlayerInputs>();
        _CC2D = GetComponent<CharacterController2D>();
        _Weapon = GetComponentInChildren<Weapon>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!onPause)
        {
            _CC2D.MoveHorizontal(Input.GetAxis(PlayerInputs._Key_horizontal));
            _CC2D.MoveVertical(Input.GetAxis(PlayerInputs._Key_vertical));

            if (Input.GetButtonDown(PlayerInputs._Key_A))
            {
                _Weapon.OnFire();
            }
        }
    }

    //-------------------------------------------------------------
    //  KILL
    //-------------------------------------------------------------
    public void kill(Damager iDamager, Damageable iDamageable)
    {
        print("DEAD DEAD DEAD");

        // UPDATE MONEY
        FameStacker fstacker = gameObject.GetComponent<FameStacker>();
        int gainedMoney = (!!fstacker) ?
            fstacker.convertFameToMoney() :
            0;

        int bank = PlayerPrefs.GetInt(Constants.bank_account, 0);
        PlayerPrefs.SetInt(Constants.bank_account, bank + gainedMoney);

        // UPDATE DEATH COUNT
        int deathcount = PlayerPrefs.GetInt(Constants.death_count, 0);
        PlayerPrefs.SetInt(Constants.death_count, deathcount+1);

        // DEBUG TRACES
        if (Constants.DEBUG_ENABLED)
        {
            string message = "GAINED MONEY : " + gainedMoney;
            print(message);
            bank = PlayerPrefs.GetInt(Constants.bank_account, 0);
            message = " # BANK : " + bank ;
            print(message);
        }

        var AM = GameObject.Find("Audio Manager");
        var AM_c = AM.GetComponent<AudioManager>();
        AM_c.Play("PlayerOnDie");

        // LOAD HUB
        SceneManager.LoadScene(Constants.hub_scene_name, LoadSceneMode.Single);
    }

    //-------------------------------------------------------------
    //  RESET
    //-------------------------------------------------------------
    public void resetStats()
    {
        // RESET UNLOCKABLE SAVE
        foreach (string item in Constants.items)
        { lockItem(item); }
    }
    //-------------------------------------------------------------
    //  getBankAccount
    //-------------------------------------------------------------
    public int getBankAccount()
    {
        int bank = PlayerPrefs.GetInt(Constants.bank_account, 0);
        return bank;
    }

    public void spendMoney(int iMoney)
    {
        int bank = PlayerPrefs.GetInt(Constants.bank_account, 0);
        int new_bank = bank - iMoney;
        PlayerPrefs.SetInt(Constants.bank_account, new_bank);
    }

    public int getDeathCount()
    {
        int deathcount = PlayerPrefs.GetInt(Constants.death_count, 0);
        return deathcount;
    }

    public void unlock(string iItemName)
    {
        PlayerPrefs.SetInt(Constants.unlocked_items[iItemName], 1);
    }
    public void lockItem(string iItemName)
    {
        PlayerPrefs.SetInt(Constants.unlocked_items[iItemName], 0);
    }

    public bool hasUnlock(string iItemName)
    {
        return PlayerPrefs.GetInt(Constants.unlocked_items[iItemName], 0) == 1; 
    }
}
