using UnityEngine;
using System.Collections;

public class ParticleHelper {

	public static float GetlifeCycleSec(Transform transform)
	{
		ParticleSystem[] particleSystems = transform.GetComponentsInChildren<ParticleSystem>();
		float maxDuration = 0;

		foreach(ParticleSystem ps in particleSystems)
		{
			if(ps.emission.enabled)
			{
				
				if(ps.main.loop)
				{

					return -1f;
				}

				float dunration = 0f;
				if(ps.emission.rateOverTimeMultiplier <=0)
				{
					dunration = ps.main.startDelay.constant + ps.main.startLifetime.constant;
				}
				else
				{
					dunration = ps.main.startDelay.constant  + Mathf.Max(ps.main.duration, ps.main.startLifetime.constant);
				}

				if (dunration > maxDuration) 
				{
					maxDuration = dunration;
				}
			}
		}

		return maxDuration;
	}

}
