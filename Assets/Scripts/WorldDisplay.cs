using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldDisplay : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    // Methods
    public static string worldToLetters(World inputWorld) {
        string outputString = "";

        for (int y = 0; y < inputWorld.getHeight(); y++) {
            for (int x = 0; x < inputWorld.getWidth(); x++) {
                char inputChar;

                // Test the current tile and "convert" it into 
                if(inputWorld.getWorldTile(x, y) == TileID.nWater) {
                    inputChar = TileID.cWater;
                }
                else if(inputWorld.getWorldTile(x, y) == TileID.nDirt) {
                    inputChar = TileID.cDirt;
                }
                else if(inputWorld.getWorldTile(x,y) == TileID.nSand) {
                    inputChar = TileID.cSand;
                }
                else {
                    inputChar = TileID.cError;
                }

                outputString += inputChar;

                if(x == inputWorld.getWidth() - 1 && y < inputWorld.getHeight() - 1) {
                    outputString += "\n";
                }
            }
        }

        return outputString;
    }

    public static string worldToNumbers(World inputWorld) {
        string outputString = "";

        for (int y = 0; y < inputWorld.getHeight(); y++) {
            for (int x = 0; x < inputWorld.getWidth(); x++) {
                outputString += inputWorld.getWorldTile(x, y);

                if(x == inputWorld.getWidth() - 1 && y < inputWorld.getHeight() - 1) {
                    outputString += "\n";
                }
            }
        }

        return outputString;
    }

    public static int calculateFontSize(World inputWorld) {
        int fontSize = 413;

        fontSize /= inputWorld.getHeight();

        //Debug.Log("Font Size is " + fontSize);
        return fontSize;
    }
}
