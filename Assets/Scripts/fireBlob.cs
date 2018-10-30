using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class fireBlob : MonoBehaviour
{
    public ForceMode typeOfForce = ForceMode.Impulse;
    public float amountOfForce = 10f;
    public float timeToReload = 0.5f;

    private GameObject blobToLaunch;
    private GameObject targetObject;
    private Vector3 initialOffset;
    private Vector3 startPoint;

    private bool reloading = false;

    private RaycastHit hit;
    GestureRecognizer recognizer;
    

    // Use this for initialization
    void Start () {

        blobToLaunch = transform.Find("blob").gameObject;

        initialOffset = new Vector3(0.1f, -0.2f, 0.2f);

        recognizer = new GestureRecognizer();
        recognizer.SetRecognizableGestures(GestureSettings.Tap);
        recognizer.TappedEvent += Recognizer_TappedEvent;
        recognizer.StartCapturingGestures();
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
        blobRB.AddForce((Camera.main.transform.forward + Camera.main.transform.up * 0.5f) * amountOfForce, typeOfForce);
        
        Destroy(blobToLaunch, 3f);
        reloading = true;
        Invoke("reload", timeToReload);
    }

    private void reload()
    {
        Transform cT = Camera.main.transform;
        startPoint = cT.position + cT.forward * initialOffset.z + cT.up * initialOffset.y + cT.right * initialOffset.x;
        blobToLaunch = Instantiate(Resources.Load("Prefabs/bubble"), startPoint, Quaternion.identity, this.gameObject.transform) as GameObject;
        reloading = false;
    }

    private void MouseDown() 
    {
        Debug.Log("Mouse is down!!");
    }

    private void Recognizer_TappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
    {
        Debug.Log("air tap detected");

        RaycastHit hitInfo;
        Vector3 cPos = Camera.main.transform.position;
        Vector3 cFor = Camera.main.transform.forward;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo, 6.0f, Physics.AllLayers))
        {
            targetObject = hitInfo.collider.gameObject;
            fire();
        }
    }
}
