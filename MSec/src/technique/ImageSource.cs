/*******************************************************************************************************************************************************************
	File	:	ImageSource.cs
	Project	:	MSec
	Author	:	Byron Worms
*******************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

/*******************************************************************************************************************************************************************
	Class: ImageSource
*******************************************************************************************************************************************************************/
namespace MSec
{
    public sealed class ImageSource
    {
        // The ID of the image source (hash of the file path!)
        private int m_imageID = 0;
        public int ImageID
        {
            get { return m_imageID; }
            private set { }
        }

        // The file path of the image
        private string m_filePath = "";
        public string FilePath
        {
            get { return m_filePath; }
            private set { }
        }

        // The hash data
        private HashData[] m_hashData = new HashData[(int)TechniqueID.COUNT];

        // Constructor
        public ImageSource(string _path)
        {
            // Copy parameters
            m_filePath = _path;

            // Calcualte image's ID
            m_imageID = m_filePath.GetHashCode();

            // Create hash data 
            m_hashData[(int)TechniqueID.DCT] = Technique.createHashDataDCT();
            m_hashData[(int)TechniqueID.RADISH] = Technique.createHashDataRADISH();
            m_hashData[(int)TechniqueID.WAVELET] = Technique.createHashDataWavelet();
        }

        // Returns the hash data for a certain technique (can be invalid!)
        public HashData getHashDataForTechnique(TechniqueID _id)
        {
            return m_hashData[(int)_id];
        }

        // Sets the hash data for a certain technique (fails silently!)
        public void setHashDataForTechnique(TechniqueID _id, HashData _data)
        {
            // Local variables
            HashData data = m_hashData[(int)_id];

            // Compare types
            if (data.getDataType() != _data.getDataType())
                return;

            // Set data
            m_hashData[(int)_id] = _data;
        }

        // Creates a system image (System.Drawing)
        public Image createSystemImage()
        {
            return Image.FromFile(m_filePath);
        }
    }
}
