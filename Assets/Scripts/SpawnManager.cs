using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject pirates;
    private bool firstWave;
    private bool secondWave; 
    private bool thirdWave;
    public int numEnemiesFirstWave;
    public int numEnemiesSecondWave;
    public int numEnemiesThirdWave;
    float timer;


    // Start is called before the first frame update
    void Start()
    {
        firstWave = true;
        secondWave = false;
        thirdWave = false;
        timer = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.deltaTime - timer == 60) {
            secondWave = true;
        }
        else if(Time.deltaTime - timer == 120) {
            thirdWave = true;
        }
        if(firstWave) {
            for(int i = 0; i < numEnemiesFirstWave; i++) {
                Instantiate(pirates, this.transform.position, this.transform.rotation);
            }
            firstWave = false;
        }
        if(secondWave) {
            for(int i = 0; i < numEnemiesSecondWave; i++) {
                Instantiate(pirates, this.transform.position, this.transform.rotation);
            }
            secondWave = false;
        }
        if(thirdWave) {
            for(int i = 0; i < numEnemiesThirdWave; i++) {
                Instantiate(pirates, this.transform.position, this.transform.rotation);
            }
            thirdWave = false;
        }
    }
}
