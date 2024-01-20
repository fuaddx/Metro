﻿using System.Collections;

namespace MetroMvc.ViewModels.Common
{
	public class PaginationVm<T> where T :IEnumerable
	{
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int LastPage { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrev { get; set; }
        public T Items { get; set; }
        public PaginationVm(int totalcount,int currentpage,int lastpage,T items)
        {
            if (currentpage < 0) throw new Exception();
            TotalCount = totalcount;
            CurrentPage = currentpage;
            LastPage = lastpage;
            Items = items;
            if(currentpage<=lastpage)
            {
                if (currentpage == 1)
                {
                    HasPrev = false;
                }
                else
                {
                    HasPrev = true;
                }
                if(currentpage == lastpage)
                {
                    HasNext = false;
                }
                else
                {
                    HasNext = true;
                }
            }
        }
    }
}
