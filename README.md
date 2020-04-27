# CMPM163Labs

## lab 2 ##
video: https://drive.google.com/file/d/17jfkKoHkQXqcE-02sG0wZYWiwN76UaPN/view?usp=sharing

<img src="images/models.png" width="500">

## lab 3 ##
video: https://drive.google.com/file/d/1ohHOBMqkH0mxcK_fUP-TfkpE43qwgZdQ/view?usp=sharing

Cube Material From Left to Right:

1) Used the THREE.MeshBasicMaterial function with the color set to orange and wireframe enabled

2) Used the THREE.MeshPhongMaterial function with color as gray, specular as green, and shininess as 30

3) Used a matrial with a simple vertex and fragment shader. The vertex shader maintained the position of the vertices on the mesh. The fragment shader returns the interpolation of two colors(used two different blueish colors) based on the z-coordinate of the fragment. Specifically, interpolation was done using the mix() function.

4) Used a material with the same vertex shader in cube 3 and a different fragment shader output. For this cube, the fragment shader would output a color for the fragment based on its position. The fragment's x-coordinate was used for the value of red, y-coordinate for the value of green, and z-coordinate for the value of blue.

## lab 4 ##
video: https://drive.google.com/file/d/1zWtMgJdBW8OuczLAlTpcwrekAo9OnN7E/view?usp=sharing

How I Made Each Cube:

1) Bottom Left: The material is a THREE.MeshPhongMaterial() material with a map set to the texture loaded from "156.jpg"

2) Bottom Middle: The material is a THREE.MeshPhongMaterial() material with a map set to the texture loaded from "156.jpg" and a normalMap set to the texture loaded from "156_norm.jpg"


