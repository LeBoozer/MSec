/*******************************************************************************************************************************************************************
	File	:	PHash.cs
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
	Class: PHash
*******************************************************************************************************************************************************************/
namespace MSec
{
    internal static class PHash
    {
        // Dll function: import -> ph_image_digest (radial hashing)
        [DllImport(@"pHash.dll", EntryPoint = "ph_image_digest", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int computeRadialHash(string _file, double _sigma, double _gamma, IntPtr _digest, int _numberOfAngles);

        // Dll function: import -> ph_image_digest_dump_to_file (radial hashing)
        [DllImport(@"pHash.dll", EntryPoint = "ph_image_digest_dump_to_file", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int dumpRadialHashToDisk(string _file, double _sigma, double _gamma, int _numberOfAngles,
            string _fileGrayscale, string _fileBlurred, string _fileRadon, string _fileFeature, string _fileDCT);

        // Dll function: import -> ph_dct_imagehash (DCT hashing)
        [DllImport(@"pHash.dll", EntryPoint = "ph_dct_imagehash", CallingConvention = CallingConvention.Cdecl, CharSet=CharSet.Ansi)]
        public static extern int computeDCTHash(string _file, ref ulong _hash);

        // Dll function: import -> ph_dct_imagehash_dump_to_file (DCT hashing)
        [DllImport(@"pHash.dll", EntryPoint = "ph_dct_imagehash_dump_to_file", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int dumpDCTHashToDisk(string _file, string _fileMeanFilter, string _fileResized, string _fileDCTMatrix, string _fileDCTImage,
            string _fileDCTImageSubsec, string _fileDCTMedian);

        // Dll function: import -> ph_mh_imagehash (wavelet hashing)
        [DllImport(@"pHash.dll", EntryPoint = "ph_mh_imagehash", CallingConvention = CallingConvention.Cdecl, CharSet=CharSet.Ansi)]
        public static extern IntPtr computeWaveletHash(string _file, ref int _hashLength, float _alpha, float _level);

        // Dll function: import -> ph_mh_imagehash_dump_to_file (wavelet hashing)
        [DllImport(@"pHash.dll", EntryPoint = "ph_mh_imagehash_dump_to_file", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int dumpWaveletHashToDisk(string _file, float _alpha, float _level, string _fileBlurred, string _fileKernel, string _fileEdges,
            string _fileBlocks);

        // Dll function: import -> ph_bmb_imagehash (BMB hashing)
        [DllImport(@"pHash.dll", EntryPoint = "ph_bmb_imagehash", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int computeBMBHash(string _file, int _method, out IntPtr _hash);

        // Dll function: import -> ph_bmb_imagehash_dump_to_file (BMB hashing)
        [DllImport(@"pHash.dll", EntryPoint = "ph_bmb_imagehash_dump_to_file", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int dumpBMBHashToDisk(string _file, int _method, string _fileResized, string _fileBlockMedians, string _fileMedian);

        // Dll function: import -> ph_crosscorr (cross correlation)
        [DllImport(@"pHash.dll", EntryPoint = "ph_crosscorr", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern int computeCrossCorrelation(IntPtr _d0, IntPtr _d1, ref double _peak, double _threshold = 0.90);

        // Dll function: import -> ph_hamming_distance (hamming distance)
        [DllImport(@"pHash.dll", EntryPoint = "ph_hamming_distance", CallingConvention = CallingConvention.Cdecl, CharSet=CharSet.Ansi)]
        public static extern int computeHammingDistance(UInt64 _hash0, UInt64 _hash1);

        // Dll function: import -> ph_hamming_distance2 (hamming distance)
        [DllImport(@"pHash.dll", EntryPoint = "ph_hammingdistance2", CallingConvention = CallingConvention.Cdecl, CharSet=CharSet.Ansi)]
        public static extern double computeHammingDistance(IntPtr _hash0, int _length0, IntPtr _hash1, int _length1);
    }
}
