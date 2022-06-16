using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
 
 public class Reset : MonoBehaviour{
        public void Reboot(){
             Scene scene = SceneManager.GetActiveScene(); 
             SceneManager.LoadScene(scene.name);
     }
 }