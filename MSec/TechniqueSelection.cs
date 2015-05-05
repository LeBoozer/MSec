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
        // Represent all possible modes for the technique selection
        public enum eMode
        {
            SINGLE,
            MULTIPLE
        }

        // The operation mode
        private eMode m_operationMode = eMode.SINGLE;
        public eMode OperationMode
        {
            get { return m_operationMode; }
            set { m_operationMode = value; _onOperatorModeChanged(value); }
        }

        // Current technique IDs
        private TechniqueID m_helperSingleMode = TechniqueID.DCT;
        private TechniqueID m_currentTechniqueIDs = 0;
        public TechniqueID CurrentTechniqueIDs
        {
            get { return m_currentTechniqueIDs; }
            private set { }
        }

        // General: threshold
        private decimal m_generalThreshold = 0;
        public decimal Threshold
        {
            get { return m_generalThreshold; }
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

        #region Values::BMB
        // Radish: gamma
        private int m_bmbMethod = 0;
        public int BMBMethod
        {
            get { return m_bmbMethod; }
            private set { }
        }
        #endregion Values::BMB

        #region Controls::General
        private NumericUpDown m_numberGeneralThreshold = null;
        #endregion Controls::General

        #region Controls::Technique::Radish
        private CheckBox m_checkTechniqueRadish = null;
        private Label m_labelRadishGamma = null;
        private Label m_labelRadishSigma = null;
        private Label m_labelRadishAngles = null;
        private NumericUpDown m_numberRadishGamma = null;
        private NumericUpDown m_numberRadishSigma = null;
        private NumericUpDown m_numberRadishAngles = null;
        #endregion Controls::Technique::Radio

        #region Controls::Technique::DCT
        private CheckBox m_checkTechniqueDCT = null;
        #endregion Controls::Technique::DCT

        #region Controls::Technique::Wavelet
        private CheckBox m_checkTechniqueWavelet = null;
        private Label m_labelWaveletAlpha = null;
        private Label m_labelWaveletLevel = null;
        private NumericUpDown m_numberWaveletAlpha = null;
        private NumericUpDown m_numberWaveletLevel = null;
        #endregion Controls::Technique::Wavelet

        #region Controls::Technique::BMB
        private CheckBox m_checkTechniqueBMB = null;
        private Label m_labelBMBMethod = null;
        private ComboBox m_comboBMBMethod = null;
        #endregion Controls::Technique::BMB

        // Delegate functions
        public delegate void delegate_onOperatorModeChanged(eMode _newMode);
        public delegate void delegate_onTechniqueIDsChanged(TechniqueID _nextTechnique);
        public delegate void delegate_onAttributeChanged();
        public delegate void delegate_onGeneralThresholdChanged(decimal _v);
        public delegate void delegate_onRadishGammaChanged(decimal _v);
        public delegate void delegate_onRadishSigmaChanged(decimal _v);
        public delegate void delegate_onRadishNumberOfAnglesChanged(decimal _v);
        public delegate void delegate_onWaveletAlphaChanged(decimal _v);
        public delegate void delegate_onWaveletLevelChanged(decimal _v);
        public delegate void delegate_onBMBMethodChanged(int _v);

        // Events
        public event delegate_onOperatorModeChanged OnOperatorModeChanged = delegate { };
        public event delegate_onTechniqueIDsChanged OnTechniqueIDsChanged = delegate { };
        public event delegate_onAttributeChanged OnAttributeChanged = delegate { };
        public event delegate_onGeneralThresholdChanged OnGeneralThresholdChanged = delegate { };
        public event delegate_onRadishGammaChanged OnRadishGammaChanged = delegate { };
        public event delegate_onRadishSigmaChanged OnRadishSigmaChanged = delegate { };
        public event delegate_onRadishNumberOfAnglesChanged OnRadishNumberOfAnglesChanged = delegate { };
        public event delegate_onWaveletAlphaChanged OnWaveletAlphaChanged = delegate { };
        public event delegate_onWaveletLevelChanged OnWaveletLevelChanged = delegate { };
        public event delegate_onBMBMethodChanged OnBMBMethodChanged = delegate { };

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
            #region General
            // Get controls
            m_numberGeneralThreshold = this.Number_General_Threshold;

            // Extract default values
            m_generalThreshold = m_numberGeneralThreshold.Value;
            #endregion General

            #region Technique::Radish
            // Get controls
            m_checkTechniqueRadish = this.Check_Technique_Radish;
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
            m_checkTechniqueDCT = this.Check_Technique_DCT;
            #endregion Technique::DCT

            #region Technique::Wavelet
            // Get controls
            m_checkTechniqueWavelet = this.Check_Technique_Wavelet;
            m_labelWaveletAlpha = this.Label_Technique_Wavelet_Alpha;
            m_labelWaveletLevel = this.Label_Technique_Wavelet_Level;
            m_numberWaveletAlpha = this.Number_Technique_Wavelet_Alpha;
            m_numberWaveletLevel = this.Number_Technique_Wavelet_Level;

            // Extract default values
            m_waveletAlpha = m_numberWaveletAlpha.Value;
            m_waveletLevel = m_numberWaveletLevel.Value;
            #endregion Technique::Wavelet

            #region Technique::BMB
            // Get controls
            m_checkTechniqueBMB = this.Check_Technique_BMB;
            m_labelBMBMethod = this.Label_Technique_BMB_Method;
            m_comboBMBMethod = this.Combo_Technique_BMB_Method;

            // Extract default values
            m_comboBMBMethod.SelectedIndex = 0;
            m_bmbMethod = int.Parse(m_comboBMBMethod.Text);
            #endregion Technique::BMB

            #region Set start technique IDs
            // Set start technique ID
            if (m_checkTechniqueDCT.Checked == true)
            {
                m_helperSingleMode = TechniqueID.DCT;
                m_currentTechniqueIDs |= TechniqueID.DCT;
            }
            if (m_checkTechniqueWavelet.Checked == true)
            {
                m_helperSingleMode = TechniqueID.WAVELET;
                m_currentTechniqueIDs |= TechniqueID.WAVELET;
            }
            if (m_checkTechniqueRadish.Checked == true)
            {
                m_helperSingleMode = TechniqueID.RADISH;
                m_currentTechniqueIDs |= TechniqueID.RADISH;
            }
            if (m_checkTechniqueBMB.Checked == true)
            {
                m_helperSingleMode = TechniqueID.BMB;
                m_currentTechniqueIDs |= TechniqueID.BMB;
            }

            // Disable controls from not set technique IDs
            if ((m_currentTechniqueIDs & TechniqueID.DCT) != TechniqueID.DCT)
                setTechniqueControlsEnabled(TechniqueID.DCT, false);
            if ((m_currentTechniqueIDs & TechniqueID.WAVELET) != TechniqueID.WAVELET)
                setTechniqueControlsEnabled(TechniqueID.WAVELET, false);
            if ((m_currentTechniqueIDs & TechniqueID.RADISH) != TechniqueID.RADISH)
                setTechniqueControlsEnabled(TechniqueID.RADISH, false);
            if ((m_currentTechniqueIDs & TechniqueID.BMB) != TechniqueID.BMB)
                setTechniqueControlsEnabled(TechniqueID.BMB, false);
            #endregion Set start technique IDs
        }

        // Handles operator mode changes
        private void _onOperatorModeChanged(eMode _newMode)
        {
            // Notify listener
            OnOperatorModeChanged(_newMode);
        }

        // Handles technique selection events
        // Returns false if invalid operation
        private bool _onTechniqueSelectionChanged(TechniqueID _selectedTechnique, bool _checked)
        {
            // Local variables
            TechniqueID tempIDs = 0;

            // Choose operator mode
            if(m_operationMode == eMode.SINGLE)
            {
                // Technique cannot be unselected
                if (m_helperSingleMode == _selectedTechnique && _checked == false)
                    return false;

                // Disable current technique's controls
                setTechniqueControlsEnabled(m_helperSingleMode, false, true);

                // Set
                m_currentTechniqueIDs &= ~m_helperSingleMode;
                m_helperSingleMode = _selectedTechnique;
                m_currentTechniqueIDs |= _selectedTechnique;

                // Enable current technique's controls
                setTechniqueControlsEnabled(m_helperSingleMode, true);

                // Notify listener
                OnTechniqueIDsChanged(m_currentTechniqueIDs);
            }
            else
            {
                // Check?
                if(_checked == true)
                {
                    // Add technique
                    m_currentTechniqueIDs |= _selectedTechnique;

                    // Enable technique's controls
                    setTechniqueControlsEnabled(_selectedTechnique, true);
                }
                else
                {
                    // Save current IDs
                    tempIDs = m_currentTechniqueIDs;

                    // Remove technique from IDs
                    tempIDs &= ~_selectedTechnique;
                    if (tempIDs == 0)
                        return false;       // At least one technique must be set!

                    // Apply changes
                    m_currentTechniqueIDs = tempIDs;
                    setTechniqueControlsEnabled(_selectedTechnique, false);
                }

                // Notify listener
                OnTechniqueIDsChanged(m_currentTechniqueIDs);
            }

            return true;
        }

        // Enables/disables the controls of the specified technique 
        private void setTechniqueControlsEnabled(TechniqueID _id, bool _enabled, bool _clearCheckState = false)
        {
            // RADISH?
            if (_id == TechniqueID.RADISH)
            {
                if (_clearCheckState == true)
                    m_checkTechniqueRadish.Checked = false;
                m_labelRadishGamma.Enabled = _enabled;
                m_labelRadishSigma.Enabled = _enabled;
                m_labelRadishAngles.Enabled = _enabled;
                m_numberRadishSigma.Enabled = _enabled;
                m_numberRadishGamma.Enabled = _enabled;
                m_numberRadishAngles.Enabled = _enabled;
            }

            // Wavelet?
            else if (_id == TechniqueID.WAVELET)
            {
                if (_clearCheckState == true)
                    m_checkTechniqueWavelet.Checked = false;
                m_labelWaveletAlpha.Enabled = _enabled;
                m_labelWaveletLevel.Enabled = _enabled;
                m_numberWaveletAlpha.Enabled = _enabled;
                m_numberWaveletLevel.Enabled = _enabled;
            }

            // BMB
            else if (_id == TechniqueID.BMB)
            {
                if (_clearCheckState == true)
                    m_checkTechniqueBMB.Checked = false;
                m_labelBMBMethod.Enabled = _enabled;
                m_comboBMBMethod.Enabled = _enabled;
            }

            // DCT
            else if(_id == TechniqueID.DCT)
            {
                if (_clearCheckState == true)
                    m_checkTechniqueDCT.Checked = false;
            }
        }

        #region Events: Check::Click
        private void Check_Technique_Radish_Click(object sender, EventArgs e)
        {
            // Local variables
            CheckBox button = sender as CheckBox;

            // Try to change selection
            if (_onTechniqueSelectionChanged(TechniqueID.RADISH, !button.Checked) == false)
                return;

            // Apply changes
            button.Checked = !button.Checked;
        }

        private void Check_Technique_DCT_Click(object sender, EventArgs e)
        {
            // Local variables
            CheckBox button = sender as CheckBox;

            // Try to change selection
            if (_onTechniqueSelectionChanged(TechniqueID.DCT, !button.Checked) == false)
                return;

            // Apply changes
            button.Checked = !button.Checked;
        }

        private void Check_Technique_Wavelet_Click(object sender, EventArgs e)
        {
            // Local variables
            CheckBox button = sender as CheckBox;

            // Try to change selection
            if (_onTechniqueSelectionChanged(TechniqueID.WAVELET, !button.Checked) == false)
                return;

            // Apply changes
            button.Checked = !button.Checked;
        }

        private void Check_Technique_BMB_Click(object sender, EventArgs e)
        {
            // Local variables
            CheckBox button = sender as CheckBox;

            // Try to change selection
            if (_onTechniqueSelectionChanged(TechniqueID.BMB, !button.Checked) == false)
                return;

            // Apply changes
            button.Checked = !button.Checked;
        }
        #endregion Events: Check::Click

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

        #region Events: Technique: BMB
        private void Combo_Technique_BMB_Method_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Set value and notify
            m_bmbMethod = int.Parse(m_comboBMBMethod.Text);
            OnBMBMethodChanged(m_bmbMethod);
            OnAttributeChanged();
        }
        #endregion Events: Technique: BMB

        #region Events: General
        private void Number_General_Threshold_ValueChanged(object sender, EventArgs e)
        {
            // Set value and notify
            m_generalThreshold = m_numberGeneralThreshold.Value;
            OnGeneralThresholdChanged(m_generalThreshold);
            OnAttributeChanged();
        }
        #endregion Events: General


    }
}
