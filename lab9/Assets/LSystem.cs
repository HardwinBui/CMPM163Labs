using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSystem : MonoBehaviour {
    private string axiom = "F";
    private float angle = 25f;
    private string curString;
    private Dictionary<char,string> rules = new Dictionary<char, string>();
    private Stack<TransformInfo> transformStack = new Stack<TransformInfo>();

    private float length = 10f;
    private bool isGenerating = false;

    // Start is called before the first frame update
    void Start() {
        /*
        axiom = "F";
        rules.Add('F', "FF+[+F-F-F]-[-F+F+F]");
        angle = 25f;
        */
        /*
        axiom = "F-G-G";
        rules.Add('F', "F-G+F+G-F");
        rules.Add('G', "GG");
        angle = 90f;
        */
        axiom = "1";
        rules.Add('1', "0+1+0+1+0");
        rules.Add('0', "1-0-1-0-1");
        angle = 36f;

        curString = axiom; 
        StartCoroutine(GenerateLSystem());
    }

    // Update is called once per frame
    void Update() {
    }

    IEnumerator GenerateLSystem() {
        int count = 0;

        while (count < 5) {
            if(!isGenerating) {
                isGenerating = true;
                StartCoroutine(Generate());
            }
            else {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    IEnumerator Generate() {
        string newString = "";

        char[] stringChars = curString.ToCharArray();
        

        for (int i = 0; i < stringChars.Length; i++) {
            char curChar = stringChars[i];

            if (rules.ContainsKey(curChar)) {
                newString += rules[curChar];
            }
            else {
                newString += curChar.ToString();
            }
        }
        curString = newString;

        stringChars = curString.ToCharArray();
        for (int i = 0; i < stringChars.Length; i++) {
            char curChar = stringChars[i];

            if(curChar == '+') {
                //transform.Rotate(Vector3.up * angle);
                transform.Rotate(Vector3.up * angle);
            }
            else if(curChar == '-') {
                print("called");
                transform.Rotate(Vector3.up * -angle);
            }
            else if(curChar == '[') {
                TransformInfo ti = new TransformInfo();
                ti.position = transform.position;
                ti.rotation = transform.rotation;
                transformStack.Push(ti);
            }
            else if(curChar == ']') {
                TransformInfo ti = transformStack.Pop();
                transform.position = ti.position;
                transform.rotation = ti.rotation;
            }
            else {
                // Move forward
                Vector3 initPos = transform.position;
                transform.Translate (Vector3.forward * length);
                Debug.DrawLine(initPos, transform.position, Color.white,10000f,false);
                yield return null;
            }
        }
        isGenerating = false;
    }

}
