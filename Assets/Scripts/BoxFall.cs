using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoxFall : MonoBehaviour
{
    public GameObject box;
    public GameObject fakeBox;
    public GameObject fakeBoxContainer;
    public GameObject spawnManager;

    private float xPos;
    private float yPos;

    public Button clickBtn;

    private int numberOfBoxes;
    public Transform background;
    public GameObject backgroundExtra;  
    public GameObject camera;
    private float moveSpeed = 0.1f;
    private float increasedCameraHeight;
    private float increasedFakeBoxHeight;
    private float increasedSpawnManagerHeight;

    public static int numberTouchGround;

    void Start()
    {
        increasedCameraHeight = camera.transform.position.y;
        increasedFakeBoxHeight = fakeBox.transform.position.y;
        increasedSpawnManagerHeight = spawnManager.transform.position.y;
    }

    void Update()
    {
        if(BoxTouch.isBoxThrown)
        {
            StartCoroutine("SpawnBox");
        }

        if(numberTouchGround >= 2)
        {
            numberTouchGround = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        Vector3 nextPosition = new Vector3(camera.transform.position.x, increasedCameraHeight, camera.transform.position.z);        
        camera.transform.position = Vector3.Lerp(camera.transform.position, nextPosition, Time.deltaTime * moveSpeed);

        nextPosition = new Vector3(fakeBoxContainer.transform.position.x, increasedFakeBoxHeight, fakeBoxContainer.transform.position.z);
        fakeBoxContainer.transform.position = Vector3.Lerp(fakeBoxContainer.transform.position, nextPosition, Time.deltaTime * moveSpeed);

        nextPosition = new Vector3(spawnManager.transform.position.x, increasedSpawnManagerHeight, spawnManager.transform.position.z);
        spawnManager.transform.position = Vector3.Lerp(spawnManager.transform.position, nextPosition, Time.deltaTime * moveSpeed);
    }

    IEnumerator SpawnBox()
    {
        numberOfBoxes++;    

        if (numberOfBoxes % 8 == 0)
        {
            increasedCameraHeight += 11.5f;
            increasedFakeBoxHeight += 11.5f;
            increasedSpawnManagerHeight += 11.5f;

            Instantiate(backgroundExtra, new Vector3(background.position.x, increasedCameraHeight, background.position.y), Quaternion.identity);
        }

        BoxTouch.isBoxThrown = false;
        clickBtn.interactable = false;

        xPos = fakeBox.transform.position.x;
        yPos = spawnManager.transform.position.y;

        Instantiate(box, new Vector3(xPos, yPos, 0), Quaternion.identity);

        yield return new WaitForSeconds(2f);

        clickBtn.interactable = true;
    }
}
