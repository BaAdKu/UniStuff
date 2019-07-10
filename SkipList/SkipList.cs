using System;
using System.Collections.Generic;
using System.Text;


namespace SkipList
{
    class SkipList
    {
        public List<SkipListNode> List
        {
            get;
            set;
        }
        public SkipListNode First
        {
            get;
            set;
        }
        public List<List<int>> ShortCuts
        {
            get;
            set;
        }
        SkipList(int[] NumberArray)
        {
            
        }       
    }
}
