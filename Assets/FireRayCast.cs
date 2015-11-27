using UnityEngine;
using System.Collections;

public class FireRayCast : MonoBehaviour
{
    public  float damage = 1;
    public float FireDelay = 0.2f;
    public GameObject[] shootEffect;
    public float recoilTimer = 0.5f;
    public Vector3 recoilOffsetPoint;

    public float accuracyOffsetTimer = 0.5f;
    private float _accuracyOffsetTimer;
    public Vector2 accuracyOffsetPoint;

    private float _fireDelay;
    private Quaternion cameraOrgPos;
    private float _recoilTimer;
    private float _inversRecoil;
    private float inversRecoil;



    void Start()
    {
        cameraOrgPos = Camera.main.transform.localRotation;
        _accuracyOffsetTimer = accuracyOffsetTimer;
        _recoilTimer = recoilTimer;
        _inversRecoil = recoilTimer;
        inversRecoil = recoilTimer;
    }

    void Update()
    {
        if (_recoilTimer <= recoilTimer)
        {
            _recoilTimer += Time.deltaTime;

            Quaternion desierdRotation = Quaternion.Euler(recoilOffsetPoint + Camera.main.transform.rotation.eulerAngles);
            Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, desierdRotation, _recoilTimer / recoilTimer);
        }
        else if(_inversRecoil <= inversRecoil)
        {
            Debug.Log("asfdas");
            _inversRecoil += Time.deltaTime;
            Camera.main.transform.localRotation = Quaternion.Lerp(Camera.main.transform.localRotation, cameraOrgPos, _inversRecoil / inversRecoil);
        }
        
        _fireDelay += Time.deltaTime;



        if (Input.GetAxis("Fire1") > 0f && CanFire())
        {
            cameraOrgPos = Camera.main.transform.localRotation;
            _fireDelay = 0;
            _recoilTimer = 0;
            _inversRecoil = 0;

            //   Ray r = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            Ray r = new Ray(transform.position, transform.forward);


            RaycastHit info;



            if (Physics.Raycast(r, out  info) )
            {


                //Quaternion.Lerp(Camera.main.transform.rotation, recoilOffsetPoint, recoilTimer / _recoilTimer);

                

                info.collider.transform.SendMessage("WasShoot", damage, SendMessageOptions.DontRequireReceiver);
                shootEffect[FXChooser()].transform.position = info.point - Vector3.forward ;
                shootEffect[FXChooser()].SetActive(true);
                ShootFXIndex++;
            }
        }
    }

    

    private int ShootFXIndex = 0;
    public bool CanFire()
    {
        if (FireDelay < _fireDelay)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private int FXChooser()
    {
        if (ShootFXIndex >= shootEffect.Length)
            ShootFXIndex = 0;
        return ShootFXIndex;
    }
}
