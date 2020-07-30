using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour {
    // Generates a map, seeds less than or equal to 0 are randomized
    public static World generateWorld(World inputWorld, int seed, int landPercent) {
        World outputWorld = new World(inputWorld.getWidth(), inputWorld.getHeight());

        // Generate a seed if a negative one is provided
        if(seed <= 0) {
            seed = (int)System.DateTime.Now.Ticks;
        }
        // Make seed positive by getting the absolute value
        seed = Mathf.Abs(seed);
        Debug.Log("Seed is " + seed);
        Random.InitState(seed);

        // Fill every tile with a random number from 1-100
        for (int x = 0; x < inputWorld.getWidth(); x++) {
            for (int y = 0; y < inputWorld.getHeight(); y++) {
                int rand = Random.Range(1, 101);
                if(rand  <= landPercent) {
                    rand = TileID.nDirt;
                }
                else {
                    rand = TileID.nWater;
                }

                outputWorld.setWorldTile(x, y, rand);
            }
        }

        // Loop through each of the edge tiles and set them to water (0)
        for (int x = 0; x < inputWorld.getWidth(); x++) {
            outputWorld.setWorldTile(x, 0, TileID.nWater);
        }
        for (int x = 0; x < inputWorld.getWidth(); x++) {
            outputWorld.setWorldTile(x, inputWorld.getHeight() - 1, TileID.nWater);
        }
        for (int y = 1; y < inputWorld.getHeight() - 1; y++) {
            outputWorld.setWorldTile(0, y, TileID.nWater);
        }
        for (int y = 1; y < inputWorld.getHeight() - 1; y++) {
            outputWorld.setWorldTile(inputWorld.getWidth() - 1, y, TileID.nWater);
        }

        return outputWorld;
    }

    // Smooths out a world over a specified number of itterations
    public static World smoothWorld(World inputWorld, int reps) {
        World outputWorld = inputWorld;

        for (int currReps = 0; currReps < reps; currReps++) {
            for (int x = 1; x < outputWorld.getWidth() - 1; x++) {
                for (int y = 1; y < outputWorld.getWidth() - 1; y++) {
                    if(countNeighbors(outputWorld, x, y, TileID.nWater, 0) > 4) {
                        outputWorld.setWorldTile(x, y, TileID.nWater);
                    }
                    else if(countNeighbors(outputWorld, x, y, TileID.nWater, 0) < 4) {
                        outputWorld.setWorldTile(x, y, TileID.nDirt);
                    }
                }
            }
        }

        return outputWorld;
    }

    // Takes in a number and counts the number of identical tiles next to it
    public static int countNeighbors(World inputWorld, int x, int y, int scanNumber, int layer) {
        int count = 0;

        for (int scanX = x - 1; scanX <= x + 1; scanX++) {
            for (int scanY = y - 1; scanY <= y + 1; scanY++) {

                // WIP Layer
                if(layer == -1) {

                }

                // World Layer
                else if(layer == 0) {
                    if(inputWorld.getWorldTile(scanX, scanY) == scanNumber && (scanX != x || scanY != y)) {
                        count++;
                    }
                }

                // Surface Layer
                else if(layer == 1) {

                }
            }
        }
        return count;
    }
}
