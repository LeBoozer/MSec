/*******************************************************************************************************************************************************************
	File	:	ImageSourceBinding.cs
	Project	:	MSec
	Author	:	Byron Worms
*******************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*******************************************************************************************************************************************************************
	Class: ImageSourceBinding
*******************************************************************************************************************************************************************/
namespace MSec
{
    public sealed class ImageSourceBinding
    {
        // The image source: RADISH
        private ImageSource m_sourceReference = null;
        public ImageSource SourceReference
        {
            get { return m_sourceReference; }
            private set { }
        }

        // The comparison data for the techniques
        private Dictionary<TechniqueID, ImageSource> m_imageSources = new Dictionary<TechniqueID, ImageSource>();

        // Constructor
        public ImageSourceBinding(ImageSource _srcReference)
        {
            // Copy
            m_sourceReference = _srcReference;
        }

        // Adds the image source for a certain technique
        public void setComparisonDataFor(TechniqueID _id, ImageSource _data)
        {
            m_imageSources.Add(_id, _data);
        }

        // Returns the image source for a certain technique (can be null!)
        public ImageSource getComparisonDataFor(TechniqueID _id)
        {
            if (m_imageSources.ContainsKey(_id) == false)
                return null;
            return m_imageSources[_id];
        }
    }
}
