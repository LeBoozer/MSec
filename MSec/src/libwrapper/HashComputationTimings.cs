/*******************************************************************************************************************************************************************
	File	:	HashComputationTimings.cs
	Project	:	MSec
	Author	:	Byron Worms
*******************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

/*******************************************************************************************************************************************************************
	Class: HashComputationTimings
*******************************************************************************************************************************************************************/
namespace MSec
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class HashComputationTimings
    {
        public double m_imageLoadingTimeMS = 0;
        public double m_hashComputationTimeMS = 0;
    }
}
