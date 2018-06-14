using System;
using System.Collections.Generic;
using System.Linq;

namespace Dialogue
{
    public class Dialogue
	{
        public string DialogueText { get; set; }
        public string Answer1 { get; set; }
		public string Answer2 { get; set; }

        public Dialogue(string dialogue, string answer1, string answer2)
        {
            DialogueText = dialogue;
            Answer1 = answer1;
			Answer2 = answer2;
        }
    }
}