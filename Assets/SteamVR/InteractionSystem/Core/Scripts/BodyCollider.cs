//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Collider dangling from the player's head
//
//=============================================================================

using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem
{
	//-------------------------------------------------------------------------
	[RequireComponent( typeof( CapsuleCollider ) )]
	public class BodyCollider : MonoBehaviour
	{
		public Transform head;

		private CapsuleCollider capsuleCollider;
        private AudioSource AudioSource;

		//-------------------------------------------------
		void Awake()
		{
			capsuleCollider = GetComponent<CapsuleCollider>();
            AudioSource = GetComponent<AudioSource>();
        }


		//-------------------------------------------------
		void FixedUpdate()
		{
			float distanceFromFloor = Vector3.Dot( head.localPosition, Vector3.up );
			capsuleCollider.height = Mathf.Max( capsuleCollider.radius, distanceFromFloor );
			transform.localPosition = head.localPosition - 0.5f * distanceFromFloor * Vector3.up;
		}


        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag.Equals("Bullet"))
            {
                AudioSource.Play();
            }
        }
    }

    
}
