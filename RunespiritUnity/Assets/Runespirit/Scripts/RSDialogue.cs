using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using GAD375.Prototyper;

namespace Punk.Runespirit
{
    public class RSDialogue : Dialogue
    {
        public string characterName = "Unknown";
        public Sprite characterImage;
        // Start is called before the first frame update
        public override void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        /*
        [YarnCommand("@")]
        public void Charname(string charname)
        {
            Debug.Log("Char name is " + charname);
            //DialogueManager.DialogueForChar(characterName, characterImage);
            DialogueManager.DialogueForChar(characterName);
            
            //manager.ChangeDialogueSettings(charname);
        }
        */
    }
}