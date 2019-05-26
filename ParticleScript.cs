using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour {

    //ParticleSystem ps;
    public ParticleSystem ps;
    public ParticleSystem ps1;
    public ParticleSystem ps2;
    void Start () 
    {
        // Get Particle system component
        //ps = GetComponent<ParticleSystem>();
        // Call particle play function
        ps.Play();
        ps1.Play();
        ps2.Play();
	}

	void Update () {
    
		int numPartitions = 8;
		float[] aveMag = new float[numPartitions];
		float partitionIndx = 0;
		int numDisplayedBins = 512 / 2; 

		for (int i = 0; i < numDisplayedBins; i++) 
		{
			if(i < numDisplayedBins * (partitionIndx + 1) / numPartitions){
				aveMag[(int)partitionIndx] += AudioPeer.spectrumData [i] / (512/numPartitions);
			}
			else{
				partitionIndx++;
				i--;
			}
		}

		for(int i = 0; i < numPartitions; i++)
		{
			aveMag[i] = (float)0.5 + aveMag[i]*100;
			if (aveMag[i] > 100) {
				aveMag[i] = 100;
			}
		}

		float mag = aveMag[0];
        float mag2 = aveMag[1];
        float mag3 = aveMag[2];
        //var ps2 = new ParticleSystem.EmitParams
        // if mag is greater than some threshold(0.6)
        //var emission = ps.emission;
        // emission.rateOverTime = mag*100f;
       // var v = ps.velocityOverLifetime;
       // v.enabled = false;
        var emission = ps.emission;
        emission.enabled = true;
        emission.rateOverTime = Mathf.Pow(mag*2, 5);

        var noise = ps.noise;
        noise.enabled = true;
        noise.strength = 2;
        noise.sizeAmount = mag;
        //noise.rotationAmount = Mathf.Pow(mag, 3);
        //noise.positionAmount = Mathf.Pow(mag, 3);

        noise.quality = ParticleSystemNoiseQuality.High;

        //////
        var emission2 = ps1.emission;
        emission2.enabled = true;
        emission2.rateOverTime = Mathf.Pow(mag2 * 2, 5);

        var noise2 = ps1.noise;
        noise2.enabled = true;
        noise2.strength = 2;
        noise2.sizeAmount = mag2;
        noise2.quality = ParticleSystemNoiseQuality.High;
        ///////
        var emission3 = ps2.emission;
        emission3.enabled = true;
        emission3.rateOverTime = Mathf.Pow(mag3 * 2, 5);
        var noise3 = ps2.noise;
        noise3.enabled = true;
        noise3.strength = 2;
        noise3.sizeAmount = mag3;
        noise3.quality = ParticleSystemNoiseQuality.High;
        /// 
        /*if (mag > 0.9)
        {

            ps.Emit(1);
           
        }
        else if(mag < 0.6 && mag > 0.5)
        {
            ps1.Emit(1);
        }*/

        // emit particle using emit function

    }


}

