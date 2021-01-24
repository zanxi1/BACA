using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkingManager : NetworkManager {

	//public BoxCollider spawnArea;

	public override void OnServerAddPlayer(NetworkConnection conn) {
		//base.OnServerAddPlayer(conn);

		//Vector3 location = spawnArea.bounds.center;
		//Vector3 size = spawnArea.bounds.extents;
		//Vector3 spawnPoint = new Vector3(
		//	location.x + size.x * Random.value, 
		//	location.z, 
		//	location.z + size.z * Random.value);
		Vector3 spawnPoint = new Vector3(0, 3, 0);
		GameObject player = Instantiate(
			playerPrefab, 
			spawnPoint, 
			new Quaternion());
		NetworkServer.AddPlayerForConnection(conn, player);
	}

}
