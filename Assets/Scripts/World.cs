using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World {
    // Variables
    int width;
    int height;

    int[,] worldLayer; // Layer holding world info
    int[,] surfaceLayer; // Layer holding decorations

    // Constructor
    public World(int inputWidth, int inputHeight) {
        worldLayer = new int[inputWidth, inputHeight];
        surfaceLayer = new int[inputWidth, inputHeight];
        width = inputWidth;
        height = inputHeight;
    }

    // Methods


    // Getters
    public int getWorldTile(int x, int y) {
        return worldLayer[x, y];
    }

    public int getSurfaceTile(int x, int y) {
        return surfaceLayer[x, y];
    }

    public int getWidth() {
        return width;
    }

    public int getHeight() {
        return height;
    }

    // Setters
    public void setWorldTile(int x, int y, int id) {
        worldLayer[x, y] = id;
    }

    public void setSurfaceTile(int x, int y, int id) {
        surfaceLayer[x, y] = id;
    }
}
