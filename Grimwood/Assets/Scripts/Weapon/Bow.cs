using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [System.Serializable]
    public class BowSettings
    {
        [Header("Arrow Settings")]
        public Rigidbody arrowPrefab;
        public Transform arrowPos;
        public Transform arrowEquipParent;
        public float arrowForce = 3;

        [Header("Bow String Settings")]
        public Transform bowString;
        public Transform stringInitialPos;
        public Transform stringHandPullPos;
        public Transform stringInitialParent;
        
    }
    [SerializeField]
    public BowSettings bowSettings;

    [Header("Crosshair Settings")]
    public GameObject crossHairPrefab;
    GameObject currentCrossHair;

    Rigidbody currentArrow;

    bool canPullString = false;
    bool canFireArrow = false;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickArrow()
    {
        bowSettings.arrowPos.gameObject.SetActive(true);
    }

    public void DisableArrow()
    {
        bowSettings.arrowPos.gameObject.SetActive(false);
    }

    public void PullString()
    {
        bowSettings.bowString.transform.position = bowSettings.stringHandPullPos.position;
        bowSettings.bowString.transform.parent = bowSettings.stringHandPullPos;
    }

    public void ReleaseString()
    {
        bowSettings.bowString.transform.position = bowSettings.stringInitialPos.position;
        bowSettings.bowString.transform.parent = bowSettings.stringInitialParent;
    }

    public void ShowCrosshair(Vector3 crosshairPos)
    {
        if (!currentCrossHair)
            currentCrossHair = Instantiate(crossHairPrefab) as GameObject;

        currentCrossHair.transform.position = crosshairPos;
        currentCrossHair.transform.LookAt(Camera.main.transform);
    }

    public void RemoveCrosshair()
    {
        if (currentCrossHair)
            Destroy(currentCrossHair);
    }
    

    public void Fire(Vector3 hitPoint)
    {
        Vector3 dir = hitPoint - bowSettings.arrowPos.position;
        
        currentArrow =
            Instantiate(bowSettings.arrowPrefab, bowSettings.arrowPos.position,
                bowSettings.arrowPos.rotation) as Rigidbody;
        
        currentArrow.AddForce(dir * bowSettings.arrowForce, ForceMode.Force);
    }
}