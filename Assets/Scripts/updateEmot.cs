using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateEmot : MonoBehaviour {
    public Material mHappy;
    public Material mFunny;
    public Material mTongue;
    public Material mWink;
    public Material mLove;
    public Material mShy;

    private PhotonView photonView;
    // Use this for initialization
    void Start () {
        photonView = GetComponent<PhotonView>();
        PhotonNetwork.sendRate = 60;
        PhotonNetwork.sendRateOnSerialize = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.isMine)
        {
            return;
        }
        if (Input.GetKey("1"))
        {
           GetComponentInChildren<Renderer>().material = mHappy;
            Debug.Log("_1");
            photonView.RPC("SetEmot", PhotonTargets.All, "mHappy");
        }
        if (Input.GetKey("2"))
        {
            GetComponentInChildren<Renderer>().material = mFunny;
            photonView.RPC("SetEmot", PhotonTargets.All, "mFunny");
        }
        if (Input.GetKey("3"))
        {
            GetComponentInChildren<Renderer>().material = mTongue;
            photonView.RPC("SetEmot", PhotonTargets.All, "mTongue");
        }
        if (Input.GetKey("4"))
        {
            GetComponentInChildren<Renderer>().material = mWink;
            photonView.RPC("SetEmot", PhotonTargets.All, "mWink");
        }
        if (Input.GetKey("5"))
        {
            GetComponentInChildren<Renderer>().material = mLove;
            photonView.RPC("SetEmot", PhotonTargets.All, "mLove");
        }
    }
    [PunRPC]
    void SetEmot(string face)
    {
        Debug.Log(face);
        switch (face) {

            case "mFunny":
                StartCoroutine(UpdateEmot(mFunny));
                break;
            case "mTongue":
                StartCoroutine(UpdateEmot(mTongue));
                break;
            case "mWink":
                StartCoroutine(UpdateEmot(mWink));
                break;
            case "mLove":
                StartCoroutine(UpdateEmot(mLove));
                break;
            default:
                break;


        }
        
    }

    IEnumerator UpdateEmot(Material face) {
        gameObject.GetComponentInChildren<MeshRenderer>().material = face; 
        yield return new WaitForSeconds(3);
        gameObject.GetComponentInChildren<MeshRenderer>().material = mHappy;

    }
}
