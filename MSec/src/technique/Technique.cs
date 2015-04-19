/*******************************************************************************************************************************************************************
	File	:	Technique.cs
	Project	:	MSec
	Author	:	Byron Worms
*******************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*******************************************************************************************************************************************************************
	Interface: TechniqueID
*******************************************************************************************************************************************************************/
namespace MSec
{
    public enum TechniqueID
    {
        RADISH = 0,
        DCT = 1,
        WAVELET = 2,

        COUNT = 3
    }
}

/*******************************************************************************************************************************************************************
	Class: Technique
*******************************************************************************************************************************************************************/
namespace MSec
{
    public abstract class Technique
    {
        // Constant and pre-defined names of attributes for the common techniques
        public static readonly string ATT_RADISH_GAMMA = "radish_gamma";
        public static readonly string ATT_RADISH_SIGMA = "radish_sigma";
        public static readonly string ATT_RADISH_NUM_ANGLES = "radish_num_angles";
        public static readonly string ATT_WAVELET_ALPHA = "wavelet_alpha";
        public static readonly string ATT_WAVELET_LEVEL = "wavelet_level";

        // The technique's ID
        protected TechniqueID m_techniqueID;
        public TechniqueID ID
        {
            get { return m_techniqueID; }
            private set { }
        }

        // The technique's attribute list
        protected Dictionary<string, object> m_attributeList = new Dictionary<string, object>();

        // Constructor
        public Technique(TechniqueID _techniqueID)
        {
            // Copy parameter
            m_techniqueID = _techniqueID;
        }

        // Checks whether a certain attribute is available (by name)
        public bool isAttributeAvailable(string _name)
        {
            return m_attributeList.ContainsKey(_name);
        }

        // Adds an attribute to the list
        // Returns true on success
        public bool addAttribute(string _name, object _value)
        {
            // Check parameteer
            if (_name == null || _name.Length == 0 || _value == null)
                return false;

            // Add
            m_attributeList[_name] = _value;
            return true;
        }

        // Tries to find a defined attribute
        // Returns true on success
        public bool getAttribute(string _name, out object _dst)
        {
            // Check parameteer
            if (_name == null || _name.Length == 0)
            {
                _dst = null;
                return false;
            }

            // Available?
            if (isAttributeAvailable(_name) == false)
            {
                _dst = null;
                return false;
            }

            // Get attribute
            _dst = m_attributeList[_name];

            return true;
        }

        // Tries to find a defined attribute
        // Returns true on success
        public bool getAttribute<_T>(string _name, out _T _dst)
        {
            // Check parameteer
            if (_name == null || _name.Length == 0)
            {
                _dst = default(_T);
                return false;
            }

            // Available?
            if (isAttributeAvailable(_name) == false)
            {
                _dst = default(_T);
                return false;
            }

            // Get attribute
            _dst = (_T)m_attributeList[_name];

            return true;
        }

        // Returns the type of the hash data
        public abstract Type getHashDataType();

        // Returns the type of the comparator data
        public abstract Type getComparatorDataType();

        // Checks whether the hash data contains the default value for its internal type
        public abstract bool containsHashDataDefaultValue(HashData _data);

        // Checks whether the comparative data contains the default value for its internal type
        public abstract bool containsComparativeDataDefaultValue(ComparativeData _data);

        // Computes the hash for a given image
        public abstract HashData computeHash(ImageSource _image, bool _recompute = false);

        // Compares two hash data structures (return null if the hast data's format is invalid!)
        public abstract ComparativeData compareHashData(HashData _data0, HashData _data1);

        // Compares two image sources based on their hashes (return null if the hast data's format is invalid!)
        public abstract ComparativeData compareHashData(ImageSource _source0, ImageSource _source1);

