﻿#pragma strict

var other : Transform;
 var range:int;
 var sound:AudioClip;
 var played:boolean;
 var timing:int;
 var delay:int=10;
 
 function Start(){
	 played=false;
	 timing = Time.time;
 }
 
 function Update(){
	 if (Vector3.Distance(other.position, transform.position) < range && !played) {
	       if(timing<Time.time){
	            played = true;
		 		AudioSource.PlayClipAtPoint(sound, transform.position);
	            timing = Time.time + delay;
            }
	 }
	 /*if(played){
		 AudioSource.PlayClipAtPoint(sound, transform.position);
		 played=false;
	 }*/
 }