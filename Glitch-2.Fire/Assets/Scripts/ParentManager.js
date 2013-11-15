#pragma strict

function OnTriggerEnter(collider : Collider)
{

	if(collider.transform.tag == "Player"){
		passenger = Collider.transform; 
		passenger.parent = this.transform; 
	
	}
}

function OnTriggerExit()
{
	passenger.parent = null; 
}