        // Create the default technique instance for the algorithm: RADISH
        public static Technique<Digest, RadishComparativeData> createTechniqueRadish()
        {
            // Local variables
            Technique<Digest, RadishComparativeData> t = null;

            // Create technique
            t = new Technique<Digest, RadishComparativeData>(TechniqueID.RADISH,
                (Technique _t, ImageSource _image) =>
                {
                    // Local variables
                    Digest hash = new Digest();
                    IntPtr hashUnmanaged = IntPtr.Zero;
                    HashData<Digest> result = null;
                    decimal attGamma = 1.0m;
                    decimal attSigma = 1.0m;
                    decimal attAngles = 180m;

                    // Extract attributes
                    if (_t.isAttributeAvailable(Technique.ATT_RADISH_GAMMA) == true)
                        _t.getAttribute<decimal>(Technique.ATT_RADISH_GAMMA, out attGamma);
                    if (_t.isAttributeAvailable(Technique.ATT_RADISH_SIGMA) == true)
                        _t.getAttribute<decimal>(Technique.ATT_RADISH_SIGMA, out attSigma);
                    if (_t.isAttributeAvailable(Technique.ATT_RADISH_NUM_ANGLES) == true)
                        _t.getAttribute<decimal>(Technique.ATT_RADISH_NUM_ANGLES, out attAngles);

                    // Convert managed to unmanaged
                    hashUnmanaged = Utility.convertSimpleStructureToUnmanagedPtr<Digest>(hash);

                    // Comnpute hash
                    PHash.computeRadialHash(_image.FilePath, Convert.ToSingle(attSigma), Convert.ToSingle(attGamma), hashUnmanaged, (int)(Convert.ToSingle(attAngles)));

                    // Convert unmanaged to managed
                    Utility.convertUnmanagedPtrToSimpleStructure<Digest>(hashUnmanaged, ref hash);

                    // Store result
                    result = new HashData<Digest>(hash, (Digest _data) =>
                    {
                        return Utility.toHexString(_data.m_coeffs, _data.m_size);
                    });
                    return result;
                },
                (Technique _t, HashData<Digest> _h0, HashData<Digest> _h1) =>
                {
                    // Local variables
                    RadishComparativeData result = null;
                    int isSame = 0;
                    double peak = 0.0;
                    IntPtr h0 = IntPtr.Zero;
                    IntPtr h1 = IntPtr.Zero;

                    // Compute cross correlation
                    h0 = Utility.convertSimpleStructureToUnmanagedPtr<Digest>(_h0.Data);
                    h1 = Utility.convertSimpleStructureToUnmanagedPtr<Digest>(_h1.Data);
                    isSame = PHash.computeCrossCorrelation(h0, h1, ref peak);

                    // Store result
                    result = new RadishComparativeData();
                    result.m_crossCorrelationPeak = peak;
                    result.m_isDifferent = isSame == 1 ? false : true;
                    return new ComparativeData<RadishComparativeData>(result, (RadishComparativeData _data) =>
                    {
                        return "Peak: " + _data.m_crossCorrelationPeak;
                    });
                }
            );

            return t;
        }

        // Create the default technique instance for the algorithm: DCT
        public static Technique<UInt64, int> createTechniqueDCT()
        {
            // Local variables
            Technique<UInt64, int> t = null;

            // Create technique
            t = new Technique<UInt64, int>(TechniqueID.DCT,
                (Technique _t, ImageSource _image) =>
                {
                    // Local variables
                    UInt64 hash = 0;
                    HashData<UInt64> result = null;

                    // Compute hast
                    PHash.computeDCTHash(_image.FilePath, ref hash);

                    // Store result
                    result = new HashData<UInt64>(hash);
                    return result;
                },
                (Technique _t, HashData<UInt64> _h0, HashData<UInt64> _h1) =>
                {
                    // Local variables
                    int dis = 0;
                    ComparativeData<int> result = null;

                    // Compute distance
                    dis = PHash.computeHammingDistance(_h0.Data, _h1.Data);

                    // Store result
                    result = new ComparativeData<int>(dis, (int _d) =>
                    {
                        return "Hamming distance: " + _d.ToString();
                    });
                    return result;
                }
            );

            return t;
        }

        // Create the default technique instance for the algorithm: wavelet
        public static Technique<WaveletHash, double> createTechniqueWavelet()
        {
            // Local variables
            Technique<WaveletHash, double> t = null;

            // Create technique
            t = new Technique<WaveletHash, double>(TechniqueID.WAVELET,
                (Technique _t, ImageSource _image) =>
                {
                    // Local variables
                    int len = 0;
                    IntPtr hash;
                    WaveletHash data = new WaveletHash();
                    HashData<WaveletHash> result = null;
                    decimal attAlpha = 2m;
                    decimal attLevel = 1m;

                    // Extract attributes
                    if (_t.isAttributeAvailable(Technique.ATT_WAVELET_ALPHA) == true)
                        _t.getAttribute<decimal>(Technique.ATT_WAVELET_ALPHA, out attAlpha);
                    if (_t.isAttributeAvailable(Technique.ATT_WAVELET_LEVEL) == true)
                        _t.getAttribute<decimal>(Technique.ATT_WAVELET_LEVEL, out attLevel);

                    // Compute hast
                    hash = PHash.computeWaveletHash(_image.FilePath, ref len, Convert.ToSingle(attAlpha), Convert.ToSingle(attLevel));

                    // Store result
                    data.m_data = hash;
                    data.m_dataLength = len;
                    result = new HashData<WaveletHash>(data, (WaveletHash _data) =>
                    {
                        return Utility.toHexString(_data.m_data, _data.m_dataLength);
                    });
                    return result;
                },
                (Technique _t, HashData<WaveletHash> _h0, HashData<WaveletHash> _h1) =>
                {
                    // Local variables
                    double dis = 0;
                    ComparativeData<double> result = null;

                    // Compute distance
                    dis = PHash.computeHammingDistance(_h0.Data.m_data, _h0.Data.m_dataLength, _h1.Data.m_data, _h1.Data.m_dataLength);

                    // Store result
                    result = new ComparativeData<double>(dis, (double _d) =>
                    {
                        return "Normalized hamming distance: " + _d.ToString("#0.0000");
                    });
                    return result;
                }
            );

            return t;
        }

