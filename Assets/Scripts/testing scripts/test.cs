using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour {
    // Variables
    public static World testWorld = new World(30,30);
    public Text display;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyUp(KeyCode.Space)) {
            testWorld = WorldGenerator.smoothWorld(testWorld, 1);
            display.text = WorldDisplay.worldToLetters(testWorld);
        }
        if(Input.GetKeyUp(KeyCode.Alpha1)) {
            testWorld = new World(10,10);
            testWorld = WorldGenerator.generateWorld(testWorld, 0, 65);
            display.text = WorldDisplay.worldToLetters(testWorld);
        }
        if (Input.GetKeyUp(KeyCode.Alpha2)) {
            testWorld = new World(20, 20);
            testWorld = WorldGenerator.generateWorld(testWorld, 0, 65);
            display.text = WorldDisplay.worldToLetters(testWorld);
        }
        if (Input.GetKeyUp(KeyCode.Alpha3)) {
            testWorld = new World(30, 30);
            testWorld = WorldGenerator.generateWorld(testWorld, 0, 60);
            display.text = WorldDisplay.worldToLetters(testWorld);
        }
        if (Input.GetKeyUp(KeyCode.Alpha4)) {
            testWorld = new World(40, 40);
            testWorld = WorldGenerator.generateWorld(testWorld, 0, 55);
            display.text = WorldDisplay.worldToLetters(testWorld);
        }
        if (Input.GetKeyUp(KeyCode.Alpha5)) {
            testWorld = new World(50, 50);
            testWorld = WorldGenerator.generateWorld(testWorld, 0, 55);
            display.text = WorldDisplay.worldToLetters(testWorld);
        }
        if (Input.GetKeyUp(KeyCode.Alpha0)) {
            testWorld = new World(125, 125);
            testWorld = WorldGenerator.generateWorld(testWorld, 0, 52);
            display.text = WorldDisplay.worldToLetters(testWorld);
        }
    }
}
