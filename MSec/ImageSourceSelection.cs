/*******************************************************************************************************************************************************************
	File	:	ImageSourceSelection.cs
	Project	:	MSec
	Author	:	Byron Worms
*******************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*******************************************************************************************************************************************************************
	Class: TechniqueSelection
*******************************************************************************************************************************************************************/
namespace MSec
{
    public partial class ImageSourceSelection : UserControl
    {
        // The data lock
        private object m_dataLock = new object();

        // The current image source
        private ImageSource m_imageSource = null;
        public ImageSource Source
        {
            get { return m_imageSource; }
            private set { }
        }

        #region Controls
        private PictureBox      m_picturePreview = null;
        private TextBox         m_textPath = null;
        private TextBox         m_textInstructions = null;
        private Button          m_buttonLoad = null;
        private Button          m_buttonDelete = null;
        #endregion Controls

        // Delegate functions
        private delegate void delegate_internal_setImagePreview(Image _image);
        private delegate void delegate_internal_onImageSourceChanged(bool _deleted = false);
        public delegate void delegate_onImageSourceChanging();
        public delegate void delegate_onImageSourceChanged(bool _deleted = false);

        // Events
        public event delegate_onImageSourceChanging OnImageSourceChanging = delegate { };
        public event delegate_onImageSourceChanged OnImageSourceChanged = delegate { };

        // Constructor
        public ImageSourceSelection()
        {
            // Initialize the user control's component
            InitializeComponent();

            // Initialize user control
            initializeUserControl();
        }

        // Locks the image selection
        public void lockImageSourceSelection()
        {
            // Run in GUI thread
            Utility.invokeInGuiThread(this, delegate
            {
                // Just disable important controls
                m_buttonLoad.Enabled = false;
                m_buttonDelete.Enabled = false;

                // Disable drag&drop
                this.AllowDrop = false;
            });
        }

        // Unlocks the image selection
        public void unlockImageSourceSelection()
        {
            // Run in GUI thread
            Utility.invokeInGuiThread(this, delegate
            {
                // Just enable important controls
                m_buttonLoad.Enabled = true;
                 m_buttonDelete.Enabled = true;

                // Enale drag&drop
                this.AllowDrop = true;
            });
        }

        // Sets the instruction text
        public void setInstructionText(string _text)
        {
            // Run in GUI thread
            Utility.invokeInGuiThread(m_textInstructions, delegate
            {
                m_textInstructions.Text = _text;
            });
        }

        // Initializes the user control
        private void initializeUserControl()
        {
            #region Controls
            // Get controls
            m_picturePreview = this.Picture_Preview;
            m_textPath = this.Text_Path;
            m_textInstructions = this.Text_Instructions;
            m_buttonLoad = this.Button_Load;
            m_buttonDelete = this.Button_Delete;
            #endregion Controls

            // Add own event listener
            OnImageSourceChanging += () => { lockImageSourceSelection(); };
            OnImageSourceChanged += (bool _deleted) => { unlockImageSourceSelection(); };
        }

        // Creates the image source from a defined file
        private void createImageSource(string _path)
        {
            // Local variables
            Job<ImageSource> job = null;

            // Notify listener
            OnImageSourceChanging();

            // Create loader job
            job = new Job<ImageSource>((object[] _params) =>
            {
                // Local variables
                ImageSource res = null;
                Image img = null;

                // Create source
                res = new ImageSource(_params[0] as string);

                // Create preview
                img = res.createSystemImage();
                Utility.invokeInGuiThread(m_picturePreview, delegate
                {
                    m_picturePreview.Image = img;
                    m_textPath.Text = _params[0] as string;
                });

                return res;
            },
            (ImageSource _result, Exception _error) =>
            {
                // Set image source
                lock(m_dataLock)
                {
                    m_imageSource = _result;
                }

                // Notify listener
                OnImageSourceChanged(false);
            },
            true, new object[]{_path});
        }

        #region Events: Controls
        private void Button_Load_Click(object sender, EventArgs e)
        {
            // Local variables
            string path = "";

            // Pick image file
            path = Utility.openSelectImageDialog();
            if (path != null && path.Length > 0)
                createImageSource(path);
        }

        private void Button_Delete_Click(object sender, EventArgs e)
        {
            // Clear data
            lock(m_dataLock)
            {
                m_imageSource = null;
                m_picturePreview.Image = null;
                m_textPath.Text = "";
                m_textInstructions.Text = "";
            }

            // Notify listener
            OnImageSourceChanged(true);
        }

        private void ImageSourceSelection_DragEnter(object _sender, DragEventArgs _e)
        {
            // Check if the data format of the data can be accepted
            // TODO
            if (_e.Data.GetDataPresent(DataFormats.FileDrop))
                _e.Effect = DragDropEffects.Copy; // Okay
            else
                _e.Effect = DragDropEffects.None; // Unknown data, ignore it
        }

        private void ImageSourceSelection_DragDrop(object _sender, DragEventArgs _e)
        {
            // Local variables
            string[] list = null;

            // Extract data from the drop object
            list = (string[])_e.Data.GetData(DataFormats.FileDrop, false);

            // Create image source
            if (list != null && list.Length > 0)
                createImageSource(list[0]);
        }
        #endregion Events: Controls
    }
}