        // Creates the default hash data for the DCT algorithm
        public static HashData<UInt64> createHashDataDCT()
        {
            return new HashData<UInt64>(default(UInt64));
        }

        // Creates the default hash data for the RADISH algorithm
        public static HashData<Digest> createHashDataRADISH()
        {
            return new HashData<Digest>(default(Digest));
        }

        // Creates the default hash data for the RADISH algorithm
        public static HashData<WaveletHash> createHashDataWavelet()
        {
            return new HashData<WaveletHash>(default(WaveletHash));
        }
    }
}

/*******************************************************************************************************************************************************************
	Class: Technique
*******************************************************************************************************************************************************************/
namespace MSec
{
    public sealed class Technique<_HR, _CR> : Technique
        where _HR : new()
        where _CR : new()
    {
        // Delegate for the hashing function
        public delegate HashData<_HR> delegate_hash(Technique _t, ImageSource _image);

        // Delegate for the comparator function
        public delegate ComparativeData<_CR> delegate_comp(Technique _t, HashData<_HR> _hash0, HashData<_HR> _hash1);

        // The hashing function
        private delegate_hash m_funcHash = null;

        // The comp. function
        private delegate_comp m_funcComp = null;

        // Constructor
        public Technique(TechniqueID _techniqueID, delegate_hash _hashFunc, delegate_comp _compFunc) :
            base(_techniqueID)
        {
            // Copy parameter
            m_funcHash = _hashFunc;
            m_funcComp = _compFunc;
        }

        // Override: HashData::getHashDataType
        public override Type getHashDataType()
        {
            return typeof(_HR);
        }

        // Override: HashData::getComparatorDataType
        public override Type getComparatorDataType()
        {
            return typeof(_CR);
        }

        // Override: HashData::containsHashDataDefaultValue
        public override bool containsHashDataDefaultValue(HashData _data)
        {
            // Local variables
            HashData<_HR> typedData = null;

            // Check parameter
            if (_data == null || _data.getDataType() != getHashDataType())
                return false;
            typedData = (HashData<_HR>)_data;

            // The default value?
            if (EqualityComparer<_HR>.Default.Equals(typedData.Data, default(_HR)))
                return true;

            return false;
        }

        // Override: HashData::containsComparativeDataDefaultValue
        public override bool containsComparativeDataDefaultValue(ComparativeData _data)
        {
            // Local variables
            ComparativeData<_CR> typedData = null;

            // Check parameter
            if (_data == null || _data.getDataType() != getComparatorDataType())
                return false;
            typedData = (ComparativeData<_CR>)_data;

            // The default value?
            if (EqualityComparer<_CR>.Default.Equals(typedData.Data, default(_CR)))
                return true;

            return false;
        }

        // Override: HashData::computeHash
        public override HashData computeHash(ImageSource _image, bool _recompute = false)
        {
            // Local variables
            HashData data = null;
            HashData<_HR> typedData = null;

            // Check parameter
            if (_image == null)
                return null;

            // Recompute?
            if(_recompute == false)
            {
                if (containsHashDataDefaultValue(_image.getHashDataForTechnique(m_techniqueID)) == false)
                    return typedData;
            }

            // Compute hash
            data = m_funcHash(this, _image);

            // Assign result to image
            _image.setHashDataForTechnique(m_techniqueID, data);

            return data;
        }

        // Override: HashData::compareHashData
        public override ComparativeData compareHashData(HashData _data0, HashData _data1)
        {
            // Local variables
            ComparativeData data = null;

            // Check parameter
            if (_data0 == null || _data1 == null)
                return null;
            if (_data0.getDataType() != getHashDataType() || _data1.getDataType() != getHashDataType())
                return null;

            // Compare hash data
            data = m_funcComp(this, (HashData<_HR>)_data0, (HashData<_HR>)_data1);

            return data;
        }

        // Override: HashData::compareHashData
        public override ComparativeData compareHashData(ImageSource _source0, ImageSource _source1)
        {
            // Check parameter
            if (_source0 == null || _source1 == null)
                return null;

            return compareHashData(_source0.getHashDataForTechnique(ID), _source1.getHashDataForTechnique(ID));
        }
    }
}
