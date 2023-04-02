using System;
using System.Collections.Generic;

namespace SpaceBattle2128
{
    class ObjectList
    {
        public List<GameObject> MakeObjectList(params GameObject[] gameObjects)
        {
            List<GameObject> ObjectList = new List<GameObject>();
            for (int i = 0; i < gameObjects.Length; i++) { ObjectList.Add(gameObjects[i]); }
            return ObjectList;
        }
        public void RenderList(List<GameObject> ObjectList)
        {
            for (int i = 0; i < ObjectList.Count; i++)
            {
                Console.WriteLine($"{ObjectList[i].renderID} {ObjectList[i].tag}");
            }
        }
    }
}
