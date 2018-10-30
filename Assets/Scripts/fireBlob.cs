using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class fireBlob : MonoBehaviour
{
    public ForceMode typeOfForce = ForceMode.Impulse;
    public float amountOfForce = 10f;
    public float timeToReload = 0.5f;

    private GameObject blobToLaunch;
    private GameObject targetObject;
    private Vector3 startPoint;

    private bool reloading = false;

    private RaycastHit hit;
    GestureRecognizer recognizer;
    

    // Use this for initialization
    void Start () {

        blobToLaunch = transform.Find("blob").gameObject;

        startPoint = blobToLaunch.transform.position;

        recognizer = new GestureRecognizer();
        recognizer.SetRecognizableGestures(GestureSettings.Tap);
        recognizer.TappedEvent += Recognizer_TappedEvent;
        
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("f"))
        {
            Debug.Log("fire keyboard!");
            fire();
        }

        if (Input.GetMouseButton(0))
        {
            Debug.Log("fire mouse!");
            fire();
        }
    }

    private void fire(GameObject target = null)
    {
        if (reloading) { return; }

        Rigidbody blobRB = blobToLaunch.GetComponent<Rigidbody>();
        blobRB.isKinematic = false;
        blobRB.AddForce(Camera.main.transform.forward * amountOfForce, typeOfForce);
        
        Destroy(blobToLaunch, 3f);
        reloading = true;
        Invoke("reload", timeToReload);
    }

    private void reload()
    {
        blobToLaunch = Instantiate(Resources.Load("Prefabs/bubble"), startPoint, Quaternion.identity, this.gameObject.transform) as GameObject;
        reloading = false;
    }

    private void MouseDown() 
    {
        Debug.Log("Mouse is down!!");
    }

    private void Recognizer_TappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
    {
        Debug.Log("got a tap");

        RaycastHit hitInfo;
        Vector3 cPos = Camera.main.transform.position;
        Vector3 cFor = Camera.main.transform.forward;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo, 20.0f, Physics.DefaultRaycastLayers))
        {
            targetObject = hitInfo.collider.gameObject;
            fire();
        }
    }
}
