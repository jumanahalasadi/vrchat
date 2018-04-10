using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class updateEmot : MonoBehaviour {
    public Material mHappy;
    public Material mFunny;
    public Material mTongue;
    public Material mWink;
    public Material mLove;
    public Material mShy;
	public int activeEmoji;
	private Camera playerCamera;
	public ParticleSystem particleShy, particleLove, particleLaugh, particleTongue, particleWink, particleHappy;

    private PhotonView photonView;
    // Use this for initialization
    void Start () {
		activeEmoji = 1;
        photonView = GetComponent<PhotonView>();
        PhotonNetwork.sendRate = 60;
        PhotonNetwork.sendRateOnSerialize = 1;
		playerCamera = gameObject.GetComponentInChildren<Camera>();
		particleShy = GameObject.Find ("ParticleShy").GetComponent<ParticleSystem>();
		particleLove = GameObject.Find ("ParticleLove").GetComponent<ParticleSystem>();
		particleLaugh = GameObject.Find ("ParticleLaugh").GetComponent<ParticleSystem>();
		particleTongue = GameObject.Find ("ParticleTongue").GetComponent<ParticleSystem>();
		particleWink = GameObject.Find ("ParticleWink").GetComponent<ParticleSystem>();
		particleHappy = GameObject.Find ("ParticleWink").GetComponent<ParticleSystem>();

    }

	public void setActiveEmoji (int emoji) {
		activeEmoji = emoji;
		Debug.Log ("it worked");
	}
		
    // Update is called once per frame
    void Update()
    {
		
        if (!photonView.isMine)
        {
            return;
        }
	

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			
			GetComponentInChildren<Renderer> ().material = mHappy;
			particleHappy.Play (); 
			particleHappy.Emit (10);
			Debug.Log ("_1");
			photonView.RPC ("SetEmot", PhotonTargets.All, "mHappy");
		} else if (Input.GetKeyDown (KeyCode.Alpha2))  {
			particleShy.Play ();
			particleShy.Emit (10);
			GetComponentInChildren<Renderer> ().material = mShy;
			photonView.RPC ("SetEmot", PhotonTargets.All, "mShy");
		} else if (Input.GetKeyDown (KeyCode.Alpha6))  {
			particleTongue.Play ();
			particleTongue.Emit (10);
			GetComponentInChildren<Renderer> ().material = mTongue;
			photonView.RPC ("SetEmot", PhotonTargets.All, "mTongue");
		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			particleWink.Play ();
			particleWink.Emit (10);
			GetComponentInChildren<Renderer> ().material = mWink;
			photonView.RPC ("SetEmot", PhotonTargets.All, "mWink");
		} else if (Input.GetKeyDown (KeyCode.Alpha4))  {
			particleLove.Play ();
			particleLove.Emit (10);
			GetComponentInChildren<Renderer> ().material = mLove;
			photonView.RPC ("SetEmot", PhotonTargets.All, "mLove");
		} else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			particleLaugh.Play ();
			particleLaugh.Emit (10);
			GetComponentInChildren<Renderer> ().material = mFunny;
			photonView.RPC ("SetEmot", PhotonTargets.All, "mFunny");
		} else {
			particleHappy.Stop ();
			particleShy.Stop ();
			particleWink.Stop ();
			particleLove.Stop ();
			particleTongue.Stop ();
			particleLaugh.Stop ();


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
