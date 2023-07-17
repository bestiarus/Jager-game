using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class SC_Weapon : MonoBehaviour
{
    public bool singleFire = false;
    public float fireRate = 0.1f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float weaponDamage = 15; //How much damage should this weapon deal
    public AudioClip fireAudio;
    public SC_DamageReceiver player;
    public Image incendio;
    public Image erg;
    [HideInInspector]
    public SC_WeaponManager manager;
    public float waitTime = 3.0f;
    float nextFireTime = 0;
    bool canFire = true;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        //Make sound 3D
        audioSource.spatialBlend = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && singleFire)
        {
            Fire();
        }
        if (Input.GetMouseButton(0) && !singleFire)
        {
            Fire();
        }
        if (waitTime > 0)
        {
            incendio.fillAmount += 1.0f/waitTime * Time.deltaTime;
        }
    }

    void Fire()
    {
        if (canFire)
        {
            if (Time.time > nextFireTime)
            {
                nextFireTime = Time.time + fireRate;

                
                    //Point fire point at the current center of Camera
                    Vector3 firePointPointerPosition = manager.playerCamera.transform.position + manager.playerCamera.transform.forward * 100;
                    RaycastHit hit;
                    if (Physics.Raycast(manager.playerCamera.transform.position, manager.playerCamera.transform.forward, out hit, 100))
                    {
                        firePointPointerPosition = hit.point;
                    }
                    firePoint.LookAt(firePointPointerPosition);
                    //Fire
                    GameObject bulletObject = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                    SC_Bullet bullet = bulletObject.GetComponent<SC_Bullet>();
                    //Set bullet damage according to weapon damage value
                    bullet.SetDamage(weaponDamage);
                    audioSource.clip = fireAudio;
                    audioSource.Play();
                    Debug.Log(player.weaponManager.selectedWeapon);
                    
                    if (weaponDamage == 50) {
                        incendio.fillAmount = 0;
                    }
                    if (weaponDamage == 15) {
                        erg.fillAmount = 33;
                    }
            }
        }
    }

    //Called from SC_WeaponManager
    public void ActivateWeapon(bool activate)
    {
        StopAllCoroutines();
        canFire = true;
        gameObject.SetActive(activate);
    }
}