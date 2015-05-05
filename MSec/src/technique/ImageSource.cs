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
using System.IO;

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

        // The ID of the image source's path (hash of the path!)
        public int m_pathID = 0;
        public int PathID
        {
            get { return m_pathID; }
            private set { }
        }

        // The file path of the image
        private string m_filePath = "";
        public string FilePath
        {
            get { return m_filePath; }
            private set { }
        }

        // The file's name (with its extension)
        public string FileName
        {
            get { return Path.GetFileName(m_filePath); }
        }

        // Returns the name of the directory
        public string Dir
        {
            get { return Path.GetDirectoryName(m_filePath); }
        }

        // The hash data
        private HashData m_hashData = null;
        public HashData HashData
        {
            get { return m_hashData; }
            set { m_hashData = value; }
        }

        // Wrapper for the hash
        public string Hash
        {
            get { return m_hashData.convertToString(); }
            private set { }
        }

        // Constructor
        public ImageSource(string _path)
        {
            // Copy parameters
            m_filePath = _path;

            // Calcualte image's ID
            m_imageID = m_filePath.GetHashCode();
            m_pathID = Dir.GetHashCode();
        }

        // Creates a system image (System.Drawing)
        public Image createSystemImage()
        {
            return Image.FromFile(m_filePath);
        }
    }
}
