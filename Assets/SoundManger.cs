using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManger : MonoBehaviour
{
    public static AudioClip playerHitSound, groundHitSound, shootingSound, deathSound, weaponSwapSound, niceBonusHealth, niceBonusAmmo;
    static AudioSource audioSource;
    void Start()
    {
        playerHitSound = Resources.Load<AudioClip>("playerHit");
        groundHitSound = Resources.Load<AudioClip>("missSound");
        shootingSound = Resources.Load<AudioClip>("shootSound");
        deathSound = Resources.Load<AudioClip>("DieSound");
        weaponSwapSound = Resources.Load<AudioClip>("reload");
        niceBonusHealth = Resources.Load<AudioClip>("nice, bonus health");
        niceBonusAmmo = Resources.Load<AudioClip>("nice, bonus ammo");

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "playerHit":
                audioSource.PlayOneShot(playerHitSound);
                break;
            case "missSound":
                audioSource.PlayOneShot(groundHitSound);
                break;
            case "shootSound":
                audioSource.PlayOneShot(shootingSound);
                break;
            case "DieSound":
                audioSource.PlayOneShot(deathSound);
                break;
            case "reload":
                audioSource.PlayOneShot(weaponSwapSound);
                break;
            case "nice, bonus ammo":
                audioSource.PlayOneShot(niceBonusAmmo);
                break;
            case "nice, bonus health":
                audioSource.PlayOneShot(niceBonusHealth);
                break;
        }
    }
}
