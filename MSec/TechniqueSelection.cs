/*******************************************************************************************************************************************************************
	File	:	TechniqueSelection.cs
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
    public partial class TechniqueSelection : UserControl
    {
        // Current technique
        private TechniqueID m_currentTechniqueID = TechniqueID.COUNT;
        public TechniqueID CurrentTechniqueID
        {
            get { return m_currentTechniqueID; }
            private set { }
        }

        #region Values::Radish
        // Radish: gamma
        private decimal m_radishGamma = 0;
        public decimal RadishGamma
        {
            get { return m_radishGamma; }
            private set { }
        }

        // Radish: sigma
        private decimal m_radishSigma = 0;
        public decimal RadishSigma
        {
            get { return m_radishSigma; }
            private set { }
        }

        // Radish: angles
        private decimal m_radishAngles = 0;
        public decimal RadishNumberOfAngles
        {
            get { return m_radishAngles; }
            private set { }
        }
        #endregion Values::Radish

        #region Values::Wavelet
        // Radish: gamma
        private decimal m_waveletAlpha = 0;
        public decimal WaveletAlpha
        {
            get { return m_waveletAlpha; }
            private set { }
        }

        // Radish: sigma
        private decimal m_waveletLevel = 0;
        public decimal WaveletLevel
        {
            get { return m_waveletLevel; }
            private set { }
        }
        #endregion Values::Wavelet

        #region Controls::Technique::Radish
        private RadioButton m_radioTechniqueRadish = null;
        private Label m_labelRadishGamma = null;
        private Label m_labelRadishSigma = null;
        private Label m_labelRadishAngles = null;
        private NumericUpDown m_numberRadishGamma = null;
        private NumericUpDown m_numberRadishSigma = null;
        private NumericUpDown m_numberRadishAngles = null;
        #endregion Controls::Technique::Radio

        #region Controls::Technique::DCT
        private RadioButton m_radioTechniqueDCT = null;
        #endregion Controls::Technique::DCT

        #region Controls::Technique::Wavelet
        private RadioButton m_radioTechniqueWavelet = null;
        private Label m_labelWaveletAlpha = null;
        private Label m_labelWaveletLevel = null;
        private NumericUpDown m_numberWaveletAlpha = null;
        private NumericUpDown m_numberWaveletLevel = null;
        #endregion Controls::Technique::Wavelet

        // Delegate functions
        public delegate void delegate_onTechniqueChanged(TechniqueID _nextTechnique);
        public delegate void delegate_onAttributeChanged();
        public delegate void delegate_onRadishGammaChanged(decimal _v);
        public delegate void delegate_onRadishSigmaChanged(decimal _v);
        public delegate void delegate_onRadishNumberOfAnglesChanged(decimal _v);
        public delegate void delegate_onWaveletAlphaChanged(decimal _v);
        public delegate void delegate_onWaveletLevelChanged(decimal _v);

        // Events
        public event delegate_onTechniqueChanged OnTechniqueChanged = delegate { };
        public event delegate_onAttributeChanged OnAttributeChanged = delegate { };
        public event delegate_onRadishGammaChanged OnRadishGammaChanged = delegate { };
        public event delegate_onRadishSigmaChanged OnRadishSigmaChanged = delegate { };
        public event delegate_onRadishNumberOfAnglesChanged OnRadishNumberOfAnglesChanged = delegate { };
        public event delegate_onWaveletAlphaChanged OnWaveletAlphaChanged = delegate { };
        public event delegate_onWaveletLevelChanged OnWaveletLevelChanged = delegate { };

        // Constructor
        public TechniqueSelection()
        {
            // Initialize the user control's component
            InitializeComponent();

            // Initialize user control
            initializeUserControl();
        }

        // Initializes the user control
        private void initializeUserControl()
        {
            #region Technique::Radish
            // Get controls
            m_radioTechniqueRadish = this.Radio_Technique_Radish;
            m_labelRadishGamma = this.Label_Technique_Radish_Gamma;
            m_labelRadishSigma = this.Label_Technique_Radish_Sigma;
            m_labelRadishAngles = this.Label_Technique_Radish_Angles;
            m_numberRadishGamma = this.Number_Technique_Radish_Gamma;
            m_numberRadishSigma = this.Number_Technique_Radish_Sigma;
            m_numberRadishAngles = this.Number_Technique_Radish_Angles;

            // Extract default values
            m_radishGamma = m_numberRadishGamma.Value;
            m_radishSigma = m_numberRadishSigma.Value;
            m_radishAngles = m_numberRadishAngles.Value;
            #endregion Technique::Radish

            #region Technique::DCT
            // Get controls
            m_radioTechniqueDCT = this.Radio_Technique_DCT;
            #endregion Technique::DCT

            #region Technique::Wavelet
            // Get controls
            m_radioTechniqueWavelet = this.Radio_Technique_Wavelet;
            m_labelWaveletAlpha = this.Label_Technique_Wavelet_Alpha;
            m_labelWaveletLevel = this.Label_Technique_Wavelet_Level;
            m_numberWaveletAlpha = this.Number_Technique_Wavelet_Alpha;
            m_numberWaveletLevel = this.Number_Technique_Wavelet_Level;

            // Extract default values
            m_waveletAlpha = m_numberWaveletAlpha.Value;
            m_waveletLevel = m_numberWaveletLevel.Value;
            #endregion Technique::Wavelet    

            // Set start technique ID
            if (m_radioTechniqueDCT.Checked == true)
            {
                m_currentTechniqueID = TechniqueID.DCT;
                techniqueControlsEnabled(TechniqueID.RADISH, false);
                techniqueControlsEnabled(TechniqueID.WAVELET, false);
            }
            else if (m_radioTechniqueWavelet.Checked == true)
            {
                m_currentTechniqueID = TechniqueID.WAVELET;
                techniqueControlsEnabled(TechniqueID.DCT, false);
                techniqueControlsEnabled(TechniqueID.RADISH, false);
            }
            else
            {
                m_currentTechniqueID = TechniqueID.RADISH;
                techniqueControlsEnabled(TechniqueID.DCT, false);
                techniqueControlsEnabled(TechniqueID.WAVELET, false);
            }
        }

        // Handles technique changes
        private void _onTechniqueChanged(TechniqueID _nextTechnique)
        {
            // Same technique?
            if (m_currentTechniqueID == _nextTechnique)
                return;

            // Disable current technique's controls
            techniqueControlsEnabled(m_currentTechniqueID, false);

            // Set
            m_currentTechniqueID = _nextTechnique;

            // Enable current technique's controls
            techniqueControlsEnabled(m_currentTechniqueID, true);

            // Notify listener
            OnTechniqueChanged(m_currentTechniqueID);
        }

        // Enables/disables the technique relevant controls
        private void techniqueControlsEnabled(TechniqueID _technique, bool _yesNo)
        {
            // RADISH?
            if(_technique == TechniqueID.RADISH)
            {
                m_labelRadishGamma.Enabled = _yesNo;
                m_labelRadishSigma.Enabled = _yesNo;
                m_labelRadishAngles.Enabled = _yesNo;
                m_numberRadishSigma.Enabled = _yesNo;
                m_numberRadishGamma.Enabled = _yesNo;
                m_numberRadishAngles.Enabled = _yesNo;
            }

            // Wavelet=
            else if(_technique == TechniqueID.WAVELET)
            {
                m_labelWaveletAlpha.Enabled = _yesNo;
                m_labelWaveletLevel.Enabled = _yesNo;
                m_numberWaveletAlpha.Enabled = _yesNo;
                m_numberWaveletLevel.Enabled = _yesNo;
            }
        }

        #region Events: Radio::CheckedChanged
        private void Radio_Technique_Radish_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton button = sender as RadioButton;
            if (button.Checked == true)
                _onTechniqueChanged(TechniqueID.RADISH);
        }

        private void Radio_Technique_DCT_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton button = sender as RadioButton;
            if (button.Checked == true)
                _onTechniqueChanged(TechniqueID.DCT);
        }

        private void Radio_Technique_Wavelet_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton button = sender as RadioButton;
            if (button.Checked == true)
                _onTechniqueChanged(TechniqueID.WAVELET);
        }
        #endregion Events: Radio::CheckedChanged

        #region Events: Technique: Radish
        private void Number_Technique_Radish_Gamma_ValueChanged(object sender, EventArgs e)
        {
            // Set value and notify
            m_radishGamma = m_numberRadishGamma.Value;
            OnRadishGammaChanged(m_radishGamma);
            OnAttributeChanged();
        }

        private void Number_Technique_Radish_Sigma_ValueChanged(object sender, EventArgs e)
        {
            // Set value and notify
            m_radishSigma = m_numberRadishSigma.Value;
            OnRadishSigmaChanged(m_radishSigma);
            OnAttributeChanged();
        }

        private void Number_Technique_Radish_Angles_ValueChanged(object sender, EventArgs e)
        {
            // Set value and notify
            m_radishAngles = m_numberRadishAngles.Value;
            OnRadishNumberOfAnglesChanged(m_radishAngles);
            OnAttributeChanged();
        }
        #endregion Events: Technique: Radish

        #region Events: Technique: Wavelet
        private void Number_Technique_Wavelet_Alpha_ValueChanged(object sender, EventArgs e)
        {
            // Set value and notify
            m_waveletAlpha = m_numberWaveletAlpha.Value;
            OnWaveletAlphaChanged(m_waveletAlpha);
            OnAttributeChanged();
        }

        private void Number_Technique_Wavelet_Level_ValueChanged(object sender, EventArgs e)
        {
            // Set value and notify
            m_waveletLevel = m_numberWaveletLevel.Value;
            OnWaveletLevelChanged(m_waveletLevel);
            OnAttributeChanged();
        }
        #endregion Events: Technique: Wavelet
    }
}
