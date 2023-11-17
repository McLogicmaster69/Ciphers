using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DumbCodeYe.LetterPatterns.Spaces
{
    public static class SpaceAdder
    {
        public static string Add(string s)
        {
            List<SpaceInsertedString> currentSpaces = new List<SpaceInsertedString>();
            currentSpaces.Add(new SpaceInsertedString(s, 0, 1, new List<string>(), 0));

            for (int i = 0; i < s.Length - 1; i++)
            {
                List<SpaceInsertedString> newSpaces = new List<SpaceInsertedString>();
                foreach(SpaceInsertedString sis in currentSpaces)
                {
                    foreach(SpaceInsertedString evolved in sis.Generate())
                    {
                        if(newSpaces.Count == 0)
                        {
                            newSpaces.Add(evolved);
                        }
                        else
                        {
                            bool found = false;
                            for (int j = 0; j < newSpaces.Count; j++)
                            {
                                if (evolved.Score > newSpaces[j].Score)
                                {
                                    newSpaces.Insert(j, evolved);
                                    found = true;
                                    break;
                                }
                            }
                            if (!found)
                            {

                            }
                        }
                    }
                }
            }
        }
    }
}
