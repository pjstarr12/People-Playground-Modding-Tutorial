using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using System.Linq;
using TMPro;
using UnityEngine.Events;


//BASE SCRIPT
namespace Mod
{
    public class Mod
    {
        public static void Main()
        {


ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Stick"), //item to get from
        NameOverride = "ExampleName", //name
        DescriptionOverride = "ExampleDescription", //not needed
        CategoryOverride = ModAPI.FindCategory("Melee"), //category
        ThumbnailOverride = ModAPI.LoadSprite("ExampleThumbnail.png"), //thumnail image
        AfterSpawn = (Instance) => //after its spawned
        { 
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("ExampleTexture.png"); //the texture for the item
            Instance.FixColliders(); //fix the colliders
        }  
    }
);



ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Pistol"), //could be Revolver or other guns
        NameOverride = "ExampleGun",
        DescriptionOverride = "ExampleDescription",
        CategoryOverride = ModAPI.FindCategory("Firearms"), 
        ThumbnailOverride = ModAPI.LoadSprite("ExampleGunThumb.png"),
        AfterSpawn = (Instance) =>
        {
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("ExampleGun.png");
            var firearm = Instance.GetComponent<FirearmBehaviour>();
            Cartridge customCartridge = ModAPI.FindCartridge("9mm"); 
            customCartridge.name = "ExampleCartridge"; //cartridge name
            customCartridge.Damage *= 46f; //damage value
            customCartridge.StartSpeed *= 457368f;  //bullet speed
            customCartridge.PenetrationRandomAngleMultiplier *= 1.4f; //whats the angle that it can come out of after hitting an object?
            customCartridge.Recoil *= 8f; //recoil
            customCartridge.ImpactForce *= 0f; //how for do you want the object to be blown away?
            firearm.Cartridge = customCartridge; //dont change
            Instance.FixColliders(); //you know what this does
        }
    }
);


ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Dynamite"),
        NameOverride = "ExampleBomb",
        DescriptionOverride = "ExampleDescription",
        CategoryOverride = ModAPI.FindCategory("Explosives"),
        ThumbnailOverride = ModAPI.LoadSprite("ExampleBombThumb.png"),
        AfterSpawn = (Instance) =>
        { 
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("ExampleBomb.png");
            Instance.FixColliders();
        }  
    }
);





ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Human"),
        NameOverride = "ExampleHuman",
        DescriptionOverride = "ExampleDescription",
        CategoryOverride = ModAPI.FindCategory("Entities"),
        ThumbnailOverride = ModAPI.LoadSprite("ExampleSkinHumanThumb.png"),
        AfterSpawn = (Instance) =>
        {
            var skin = ModAPI.LoadTexture("ExampleSkinHuman.png");// textures
            var flesh = ModAPI.LoadTexture("ExampleFlesh.png");// textures
            var bone = ModAPI.LoadTexture("ExampleBone.png");// textures
            var person = Instance.GetComponent<PersonBehaviour>(); //dont change
            person.SetBodyTextures(skin, flesh, bone, 1); //dont change
            person.SetBruiseColor(86, 62, 130);//colors'n'stuff
            person.SetSecondBruiseColor(154, 0, 7);//colors'n'stuff
            person.SetThirdBruiseColor(207, 206, 120);//colors'n'stuff
            person.SetRottenColour(202, 199, 104);//colors'n'stuff
            person.SetBloodColour(108, 0, 4);//colors'n'stuff
        }
    }
);





        }
    }
}